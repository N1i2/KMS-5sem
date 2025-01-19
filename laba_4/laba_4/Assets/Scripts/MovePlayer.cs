using JetBrains.Annotations;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float speed = 2f;
    private float rotate = 20f;

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float w = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * rotate;

        Vector3 vector = new Vector3(h, 0, v).normalized * Time.fixedDeltaTime * speed;
        transform.position += transform.TransformDirection(vector);
        transform.Rotate(0, w, 0);
    }
}
