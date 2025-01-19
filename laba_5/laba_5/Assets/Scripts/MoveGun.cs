using UnityEngine;

public class MoveGun : MonoBehaviour
{
    private float speedRot = 50f;
    private float xRot;

    public void FixedUpdate()
    {
        float y = -Input.GetAxis("Mouse Y");

        xRot = transform.localEulerAngles.x;

        if(xRot < 355 && xRot > 5){
            if((y > 0 && xRot < 180) || (y < 0 && xRot > 180)){
                return;
            }
        }

        transform.Rotate(y, 0, 0);
    }
}
