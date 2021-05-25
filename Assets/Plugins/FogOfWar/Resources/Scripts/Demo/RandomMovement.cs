using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_5_5_OR_NEWER
using UnityEngine.AI;
#endif

public class RandomMovement : MonoBehaviour {
    public NavMeshAgent Agent;
    public float LevelWidth = 128f;
    public float LevelHeight = 128f;

    void Start()
    {
        NavMeshHit nHit = new NavMeshHit();
        Vector3 pos = new Vector3(Random.Range(0, 128), 10f, Random.Range(0, 128));

        if (NavMesh.SamplePosition(pos, out nHit, 150f, 1))
        {
            Agent.SetDestination(nHit.position);
        }
    }
}
