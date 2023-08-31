using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public Transform SpawnPoint;
    public Transform rocketSpawnPoint;
    public float bulletSpeed = 10f;
    public float rocketSpeed = 10f;
    public float delay = 3f;
    public float spawnOffset = 0.5f; // Offset distance in front of the player

    public AudioClip fireSound;
    public AudioClip rocketFireSound;
    private AudioSource source;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
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
            Vector3 spawnPosition = SpawnPoint.position + SpawnPoint.up * spawnOffset;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, SpawnPoint.rotation);
            source.PlayOneShot(fireSound);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = SpawnPoint.up * bulletSpeed;
            timer = 0f;
        }
    }

    void ShootingRocket()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPosition = rocketSpawnPoint.position + rocketSpawnPoint.up * spawnOffset;
            GameObject rocket = Instantiate(rocketPrefab, spawnPosition, rocketSpawnPoint.rotation);
            source.PlayOneShot(rocketFireSound);
            Rigidbody2D rocketRigidbody = rocket.GetComponent<Rigidbody2D>();
            rocketRigidbody.velocity = rocketSpawnPoint.up * rocketSpeed;
        }
    }
}
