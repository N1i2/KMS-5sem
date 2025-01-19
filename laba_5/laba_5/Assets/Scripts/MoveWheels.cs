using UnityEngine;

public class MoveWheels : MonoBehaviour
{
    private Rigidbody _rb;
    public float yRot;
    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }
    private void Update()
    {
        float run = _rb.velocity.magnitude;
        float y = Input.GetAxis("Horizontal");
        yRot = transform.localEulerAngles.z;

        if (Input.GetAxis("Vertical") < 0)
        {
            run *= -1;
        }
        transform.Rotate(run, 0, 0);
    }
}
