using UnityEngine;

public class MoveGetAxis : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float RotationX = 90f;  

    private float currentRotationX = 0f;

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float t = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
        float r = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;

        Vector3 localMove = new Vector3(h, 0, v).normalized * speed * Time.fixedDeltaTime;

        transform.position += transform.TransformDirection(localMove);

        currentRotationX -= t; 
        currentRotationX = Mathf.Clamp(currentRotationX, -RotationX, RotationX); 

        transform.localRotation = Quaternion.Euler(currentRotationX, transform.localEulerAngles.y + r, 0);
    }
}
