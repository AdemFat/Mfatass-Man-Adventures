using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Transform endPoint, beginPoint;
    public float speed;
    public Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= beginPoint.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }

        if (transform.position.x <= endPoint.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
    }
}
