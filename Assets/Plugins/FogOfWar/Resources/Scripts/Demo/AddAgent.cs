using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddAgent : MonoBehaviour {

    public GameObject Agent;
    public int Num = 0;
    public Text text;

    public void AddNewAgent()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject g = Instantiate(Agent, new Vector3(64f+Random.Range(-2f,2f), 11f, 64f + Random.Range(-2f, 2f)), Quaternion.identity);
            g.SetActive(true);
            Num++;
            text.text = "Add Revealer (" + Num.ToString() + ")";
        }
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

}
