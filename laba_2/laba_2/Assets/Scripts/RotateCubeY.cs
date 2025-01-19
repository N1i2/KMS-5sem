using UnityEngine;
using UnityEngine.UIElements;

public class RotateCubeY : MonoBehaviour
{
    [SerializeField]private float speedRot = 200;
    private void FixedUpdate() {
        float rot = Input.GetAxis("Horizontal");

        transform.rotation *= Quaternion.Euler(0, -rot * speedRot * Time.fixedDeltaTime, 0);
    }
}
