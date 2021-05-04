using UnityEngine;

namespace CTS
{
    /// <summary>
    /// A simple fly script for the demos, provided for convenience to avoid having to import standard assets.
    /// This is based with thanks on the script located here : http://wiki.unity3d.com/index.php/FlyCam_Extended
    /// </summary>
    public class CTSFly : MonoBehaviour
    {
        public float cameraSensitivity = 90f;
        public float climbSpeed = 4f;
        public float normalMoveSpeed = 10f;
        public float fastMoveFactor = 3f;

        void Start()
        {
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                transform.position += transform.forward*(normalMoveSpeed*fastMoveFactor)*Input.GetAxis("Vertical")*
                                      Time.deltaTime;
                transform.position += transform.right*(normalMoveSpeed*fastMoveFactor)*Input.GetAxis("Horizontal")*
                                      Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward*normalMoveSpeed*Input.GetAxis("Vertical")*Time.deltaTime;
                transform.position += transform.right*normalMoveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.E))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    transform.position += transform.up*climbSpeed*fastMoveFactor*Time.deltaTime;
                }
                else
                {
                    transform.position += transform.up*climbSpeed*Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.Q))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    transform.position -= transform.up*climbSpeed*fastMoveFactor*Time.deltaTime;
                }
                else
                {
                    transform.position -= transform.up*climbSpeed*Time.deltaTime;
                }
            }
        }
    }
}