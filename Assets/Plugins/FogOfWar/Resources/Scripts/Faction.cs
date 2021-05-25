using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Faction
{
    public int ID;
    public FogOfWar.Players RevealFactions;

    public bool UpdateInBackground = true;

    public Color[] FogOfWarMapData;
    public Color[] FogOfWarMapDataBuffer;

    public Texture2D FogTexture;
    public RenderTexture BluredRenderTexture;

    public Faction(int size, int id)
    {
        ID = Mathf.FloorToInt(Mathf.Pow(2, id));
        RevealFactions = (FogOfWar.Players)ID;

        FogOfWarMapData = new Color[size];
        FogOfWarMapDataBuffer = new Color[size];
    }
}
