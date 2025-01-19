using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShotUseBotGune : MonoBehaviour
{
    public GameObject projectile;
    public ParticleSystem smokeEffect;

    private float force = 500f;
    private Transform gunEnd;
    private AudioSource audioSource;

    private void Start()
    {
        gunEnd = GetComponent<Transform>();
        smokeEffect.Stop();
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        audioSource.Play();

        Vector3 vector = new Vector3(0f, -4.2f, -0.2f);
        Vector3 swapPosition = gunEnd.position + gunEnd.TransformDirection(vector);
        swapPosition.y = 4.1f;

        GameObject newProject = Instantiate(projectile, swapPosition, gunEnd.rotation);

        Rigidbody _rb = newProject.GetComponent<Rigidbody>();

        smokeEffect.Play();
        StartCoroutine(MoveProjectile(_rb));
    }
    
    IEnumerator MoveProjectile(Rigidbody rb)
    {
        float moveDuration = 10f;
        float elapsedTime = 0f;
        Vector3 startPosition = rb.position;
        Vector3 endPosition = startPosition + gunEnd.TransformDirection(Vector3.up) * -force;

        while (elapsedTime < moveDuration)
        {
            rb.MovePosition(Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(rb.gameObject);
    }
}