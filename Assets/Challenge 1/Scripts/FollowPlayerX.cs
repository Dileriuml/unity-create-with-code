using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = plane.transform.position;
    }
}