namespace Tartaros.Construction
{
	using System.Collections;
	using UnityEngine;

	public class ConstructionDelay : MonoBehaviour
	{
		private IConstructable _constructable = null;
		private int _timeToConstruct = 0;
		private float _currentDelay = 0;

		public IConstructable Construcatble { get => _constructable; set => _constructable = value; }
		public int TimeToConstruct => _timeToConstruct;
		public float CurrentDelay => _currentDelay;

		private void Start()
		{
			_timeToConstruct = _constructable.TimeToConstruct;
			StartCoroutine(DelayBeforeConstruction(_timeToConstruct));
		}

		private void Update()
		{
			Delay();
		}

		private void Delay()
		{
			_currentDelay += Time.deltaTime;
		}

		private void InstanciateGameplayPrefab()
		{
			GameObject.Instantiate(_constructable.GameplayPrefab, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}

		IEnumerator DelayBeforeConstruction(float time)
		{
			Debug.Log("startDelay");
			yield return new WaitForSeconds(time);
			InstanciateGameplayPrefab();
		}
	}
}