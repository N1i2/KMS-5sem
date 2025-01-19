using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material material;
    private void OnCollisionStay(Collision other)
    {
        if (other.body.tag == "ColorCube")
        {
            Debug.Log("Hello");
            other.body.GetComponent<Renderer>().material = material;
        }
    }
    private void OnCollisionExit(Collision other) {
        if (other.body.tag == "ColorCube")
        {
            Debug.Log("Hello");
            other.body.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
        }
    }
}
