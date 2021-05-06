namespace Tartaros.UI.MiniMap
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SectorsMiniMapDisplay : MonoBehaviour
	{
		private class SectorDrawMiniMap
		{
			public Sector _sector = null;
			public DrawLineUI _line = null;

			public SectorDrawMiniMap(Sector sector, DrawLineUI line)
			{
				_sector = sector;
				_line = line;
			}
		}
		[SerializeField]
		private SectorOutlineData _outlineData = null;
		[SerializeField]
		private GameObject _miniMapBackground = null;
		[SerializeField]
		private GameObject _drawLinePrefab = null;
		[SerializeField]
		private MiniMap _miniMap = null;


		private List<SectorDrawMiniMap> _sectorsLines = new List<SectorDrawMiniMap>();
		private IMap _map = null;

		//TODO DJ: Avoid this 
		private IMap Map
		{
			get
			{
				if (_map == null)
				{
					_map = Services.Instance.Get<IMap>();
				}

				return _map;
			}
		}



		public RectTransform RootTransform => _miniMap.RootTransform;

		private void Awake()
		{
			_map = Services.Instance.Get<IMap>();
		}

		public void DisplaySectors()
		{
			Sector[] sectors = Map.Sectors.OfType<Sector>().ToArray();

			if (sectors == null)
			{
				Debug.LogError("There is no ref of sectors on the scene");
				return;
			}

			foreach (var sector in sectors)
			{
				GameObject sectorDisplay = GameObject.Instantiate(_drawLinePrefab, _miniMapBackground.transform);
				DrawLineUI drawLineUI = sectorDisplay.GetComponent<DrawLineUI>();

				List<Vector2> listOfVertice = GetVectorOnUI(sector.ConvexPolygon.vertices);
				listOfVertice.Add(listOfVertice.ToArray()[0]);

				drawLineUI.Setup(
					Mathf.RoundToInt(RootTransform.rect.width),
					Mathf.RoundToInt(RootTransform.rect.height));

				SetOutline(drawLineUI);

				drawLineUI.SetNavigationPoints(listOfVertice);

				_sectorsLines.Add(new SectorDrawMiniMap(sector, drawLineUI));
				sector.Captured -= SectorCaptured;
				sector.Captured += SectorCaptured;
			}
		}

		private void SetOutline(DrawLineUI drawLineUI)
		{
			if (_outlineData != null)
			{
				if (_outlineData.UnCapturedSectorsMaterial != null)
				{
					drawLineUI.SetMaterial(_outlineData.UnCapturedSectorsMaterial);
				}
				else
				{
					drawLineUI.SetColor(_outlineData.UnCapturedSectorsColor);
				}
			}
			else
			{
				Debug.LogWarningFormat("There is no SectorOutlineData in {0}", this);
			}
		}

		private void SectorCaptured(object sender, CapturedArgs e)
		{
			foreach (var sectorLines in _sectorsLines)
			{
				if (Equals(sender, sectorLines._sector))
				{
					if (_outlineData != null)
					{
						if (_outlineData.CapturedSectorsMaterial != null)
						{
							sectorLines._line.SetMaterial(_outlineData.CapturedSectorsMaterial);
						}
						else
						{
							sectorLines._line.SetColor(_outlineData.CapturedSectorsColor);
						}
					}
					else
					{
						Debug.LogWarningFormat("There is no SectorOutlineData in {0}", this);
					}
					sectorLines._sector.Captured -= SectorCaptured;
					_sectorsLines.Remove(sectorLines);
					return;
				}
			}
		}

		private List<Vector2> GetVectorOnUI(List<Vector2> vertices)
		{
			List<Vector2> list = new List<Vector2>();
			foreach (Vector2 vertice in vertices)
			{
				list.Add(_miniMap.WordToUiPosition(vertice));
			}
			return list;
		}
	}
}