using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayTop : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
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
}
