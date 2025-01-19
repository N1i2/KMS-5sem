using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHp : MonoBehaviour
{
    public int MyHp = 3;
    public ParticleSystem BrokeSmoke;

    private bool isInvulnerable = false; 
    private float invulnerabilityDuration = 3f; 
    private float lastHitTime; 

    private void Start()
    {
        BrokeSmoke.Stop();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && MyHp > 0 && !isInvulnerable)
        {
            MyHp--;

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
