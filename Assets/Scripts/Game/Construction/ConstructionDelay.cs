namespace Tartaros.Construction
{
	using System.Collections;
	using UnityEngine;

	public class ConstructionDelay : MonoBehaviour
	{
		private IConstructable _constructable = null;
		private int _timeToConstruct = 0;

		public IConstructable Construcatble { get => _constructable; set => _constructable = value; }

		private void Start()
		{
			_timeToConstruct = _constructable.TimeToConstruct;
			StartCoroutine(DelayBeforeConstruction(_timeToConstruct));
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