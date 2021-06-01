namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class SectorOutlineData : SerializedScriptableObject
	{
		[OdinSerialize]
		private Color _unCapturedSectorsColor = Color.blue;
		[OdinSerialize]
		private Color _CapturedSectorsColor = Color.green;
		[OdinSerialize]
		private Color _CapturedSelectedSectorsColor = Color.yellow;

		[OdinSerialize]
		private Material _unCapturedSectorsMaterial = null;
		[OdinSerialize]
		private Material _CapturedSectorsMaterial = null;

		public Color UnCapturedSectorsColor => _unCapturedSectorsColor;
		public Color CapturedSectorsColor => _CapturedSectorsColor;
		public Color CapturedSectorSelectedColor => _CapturedSelectedSectorsColor;
		public Material CapturedSectorsMaterial => _CapturedSectorsMaterial;
		public Material UnCapturedSectorsMaterial => _unCapturedSectorsMaterial;
	}

}