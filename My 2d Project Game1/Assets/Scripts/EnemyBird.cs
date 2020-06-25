using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBird : MonoBehaviour
{

    public Transform endPoint, beginPoint;
    public float speed;
    public Vector3 localScale;

    public GameObject bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        localScale = transform.localScale;
        InvokeRepeating("Shooting", 3, 1.25f);
    }

    private void Update()
    {
        if (transform.position.x >= beginPoint.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            transform.localScale = new Vector3(-localScale.x, transform.localScale.y, 1);
        }

        if (transform.position.x <= endPoint.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            transform.localScale = new Vector3(localScale.x,transform.localScale.y,1);
        }
    }

    public void Shooting()
    {
        Instantiate(bullet, firePoint.position , Quaternion.identity);
    }

}
