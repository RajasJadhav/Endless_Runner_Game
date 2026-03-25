using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();  
    }

    private void FixedUpdate()
    {
        MoveForward();
    }
    private void MoveForward()
    {
        playerRb.AddForce(Vector3.forward * forwardSpeed , ForceMode.Force);
    }

    private void ChangeLane()
    {

    }
}
