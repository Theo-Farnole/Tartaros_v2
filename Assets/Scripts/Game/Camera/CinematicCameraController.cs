namespace Tartaros.CameraSystem
{
	using System;
	using TMPro;
	using UnityEngine;

	public class CinematicCameraController : MonoBehaviour
	{
		#region Fields
		[SerializeField] private CameraData _cameraData = null;

		private Transform _destination = null;
		#endregion Fields

		#region Properties
		[ShowInRuntime]
		public Transform Destination { get => _destination; set => _destination = value; }
		#endregion Properties

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
		private void Update()
		{
			if (_destination != null)
			{
				transform.position = Vector3.MoveTowards(transform.position, _destination.position, _cameraData.SpeedEdgePan * Time.deltaTime);

				if (Vector3.Distance(transform.position, _destination.position) < 0.03f)
				{
					DestinationReached?.Invoke(this, new DestinationReachedArgs(_destination.position));
					_destination = null;
				}
			}
		}
		#endregion Methods
	}
}
