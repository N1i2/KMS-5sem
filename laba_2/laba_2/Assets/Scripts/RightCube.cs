using UnityEngine;

public class RightCube : MonoBehaviour
{
    [SerializeField] private float speed = 200;
    private Quaternion quaternion;
    private float grad;

    private void Start()
    {
        quaternion = transform.rotation;
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;

        transform.rotation *= Quaternion.Euler(-h, 0, v);
    }
}
