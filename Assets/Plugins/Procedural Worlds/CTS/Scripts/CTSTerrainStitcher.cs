using UnityEngine;

namespace CTS
{
    /// <summary>
    /// Class to stitch terrain tiles. Add to 1 tile in the scene.
    /// </summary>
    [ExecuteInEditMode]
    public class CTSTerrainStitcher : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            CTSTerrainManager.Instance.RemoveWorldSeams();
        }
    }
}

