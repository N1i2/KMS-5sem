using UnityEngine;

public class RotateTowerBot : MonoBehaviour
{
    public Transform target; 
    public float detectionRadius = 50f; 
    public LayerMask raycastMask; 
    public float focusTime = 5f; 

    private bool isTargetInSight = false;
    [SerializeField]private float focusTimer = 0f;

    public ShotUseBotGune shotUseBotGune;

    void Update()
    {
        if (target == null) {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= detectionRadius)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            directionToTarget.y = 0;

            if (directionToTarget != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1f);
            }

            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, detectionRadius, raycastMask))
            {
                if (hit.transform == target)
                {
                    isTargetInSight = true;
                    focusTimer += Time.deltaTime;

                    if (focusTimer >= focusTime)
                    {
                        ShotBot();
                        focusTimer = 0f; 
                    }
                }
                else
                {
                    isTargetInSight = false;
                    focusTimer = 0f; 
                }
            }
            else
            {
                isTargetInSight = false;
                focusTimer = 0f; 
            }
        }
        else
        {
            isTargetInSight = false;
            focusTimer = 0f; 
        }
    }

    void ShotBot()
    {
        if(shotUseBotGune != null){
            shotUseBotGune.Shoot();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * detectionRadius );
    }
}