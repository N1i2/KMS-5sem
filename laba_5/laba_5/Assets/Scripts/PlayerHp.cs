using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int MyHp = 3;
    public ParticleSystem BrokeSmoke;
    public Text text;
    

    private bool isInvulnerable = false; 
    private float invulnerabilityDuration = 3f; 
    
    private void Start()
    {
        text.text = "\tHp: " + MyHp;
        BrokeSmoke.Stop();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BulletBot" && MyHp > 0 && !isInvulnerable)
        {
            MyHp--;

            text.text = "\tHp: " + MyHp;

            if (MyHp <= 0)
            {
                DisableObject();
            }
            else
            {
                StartCoroutine(ActivateInvulnerability());
            }
        }
    }

    void DisableObject()
    {
        foreach (var component in GetComponents<MonoBehaviour>())
        {
            component.enabled = false;
        }

        foreach (Transform child in transform)
        {
            foreach (var component in child.GetComponentsInChildren<MonoBehaviour>())
            {
                component.enabled = false;
            }
        }

        BrokeSmoke.Play();
    }

    private IEnumerator ActivateInvulnerability()
    {
        isInvulnerable = true; 
        yield return new WaitForSeconds(invulnerabilityDuration); 
        isInvulnerable = false; 
    }
}
