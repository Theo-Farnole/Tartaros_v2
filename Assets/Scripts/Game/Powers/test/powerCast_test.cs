namespace Tartaros.Powers
{
	using Sirenix.OdinInspector;
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
            throw new System.NotImplementedException();
            //if (_powerManager.CanCastSpell(_power))
            //{
            //    _powerManager.Cast(_power);
            //}
            //else
            //{
            //    Debug.LogError("Don't have the Ressources to construct this Entity");
            //}
        }
    }
}