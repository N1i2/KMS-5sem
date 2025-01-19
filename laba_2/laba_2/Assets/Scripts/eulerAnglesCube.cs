using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x -= h * speed * Time.deltaTime;
        currentRotation.z += v * speed * Time.deltaTime;

        transform.eulerAngles = currentRotation;
    }
}
