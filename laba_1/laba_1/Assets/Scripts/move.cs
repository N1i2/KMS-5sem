using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody rb;
	public float x;
	public float y;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
    }
}
