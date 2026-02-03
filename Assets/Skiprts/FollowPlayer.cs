using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private readonly Dictionary<CameraMode, (Vector3 rotation, Vector3 offset)> cameraModes = new()
    {
        { CameraMode.Default3rd, ( new Vector3(27, 0, 0), new Vector3(0, 5, -7)) },
        { CameraMode.Far3rd, ( new Vector3(27, 0, 0), new Vector3(0, 7.5f, -13)) },
        { CameraMode.OverheadView, ( new Vector3(90, 0, 0), new Vector3(0, 30, 0)) },
        { CameraMode.SideView, ( new Vector3(40, 90, 0), new Vector3(-10, 9, 0)) },
        { CameraMode.FirstPerson, ( new Vector3(0, 0, 0), new Vector3(0, 2.4f, 3)) }
    };

    private CameraMode selectedCameraMode = CameraMode.Default3rd;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchCamera();
            transform.rotation = Quaternion.Euler(cameraModes[selectedCameraMode].rotation);
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + cameraModes[selectedCameraMode].offset;
    }

    private void SwitchCamera()
    {
        selectedCameraMode = (CameraMode)(((int)selectedCameraMode + 1) % cameraModes.Count);
    }
}

public enum CameraMode
{
    Default3rd = 0,
    Far3rd,
    FirstPerson,
    SideView,
    OverheadView
}
