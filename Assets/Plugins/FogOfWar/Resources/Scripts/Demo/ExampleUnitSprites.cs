using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExampleUnitSprites : MonoBehaviour
{
    private Revealer _Revealer;
    public float VisionRange = 6f;
    public FogOfWar.Players Faction = 0;
    [Range(0, 255)]
    public int UpVision = 0;
    public Image image;
    public GameObject[] Effects;
    public float TurnOffDelay = 0.0f;

    public void Start()
    {
        if(!image)
            image = gameObject.GetComponent<Image>();

        _Revealer = new Revealer(VisionRange,
            Faction,
            UpVision,
            gameObject);

        FogOfWar.RegisterRevealer(_Revealer);

        if (FogOfWar.IsPositionRevealedByFaction(transform.position, FogOfWar.RevealFaction))
        {
            image.enabled = true;
        }
        else {
            image.enabled = false;
        }
    }

    private bool Hide = false;
    private float StartTime = 0;

    void Update()
    {
        if (image.enabled)
        {
            foreach (GameObject g in Effects)
            {
#pragma warning disable 618
                g.GetComponent<ParticleSystem>().enableEmission = true;
            }
        } else {
            foreach (GameObject g in Effects)
            {
                g.GetComponent<ParticleSystem>().enableEmission = false;
#pragma warning restore 618
            }
        }

        if (Hide)
        {
            if (Time.time >= StartTime + TurnOffDelay)
            {
                image.enabled = false;
            }
        }

        _Revealer.VisionRange = VisionRange;

        if (Faction != FogOfWar.RevealFaction)
        {
            if (FogOfWar.IsPositionRevealedByFaction(transform.position, FogOfWar.RevealFaction))
            {
                if (Hide)
                {
                    Hide = false;
                }
                image.enabled = true;

            } else {
                if (!Hide)
                {
                    StartTime = Time.time;
                    Hide = true;
                }
            }
        } else {
            if (!image.enabled)
            {
                image.enabled = true;
            }
        }
    }
    
    public void OnDisable()
    {
        if (_Revealer != null)
            FogOfWar.UnRegisterRevealer(_Revealer);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position + Vector3.up, "Revealer.png", true);
    }
}
