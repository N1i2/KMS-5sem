using UnityEngine;

public class ScriptPosition : MonoBehaviour
{
    [SerializeField]private int speed = 5;
    [SerializeField]private float jump = 0.5f;
    private float currentSpeed;
    private float baseSpeed = 5f;
    private float maxSpeed = 10f;
    private float acceleration = 2f;

    private void Start() {
        currentSpeed = baseSpeed;
    }

    private void FixedUpdate() {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float y = 0;

        if(Input.GetKey(KeyCode.Space)){
            y = jump;
        }
        if(Input.GetKey(KeyCode.LeftAlt) ||Input.GetKey(KeyCode.RightAlt) ){
            y = -jump;
        }
        
        Vector3 direction = new Vector3(h, y, v).normalized*Time.fixedDeltaTime * speed;
        
        if (direction.magnitude > 0)
        {
            currentSpeed += acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, baseSpeed, maxSpeed); 
        }
        else
        {
            currentSpeed -= acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, baseSpeed, maxSpeed);
        }

        transform.position += direction;
    }
}
