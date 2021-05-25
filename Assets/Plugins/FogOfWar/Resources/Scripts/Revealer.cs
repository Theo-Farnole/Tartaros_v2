using UnityEngine;
using System.Collections;

[System.Serializable]
public class Revealer
{
    public float VisionRange = 6f;
    public FogOfWar.Players Faction = 0;
    public int UpVision = 0;
    public GameObject RevealerObject;

    public Revealer(float _VisionRange, FogOfWar.Players _Faction, int _UpVision, GameObject _RevealerObject)
    {
        VisionRange = _VisionRange;
        Faction = _Faction;
        UpVision = _UpVision;
        RevealerObject = _RevealerObject;
    }
}
