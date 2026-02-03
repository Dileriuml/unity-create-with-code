using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public GameObject RespawnCollisionObject;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == RespawnCollisionObject.name)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
}
