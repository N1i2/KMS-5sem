using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShotUseGune : MonoBehaviour
{
    public GameObject projectile;
    public Text text;
    public ParticleSystem smokeEfect;

    private float force = 500f;
    private float cooldown = 5f;
    private float lastShoot;
    private Transform gunEnd;
    private AudioSource audioSource;

    private void Start()
    {
        lastShoot = Time.time - 5;
        gunEnd = GetComponent<Transform>();
        smokeEfect.Stop();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        int nowTime = Convert.ToInt32(cooldown + lastShoot - Time.time);
        if (nowTime <= 0)
        {
            text.text = "Shoot!!!";
        }
        else
        {
            text.text = "Wait " + nowTime + " s";
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= (lastShoot + cooldown))
        {
            Shoot();
            lastShoot = Time.time;
        }
    }
    void Shoot()
    {
        audioSource.Play();
        
        Vector3 vector = new Vector3(0f, -4.2f, -0.2f);
        Vector3 swapPosition = gunEnd.position + gunEnd.TransformDirection(vector);
        swapPosition.y = 4.1f;

        GameObject newProject = Instantiate(projectile, swapPosition, gunEnd.rotation);

        Rigidbody _rb = newProject.GetComponent<Rigidbody>();

        smokeEfect.Play();
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