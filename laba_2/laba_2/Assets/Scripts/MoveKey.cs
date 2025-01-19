using UnityEngine;

public class MoveKey : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float step = 1f;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;
    [SerializeField] private float z = 0;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            x = step;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -step;
        }
        if (Input.GetKey(KeyCode.W))
        {
            y = step;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y = -step;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            z = step;
        }
        if (Input.GetKey(KeyCode.E))
        {
            z = -step;
        }

        Vector3 dis = new Vector3(x, y, z).normalized * speed * Time.fixedDeltaTime;

        transform.position += dis;
        EmptyCord();
    }

    private void EmptyCord(){
        x = 0;
        y = 0;
        z = 0;
    }
}
