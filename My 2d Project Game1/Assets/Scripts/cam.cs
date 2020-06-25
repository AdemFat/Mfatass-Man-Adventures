using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 range;
    void Awake()
    {
        range = transform.position - playerTransform.position;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(range.x + playerTransform.position.x, transform.position.y, range.z + playerTransform.position.z);
    }

}
