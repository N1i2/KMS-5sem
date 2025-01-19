using UnityEngine;

public class MoveTank : MonoBehaviour
{
    [SerializeField] private float speed = 1_000_000f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float rotate = 5f;
    private Rigidbody _rb;
    private bool canMove = false;
    private AudioSource audioSource;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float w = Input.GetAxis("Horizontal");

        Vector3 vector3 = transform.up * -v * speed * Time.fixedDeltaTime;

        if (canMove)
        {
            _rb.AddForce(vector3);
        }

        if (IsMove())
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            w = (v > 0) ? w : -w;
            float rotMove = w * rotate * Time.fixedDeltaTime * _rb.velocity.magnitude;
            transform.Rotate(0, 0, rotMove);
        }
        else if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        CheckSpeed();
    }
    private bool IsMove()
    {
        return _rb.velocity.magnitude > 1f;
    }
    private void CheckSpeed()
    {
        if (_rb.velocity.magnitude > maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * maxSpeed;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Finish")
        {
            canMove = true;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Finish")
        {
            if (transform.localEulerAngles.x > 350 || transform.localEulerAngles.x < 190)
            {
                _rb.isKinematic = true;
                transform.position = new Vector3(transform.position.x, 10, transform.position.z);
                transform.rotation = new Quaternion(-90, 0, 0, 90);
                _rb.isKinematic = false;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Finish")
        {
            canMove = false;
        }
    }
}