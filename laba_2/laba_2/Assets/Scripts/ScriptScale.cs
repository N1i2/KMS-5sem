using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private float minimal = 0.9896158f;
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (transform.localScale.x < minimal)
        {
            transform.localScale = new Vector3(1, transform.localScale.y,  transform.localScale.z);
        }
        else if (transform.localScale.y < minimal)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1,  transform.localScale.z);
        }
        else{
            transform.localScale += new Vector3(x, y, 0) * speed * Time.fixedDeltaTime;
        }
    }
}