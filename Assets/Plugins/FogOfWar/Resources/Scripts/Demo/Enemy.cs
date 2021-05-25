using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float Speed = 5f;
    public Vector3 Direction = Vector3.left;

	void Update () {
        if (Direction == Vector3.left)
        {
            Ray ray = new Ray(transform.position, new Vector3(-1f,-1f,0f));
            RaycastHit rayHit = new RaycastHit();

            if (!Physics.Raycast(ray, out rayHit, 5f))
            {
                GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
                Direction = Vector3.right;
            }

            Debug.DrawRay(ray.origin, ray.direction*5f, Color.red);
            ray = new Ray(transform.position, Vector3.left);
            rayHit = new RaycastHit();
            Debug.DrawRay(ray.origin, ray.direction, Color.green);

            if (Physics.Raycast(ray, out rayHit, 2f))
            {
                GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                Direction = Vector3.right;
            }
        }

        if (Direction == Vector3.right)
        {
            Ray ray = new Ray(transform.position, new Vector3(1f, -1f, 0f));
            RaycastHit rayHit = new RaycastHit();

            if (!Physics.Raycast(ray, out rayHit, 5f))
            {
                GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                Direction = Vector3.left;
            }

            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red);
            ray = new Ray(transform.position, Vector3.right);
            rayHit = new RaycastHit();
            Debug.DrawRay(ray.origin, ray.direction, Color.green);

            if (Physics.Raycast(ray, out rayHit, 2f))
            {
                GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                Direction = Vector3.left;
            }
        }

        transform.position = transform.position + (Direction * Time.deltaTime * Speed);
    }
}
