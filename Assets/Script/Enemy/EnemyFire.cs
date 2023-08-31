using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public GameObject rocketPrefab;
    public Transform rocketSpawnPoint; 
    public float rocketSpeed = 20f;
    public float bulletSpeed = 10f;
    public float delay = 3f;
    public float rocketDelay = 10f;
    public float spawnOffset = 0.5f;
    private float timer = 0f;

    public AudioClip bulletfireSound;
    public AudioClip rocketfireSound;
    public AudioSource source;
    public AudioSource rocketsource;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootingBullet();
        ShootingRocket();
    }

    void ShootingBullet()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            Vector3 spawnPosition = bulletSpawnPoint.position + bulletSpawnPoint.up * spawnOffset;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, bulletSpawnPoint.rotation);
            source.PlayOneShot(bulletfireSound);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = -bulletSpawnPoint.up * bulletSpeed;
            timer = 0f;
        }
    }

    void ShootingRocket()
    {
        timer += Time.deltaTime;

        if (timer >= rocketDelay)
        {
            Vector3 spawnPosition = rocketSpawnPoint.position + rocketSpawnPoint.up * spawnOffset;
            GameObject rocket = Instantiate(rocketPrefab, spawnPosition, rocketSpawnPoint.rotation);
            rocketsource.PlayOneShot(rocketfireSound);
            Rigidbody2D rocketRigidbody = rocket.GetComponent<Rigidbody2D>();
            rocketRigidbody.velocity = -rocketSpawnPoint.up * rocketSpeed;
            timer = 0f;
        }

    }
}
