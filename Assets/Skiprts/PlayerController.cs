using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField]
    private GameObject centerOfMass;

    [SerializeField]
    private float horsePower = 50f;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = HorizontalInput();
        verticalInput = VerticalInput();
        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }

    float HorizontalInput()
    {
        return gameObject.name == "Player1" ?
            Input.GetAxis("Horizontal_P1") : Input.GetAxis("Horizontal_P2");
    }

    float VerticalInput()
    {
        return gameObject.name == "Player1" ?
            Input.GetAxis("Vertical_P1") : Input.GetAxis("Vertical_P2");
    }
}
