namespace Tartaros.CameraSystem
{
	using System;
	using TMPro;
	using UnityEngine;

	public class CinematicCameraController : MonoBehaviour
	{
		#region Fields
		[SerializeField] private CameraData _cameraData = null;

		[ShowInRuntime] private Vector3 _destination = default;
		[ShowInRuntime] private bool _moveTo = false;

		private CameraController _cameraController = null;
		#endregion Fields

		#region Events
		public class DestinationReachedArgs : EventArgs
		{
			public readonly Vector3 destination = default;

			public DestinationReachedArgs(Vector3 destination)
			{
				this.destination = destination;
			}
		}

		public event EventHandler<DestinationReachedArgs> DestinationReached = null;
		#endregion Events

		#region Methods
		private void Awake()
		{
			_cameraController = GetComponent<CameraController>();
		}

		private void Update()
		{
			if (_moveTo == true)
			{
				transform.position = Vector3.MoveTowards(transform.position, _destination, _cameraData.SpeedInCinematics * Time.unscaledDeltaTime);

				if (Vector3.Distance(transform.position, _destination) < 0.03f)
				{
					Stop();
					DestinationReached?.Invoke(this, new DestinationReachedArgs(_destination));
				}
			}
		}

		public void Stop()
		{
			if (_cameraController != null)
			{
				_cameraController.enabled = true;
			}

			_moveTo = false;
		}

		public void MoveTo(Vector3 destination)
		{
			// A .___. B
			//	 |  /
			//	 | /
			// C |/			


			float radiansB = transform.eulerAngles.x * Mathf.Deg2Rad;
			float sinRadiansB = Mathf.Sin(radiansB);
			float edgeOpposedToB = Mathf.Abs(transform.position.y - destination.y); // opposé

			// we are looking for this
			// sin = opposed / hypotenuse <=> hyp = opposé / sin
			float hypotenuse = edgeOpposedToB / sinRadiansB;

			_destination = destination + -transform.forward * hypotenuse;
			_moveTo = true;

			if (_cameraController != null)
			{
				_cameraController.enabled = false;
			}
		}
		#endregion Methods
	}
}
