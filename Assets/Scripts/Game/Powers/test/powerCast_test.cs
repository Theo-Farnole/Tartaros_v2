namespace Tartaros.Power
{
    using Sirenix.OdinInspector;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class powerCast_test : SerializedMonoBehaviour
    {
        [SerializeField]
        private PowerManager _powerManager = null;
        [SerializeField]
        private IPower _power = null;
        private GameInputs _input = null;

        private void Awake()
        {
            _input = new GameInputs();
            _input.Construction.Enable();

            _input.Construction.EnterConstruction.performed -= EnterConstruction_performed;
            _input.Construction.EnterConstruction.performed += EnterConstruction_performed;
        }

        private void EnterConstruction_performed(InputAction.CallbackContext obj)
        {
            if (_powerManager.CanCastSpell(_power))
            {
                _powerManager.EnterPowerState(_power);
            }
            else
            {
                Debug.LogError("Don't have the Ressources to construct this Entity");
            }
        }
    }
}