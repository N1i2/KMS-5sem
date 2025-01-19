using UnityEngine;

public class TrigerTauch : MonoBehaviour
{
    public Light lightObj;
    public Light lightRotate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MyTrg")
        {
            lightObj.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Light")
        {
            lightRotate.transform.Rotate(0, 10f, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MyTrg")
        {
            lightObj.enabled = false;
        }
    }
}
