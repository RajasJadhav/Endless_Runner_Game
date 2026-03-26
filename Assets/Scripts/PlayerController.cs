using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 3f;
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveSpeed = 3f;

    private float currentLane = 0f;

    private Rigidbody playerRb;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private float elapsedTime;
    private bool isMoving = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();  
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void Update()
    {
        ChangeLane();

        if(isMoving)
        {
            MoveTo();
        }
    }
    private void MoveForward()
    {
        playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x,playerRb.linearVelocity.y,forwardSpeed);
    }
    private void ChangeLane()
    {
        if(Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            if(currentLane > -1)
            {
                currentLane--;

                startPosition = transform.position;
                endPosition = startPosition + (Vector3.left * moveDistance);

                elapsedTime = 0f;
                isMoving = true;
            }
            
        }
        else if(Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            if (currentLane < 1)
            {
                currentLane++;

                startPosition = transform.position;
                endPosition = startPosition + (Vector3.right * moveDistance);

                elapsedTime = 0;
                isMoving = true;
            }
        }
    }

    private void MoveTo()
    {
        elapsedTime += Time.deltaTime;
        
        float distance = Vector3.Distance(startPosition, endPosition);
        float journey = elapsedTime * moveSpeed;

        float t = journey / distance;

        Vector3 newPosition = Vector3.Lerp(startPosition, endPosition, t);
        playerRb.MovePosition(newPosition);

        if(t >= 1f)
        {
            playerRb.MovePosition(endPosition);
            isMoving = false;   
        }
    }
}
