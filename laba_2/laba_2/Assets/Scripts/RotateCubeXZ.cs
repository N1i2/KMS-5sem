using UnityEngine;

public class RotateCubeXZ : MonoBehaviour
{
    [SerializeField]private float speedRot = 200;
    private void FixedUpdate() {
        float rot = Input.GetAxis("Vertical") * speedRot * Time.fixedDeltaTime;


        transform.rotation *= Quaternion.Euler(rot, 0, rot);
    }
}
