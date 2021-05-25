using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public GameObject Camera;

    public float UpSpeed = 15f;
    private float Upvelovity = 0;
    public float Gravity = 5f;
    private int JumpsLeft = 2;

    void Update() {
        Ray ray1 = new Ray(transform.position, Vector3.left);
        RaycastHit rayHit1 = new RaycastHit();
        Ray ray2 = new Ray(transform.position, Vector3.right);
        RaycastHit rayHit2 = new RaycastHit();
        Ray ray3 = new Ray(transform.position, Vector3.up);
        RaycastHit rayHit3 = new RaycastHit();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 2f)
        {
            GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            if (!Physics.Raycast(ray1, out rayHit1, 2f))
            {
                transform.position = transform.position + (Vector3.left * MovementSpeed * Time.deltaTime);
            }   
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x < 124f)
        {
            GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            if (!Physics.Raycast(ray2, out rayHit2, 2f))
            {
                transform.position = transform.position + (Vector3.right * MovementSpeed * Time.deltaTime);
            }  
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (JumpsLeft > 0)
            {
                JumpsLeft--;
                Upvelovity = UpSpeed;
            }      
        }

        if (transform.position.y <= 128f)
        {
            if (Physics.Raycast(ray3, out rayHit3, 2f))
            {
                Upvelovity *= -1f;
            }

            transform.Translate(new Vector3(0f, Upvelovity * Time.deltaTime, 0f));
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit rayHit = new RaycastHit();

        Debug.DrawRay(ray.origin, ray.direction);
        Debug.DrawRay(ray1.origin, ray1.direction);
        Debug.DrawRay(ray2.origin, ray2.direction);
        Debug.DrawRay(ray3.origin, ray3.direction);

        if (Physics.Raycast(ray, out rayHit, 2f))
        {
            JumpsLeft = 2;
            transform.position = rayHit.point + new Vector3(0,2f,0);
            Upvelovity = 0f;
        } else {
            Upvelovity -= Gravity * Time.deltaTime;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,1f,127f), Mathf.Clamp(transform.position.y, 1f, 127f), transform.position.z);

        Camera.transform.position = Vector3.Slerp(Camera.transform.position, transform.position + new Vector3(0,0,-1f), 15f * Time.deltaTime);
    }
}
