using UnityEngine;

public class MoveBotCar : MonoBehaviour
{
    public Transform cube1; 
    public float detectionRadius = 50f; 
    public float moveSpeed = 10f; 
    public float rotationSpeed = 30f; 

    void Update()
    {
        Vector3 directionToCube1 = cube1.position - transform.position;
        float distanceToCube1 = directionToCube1.magnitude;

        if (distanceToCube1 <= detectionRadius)
        {
            Vector3 localDirection = transform.InverseTransformDirection(directionToCube1.normalized);

            if (localDirection.y < 0 && localDirection.x > 0)
            {
                Move(-1, 1); 
            }
            else if (localDirection.y < 0 && localDirection.x < 0)
            {
                Move(-1, -1); 
            }
            else if (localDirection.y > 0 && localDirection.x > 0)
            {
                Move(1, 1); 
            }
            else if (localDirection.y > 0 && localDirection.x < 0)
            {
                Move(1, -1); 
            }
        }
    }

    private void Move(float vertical, float horizontal)
    {
        Vector3 moveDirection = new Vector3(0, vertical, 0).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);

        if (horizontal != 0)
        {
            float rotationAmount = horizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationAmount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
