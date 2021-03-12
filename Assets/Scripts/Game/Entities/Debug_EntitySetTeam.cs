namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using UnityEngine;


	public class Debug_EntitySetTeam : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self is null")]
		private Entity _entity = null;

		[SerializeField]
		private Team _teamSetOnStart = Team.Player;
		#endregion Fields

		#region Methods
		void Awake()
		{
			if (_entity == null)
			{
				_entity = GetComponent<Entity>();
			}
		}

		void Start()
		{
			_entity.Initialize(_teamSetOnStart, _entity.EntityType);
		}
		#endregion Methods
	}
}
