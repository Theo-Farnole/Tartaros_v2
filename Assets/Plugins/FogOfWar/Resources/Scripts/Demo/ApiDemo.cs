using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiDemo : MonoBehaviour {

    public int width = 128;
    public int height = 128;

    public GameObject TileA;
    public GameObject TileB;
    public GameObject TileC;
    private List<GameObject> GOList = new List<GameObject>();

    void Start (){
        Color[] c = new Color[width * height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                float value = Mathf.PerlinNoise(x / 20f,z / 20f);
                int coordinate = Mathf.FloorToInt(z) * width + Mathf.FloorToInt(x); ;

                if (value < 0.33f)
                {
                    GOList.Add( Instantiate(TileA, new Vector3(x,0,z)+new Vector3(0.5f,0,0.5f), Quaternion.identity) as GameObject );
                    c[coordinate].g = .0f;
                }

                if (value >= 0.33f && value < 0.66f)
                {
                    GOList.Add(Instantiate(TileB, new Vector3(x, 0, z) + new Vector3(0.5f, 0, 0.5f), Quaternion.identity) as GameObject);
                    c[coordinate].g = 0.5f;
                }

                if (value >= 0.66f)
                {
                    GOList.Add(Instantiate(TileC, new Vector3(x, 0, z) + new Vector3(0.5f, 0, 0.5f), Quaternion.identity) as GameObject);
                    c[coordinate].g = 1.0f;
                }
            }
        }

        GameObject g1 = new GameObject("FogOfWarManager");
        FogOfWarManager manager = g1.AddComponent<FogOfWarManager>();
        manager.LevelWidth = width;
        manager.LevelHeight = height;
        manager.BlurFog = FogOfWar.FogQuality.On;

        manager.SetResistenceMapData(c);
        manager.InitializeMaps();

        GameObject g2 = new GameObject("Projector");
        g2.transform.position = new Vector3(width / 2f, 15f, height/2f);
        g2.transform.rotation = Quaternion.Euler(90f,0f,0f);

        Projector p = g2.AddComponent<Projector>();
        
        Material projectorMat = new Material(Shader.Find("UltimateFogOfWar/Projectors/Projector"));
        p.material = projectorMat;
        p.orthographic = true;
        p.orthographicSize = height / 2f;
        p.aspectRatio = (float)width / (float)height;
        
        GameObject revealer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        revealer.transform.position = new Vector3(width/2f, 1f, height/2f);
        ExampleUnit e = revealer.AddComponent<ExampleUnit>();
        e.VisionRange = 12.75f;
    }
}
