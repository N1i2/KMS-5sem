using Unity.VisualScripting;
using UnityEngine;

public class ShootGoal : MonoBehaviour
{
    public GameObject exp1;

    private Renderer thisObj;
    private bool have = true;
    private AudioSource audioSource;

    private void Start()
    {
        thisObj = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "goal")
        {
            if (have)
            {
                audioSource.Play();
                thisObj.enabled = false;
                GameObject effect = Instantiate(exp1, other.contacts[0].point, Quaternion.Euler(180, 0, 180));
                have = false;
                Destroy(effect, 3f);
            }
        }
    }
}