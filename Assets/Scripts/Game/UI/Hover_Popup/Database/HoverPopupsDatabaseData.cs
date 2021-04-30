namespace Tartaros.UI.HoverPopup
{
	using System;
	using UnityEngine;

	public class HoverPopupsDatabaseData : ScriptableObject
	{
		[SerializeField] private HoverPopupDataSO _attack = null;
		[SerializeField] private HoverPopupDataSO _closeGate = null;
		[SerializeField] private HoverPopupDataSO _heal = null;
		[SerializeField] private HoverPopupDataSO _move = null;
		[SerializeField] private HoverPopupDataSO _moveAggressively = null;
		[SerializeField] private HoverPopupDataSO _openGate = null;
		[SerializeField] private HoverPopupDataSO _patrol = null;
		[SerializeField] private HoverPopupDataSO _selfKill = null;
		[SerializeField] private HoverPopupDataSO _turnIntoGate = null;

		public HoverPopupData Attack => _attack.HoverPopupData ?? throw HandleNullField(nameof(_attack));
		public HoverPopupData CloseGate => _closeGate.HoverPopupData ?? throw HandleNullField(nameof(_closeGate));
		public HoverPopupData Heal => _heal.HoverPopupData ?? throw HandleNullField(nameof(_heal));
		public HoverPopupData Move => _move.HoverPopupData ?? throw HandleNullField(nameof(_move));
		public HoverPopupData MoveAggressively => _moveAggressively.HoverPopupData ?? throw HandleNullField(nameof(_moveAggressively));
		public HoverPopupData OpenGate => _openGate.HoverPopupData ?? throw HandleNullField(nameof(_openGate));
		public HoverPopupData Patrol => _patrol.HoverPopupData ?? throw HandleNullField(nameof(_patrol));
		public HoverPopupData SelfKill => _selfKill.HoverPopupData ?? throw HandleNullField(nameof(_selfKill));
		public HoverPopupData TurnIntoGate => _turnIntoGate.HoverPopupData ?? throw HandleNullField(nameof(_turnIntoGate));

		private Exception HandleNullField(string fieldName)
		{
			return new MissingFieldException("Please, set a value to the field {0}.".Format(fieldName));
		}
	}
}
