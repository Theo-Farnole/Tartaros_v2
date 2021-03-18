namespace Assets.Scripts.Game.Construction.V2
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.InputSystem;
	using Tartaros.Construction;
	using Sirenix.OdinInspector;

	public class Test_Construction_Building_Input : SerializedMonoBehaviour
	{
		[SerializeField]
		private ConstructionManager _constructionManger = null;
		[SerializeField]
		private GameObject _test = null;
		private IConstructable _constructable = null;
		private GameInputs _input = null;


		private void OnEnable()
		{
			_input = new GameInputs();
			_input.Construction.Enable();



			_constructable = _test.GetComponent<IConstructable>();

			_input.Construction.EnterConstruction.performed -= EnterConstruction_performed;
			_input.Construction.EnterConstruction.performed += EnterConstruction_performed;
		}

		private void OnDisable()
		{
			_input.Construction.EnterConstruction.performed -= EnterConstruction_performed;
		}

		private void EnterConstruction_performed(InputAction.CallbackContext obj)
		{
			if (_constructionManger.CanEnterConstruction(_constructable))
			{
				_constructionManger.EnterConstructionMode(_constructable);
			}
			else
			{
				Debug.LogError("Don't have the Ressources to construct this Entity");
			}
		}


	}
}