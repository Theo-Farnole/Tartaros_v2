using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ForwardToLevelOne : MonoBehaviour
{
    public float WaitTime = 5f;
    public Slider slider;
    float startTime;

    void Start () {
        startTime = Time.time;
        StartCoroutine(LoadScene());
	}
	
	IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene("Level1");
        yield break;
    }

    void Update()
    {
        float Progress = (Time.time - startTime) / WaitTime;
        slider.value = Progress;
    }
}
