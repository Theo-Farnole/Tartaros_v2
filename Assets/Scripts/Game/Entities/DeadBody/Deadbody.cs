namespace Tartaros.Entities
{
	using DG.Tweening;
	using UnityEngine;

	public class Deadbody : MonoBehaviour
	{
		[SerializeField] private DeadbodyData _data = null;

		private float _currentLifetime = 0;

		public DeadbodyData Data { get => _data; set => _data = value; }

		private void Update()
		{
			_currentLifetime += Time.deltaTime;

			if (_currentLifetime >= _data.Lifetime)
			{
				TranslateIntoGroundThenDestroy();
			}
		}

		private void TranslateIntoGroundThenDestroy()
		{
			transform.DOLocalMoveY(-1.5f, 0.8f)
				.OnComplete(() => Destroy(gameObject));
		}
	}
}
