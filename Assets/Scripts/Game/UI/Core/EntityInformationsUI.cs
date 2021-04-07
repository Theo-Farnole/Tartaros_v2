namespace Tartaros.UI
{
	using Tartaros.Entities;
	using Tartaros.Entities.Informations;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class EntityInformationsUI : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Entity _entity = null;

		[Space]

		[SerializeField]
		private TextMeshProUGUI _name = null;

		[SerializeField]
		private TextMeshProUGUI _description = null;

		[SerializeField]
		private Image _portrait = null;
		#endregion Fields

		#region Properties
		public Entity Entity
		{
			get => _entity;
			set
			{
				_entity = value;
				UpdateInformations();
			}
		}

		private EntityInformationsData EntityInformation => _entity.EntityData.GetBehaviour<EntityInformationsData>();
		#endregion Properties

		#region Methods
		private void Start()
		{
			UpdateInformations();
		}

		void UpdateInformations()
		{
			if (_entity == null) return;

			if (_name != null && EntityInformation != null)
			{
				_name.text = EntityInformation.Name;
			}

			if (_description != null && EntityInformation != null)
			{
				_description.text = EntityInformation.Description;
			}

			if (_portrait != null && EntityInformation != null)
			{
				_portrait.sprite = _entity.EntityData.Portrait;
			}
		}
		#endregion Methods
	}
}
