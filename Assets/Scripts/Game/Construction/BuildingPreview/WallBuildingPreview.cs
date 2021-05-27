namespace Tartaros.Construction
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.AI;

	public class WallBuildingPreview
	{
		private GameObject _buildingPreview = null;
		private GameObject _startBuildingPreview = null;
		private CheckObjectUnderCursorManager _objectUnderCursorManager = null;
		private GameObject _wallCantConstruct = null;
		private bool _canConstruct = true;
		private List<MeshRenderer> _meshRenderers = new List<MeshRenderer>();

		private List<GameObject> _buildingsPreview = new List<GameObject>();
		private Vector3 _startPosition = Vector3.zero;
		private IConstructable _toBuild = null;
		private Vector2[] _pointsToCheck = null;

		private float _angleLimitation = 4;

		public float DistanceBetweenInstanciate => _toBuild.Size.x;

		public WallBuildingPreview(IConstructable toBuild, Vector3 startPosition, GameObject startPreview)
		{

			_toBuild = toBuild;
			_buildingPreview = toBuild.PreviewPrefab;
			_startBuildingPreview = startPreview;
			_startPosition = startPosition;

			SetUp();
		}

		private void SetUp()
		{
			if (_toBuild.PreviewPrefab == null || _toBuild.WallCornerModel == null)
			{
				Debug.LogError("there is no prefab on the dataBase");
			}
			_objectUnderCursorManager = new CheckObjectUnderCursorManager(_toBuild);
			InstanciatePreviewStart(_startPosition);
			_pointsToCheck = GetPointToCheckTheConstructionViability();
		}

		public void Update(Vector3 end)
		{
			Vector3 rawDirection = (_startPosition - end);
			Vector3 realDirection = MathHelper.SnapXZToAxis(rawDirection, _angleLimitation);
			end = _startPosition + rawDirection.magnitude * realDirection.normalized;

			int numberOfWallSection = CalculateNumberOfWallSections(end);

			if (numberOfWallSection > _buildingsPreview.Count)
			{
				Vector3 position = _startPosition + (realDirection * ((DistanceBetweenInstanciate) * _buildingsPreview.Count));

				InstanciatePreviewWallSection(position);
			}
			else if (numberOfWallSection < _buildingsPreview.Count)
			{
				RemovePreviewWall();
			}

			SetPositionRotationOfPreviews(end);

			if (_wallCantConstruct == null)
			{
				_canConstruct = true;
			}
		}

		private int CalculateNumberOfWallSections(Vector3 end)
		{
			return Mathf.RoundToInt(CalculateDistanceFromStartToPosition(end) / _toBuild.Size.x);
		}

		private void InstanciatePreviewWallSection(Vector3 position)
		{
			GameObject wallInstance = GameObject.Instantiate(_buildingPreview, position, Quaternion.identity);
			AddPreviewWall(wallInstance);
			AddMeshRenderer(wallInstance.GetComponentInChildren<MeshRenderer>());

			if (_wallCantConstruct == null && IsValidPositionToBuild(wallInstance.transform.position) == false)
			{
				_wallCantConstruct = wallInstance;
				_canConstruct = false;
			}
		}

		private void InstanciatePreviewStart(Vector3 position)
		{
			GameObject wallInstance = GameObject.Instantiate(_startBuildingPreview, position, Quaternion.identity);
			AddPreviewWall(wallInstance);
			AddMeshRenderer(wallInstance.GetComponentInChildren<MeshRenderer>());
		}

		private void SetPositionRotationOfPreviews(Vector3 end)
		{
			SetRotationOfPreview(end);
			SetPositionOfPreview(end);
		}

		private void SetRotationOfPreview(Vector3 end)
		{
			foreach (GameObject wallSection in _buildingsPreview)
			{
				wallSection.transform.LookAt(end);
			}
		}

		private void SetPositionOfPreview(Vector3 end)
		{
			float sectionLength = Vector3.Distance(_startPosition, end);
			float sectionPercent = _toBuild.Size.x / sectionLength;

			for (int i = 0; i < _buildingsPreview.Count; i++)
			{
				GameObject wallSection = _buildingsPreview[i];
				float interpolation = sectionPercent * i;
				wallSection.transform.position = Vector3.Lerp(_startPosition, end, interpolation);
			}
		}

		private float CalculateDistanceFromStartToPosition(Vector3 position)
		{
			return Vector3.Distance(_startPosition, position);
		}

		public List<GameObject> GetWallBuildingPreview()
		{
			return _buildingsPreview;
		}

		private void AddPreviewWall(GameObject previewToInstanciate)
		{
			_buildingsPreview.Add(previewToInstanciate);
		}

		private void RemovePreviewWall()
		{
			if (_buildingsPreview.Count - 1 > 0)
			{
				RemoveMeshRenderer(_buildingsPreview[_buildingsPreview.Count - 1].GetComponentInChildren<MeshRenderer>());

				GameObject.Destroy(_buildingsPreview[_buildingsPreview.Count - 1]);
				_buildingsPreview.RemoveAt(_buildingsPreview.Count - 1);
			}
		}

		public List<GameObject> GetAllSectionPreview()
		{
			List<GameObject> wallSection = new List<GameObject>(_buildingsPreview);
			int lastIndex = _buildingsPreview.Count - 1;
			wallSection.RemoveAt(lastIndex);
			wallSection.RemoveAt(0);

			return wallSection;
		}

		public List<GameObject> GetAllCornerPreview()
		{
			List<GameObject> wallCorner = new List<GameObject>();
			int lastIndex = _buildingsPreview.Count - 1;

			wallCorner.Add(_buildingsPreview[0]);
			wallCorner.Add(_buildingsPreview[lastIndex]);


			return wallCorner;
		}

		public bool CanConstructHere()
		{
			return _canConstruct;
		}

		private bool IsValidPositionToBuild(Vector3 wallPreview)
		{
			foreach (Vector2 position in _pointsToCheck)
			{
				float buildingPosX = wallPreview.x - _toBuild.Size.x / 2;
				float buildingPosZ = wallPreview.z - _toBuild.Size.y / 2;
				Vector3 positionV3 = new Vector3(position.x + buildingPosX, 1, position.y + buildingPosZ);


				RaycastHit hit;

				if (Physics.Raycast(positionV3, Vector3.down, out hit, Mathf.Infinity, NavMesh.AllAreas))
				{
					Debug.DrawRay(positionV3, Vector3.down * 10, Color.yellow, 3);
					if (NavMeshHelper.IsPositionOnNavMesh(hit.point) == false)
					{
						Debug.DrawRay(positionV3, Vector3.down * 10, Color.green, 3);

						if (_objectUnderCursorManager.IsTheSameConstructable() == false)
						{
							return false;
						}
					}
				}
				else
				{
					return false;
				}
			}
			return true;
		}

		private Vector2[] GetPointToCheckTheConstructionViability()
		{
			float previewWidght = _toBuild.Size.x - 1f;
			float previewLenght = _toBuild.Size.y - 1f;
			List<Vector2> output = new List<Vector2>();

			//center
			output.Add(new Vector2(previewWidght / 2, previewLenght / 2));
			//bottomLeft
			output.Add(Vector2.zero);
			//topRight
			output.Add(new Vector2(previewWidght, previewLenght));
			//bottomRight
			output.Add(new Vector2(previewWidght, 0));
			//topLeft
			output.Add(new Vector2(0, previewLenght));
			//centerLeft
			output.Add(new Vector2(0, previewLenght / 2));
			//centerUp
			output.Add(new Vector2(previewWidght / 2, previewLenght));
			//centerRight
			output.Add(new Vector2(previewWidght, previewLenght / 2));
			//centerBottom
			output.Add(new Vector2(previewWidght / 2, 0));

			return output.ToArray();
		}
		

		public MeshRenderer[] GetMeshRenderes()
		{
			return _meshRenderers.ToArray();
		}

		private void AddMeshRenderer(MeshRenderer mesh)
		{
			_meshRenderers.Add(mesh);
		}

		private void RemoveMeshRenderer(MeshRenderer mesh)
		{
			_meshRenderers.Remove(mesh);
		}


		public void DestroyMethod()
		{
			foreach (GameObject wallSection in _buildingsPreview)
			{
				GameObject.Destroy(wallSection);
			}
		}
	}
}