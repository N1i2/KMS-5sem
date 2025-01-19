using UnityEngine;

public class MoveHead : MonoBehaviour
{
    private float speedRot = 60f;
    private float zRot;

    private void FixedUpdate()
    {
        float r = Input.GetAxis("Mouse X");
        zRot = transform.localEulerAngles.z;
        
        if(zRot >= 150 && zRot <= 210){
            if((r > 0 && zRot < 180) || (r < 0 && zRot > 180)){
                return;
            }
        }

        Vector3 vector = new Vector3(0, 0, r) * speedRot * Time.fixedDeltaTime;
        transform.Rotate(vector);
    }
}
