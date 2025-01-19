using UnityEngine;

public class TrigerBackObj : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        other.transform.position = new Vector3(0, 10,0);
    }
}
