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

			if (_name != null)
			{
				_name.text = EntityInformation != null ? EntityInformation.Name : "NONE";

			}

			if (_description != null)
			{
				_description.text = EntityInformation != null ? EntityInformation.Description : "NONE";
			}

			if (_portrait != null)
			{
				_portrait.sprite = EntityInformation != null ? _entity.EntityData.Portrait : null;
			}
		}
		#endregion Methods
	}
}
