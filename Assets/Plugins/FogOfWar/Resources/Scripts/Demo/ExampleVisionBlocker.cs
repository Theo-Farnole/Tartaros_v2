using UnityEngine;
using System.Collections;

public class ExampleVisionBlocker : MonoBehaviour
{
    public FogOfWar.Players Faction = 0;
    public MeshRenderer meshRenderer;
    public float TurnOffDelay = 0.0f;

    public void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        FogOfWar.RegisterVisionBlocker(gameObject);

        if (FogOfWar.IsPositionRevealedByFaction(transform.position, FogOfWar.RevealFaction))
        {
            meshRenderer.enabled = true;
        }
        else {
            meshRenderer.enabled = false;
        }
    }

    private bool Hide = false;
    private float StartTime = 0;

    void Update()
    {
        if (Hide)
        {
            if (Time.time >= StartTime + TurnOffDelay)
                meshRenderer.enabled = false;
        }

        if (Faction != FogOfWar.RevealFaction)
        {
            if (FogOfWar.IsPositionRevealedByFaction(transform.position, FogOfWar.RevealFaction))
            {
                if (Hide)
                {
                    Hide = false;
                }
                meshRenderer.enabled = true;

            }
            else {
                if (!Hide)
                {
                    StartTime = Time.time;
                    Hide = true;
                }
            }
        }
        else {
            if (!meshRenderer.enabled)
            {
                meshRenderer.enabled = true;
            }
        }
    }

    public void OnDisable()
    {
        FogOfWar.UnRegisterVisionBlocker(gameObject);
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position + Vector3.up, "Blocker.png", true);
    }
#endif
}
