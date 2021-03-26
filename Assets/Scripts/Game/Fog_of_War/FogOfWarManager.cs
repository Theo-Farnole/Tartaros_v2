namespace Tartaros.FogOfWar
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Math;
	using Tartaros.Sectors;
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	public class FogOfWarManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private FogOfWarData _data = null;

		[ShowInRuntime]
		private List<IFogVision> _visions = new List<IFogVision>();

		[ShowInRuntime]
		private List<IFogCoverable> _coverables = new List<IFogCoverable>();
		#endregion Fields

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		private void Update()
		{
			UpdateCoverablesVisibility();
		}

		public void AddVision(IFogVision vision)
		{
			if (_visions.Contains(vision) == true)
			{
				Debug.LogErrorFormat("Cannot add fog vision {0}. It is already in visions list.", vision.ToString());
				return;
			}

			_visions.Add(vision);
		}

		public void RemoveVision(IFogVision vision)
		{
			if (_visions.Contains(vision) == false)
			{
				Debug.LogErrorFormat("Cannot remove fog vision {0}. It is not in visions list.", vision.ToString());
				return;
			}

			_visions.Remove(vision);
		}

		public void AddCoverable(IFogCoverable coverable)
		{
			if (_coverables.Contains(coverable) == true)
			{
				Debug.LogErrorFormat("Cannot add fog coverable {0}. It is already in coverables list.", coverable.ToString());
				return;
			}

			_coverables.Add(coverable);
		}

		public void RemoveCoverable(IFogCoverable coverable)
		{
			if (_coverables.Contains(coverable) == false)
			{
				Debug.LogErrorFormat("Cannot remove fog coverable {0}. It is not in coverables list.", coverable.ToString());
				return;
			}

			_coverables.Remove(coverable);
		}

		private void UpdateCoverablesVisibility()
		{
			IShape[] visions = _visions.Select(x => x.VisionShape).ToArray();

			foreach (IFogCoverable coverable in _coverables)
			{
				IShape coverableShape = coverable.ModelBounds;

				bool isVisible = CollisionOverlapCalculator.DoOverlap(coverableShape, visions);
				coverable.IsCovered = !isVisible;

				Debug.LogFormat("Coverable {0} is {1}.", coverable.ToString(), isVisible ? "visible" : "not visible");
			}
		}
		#endregion Methods
	}
}
