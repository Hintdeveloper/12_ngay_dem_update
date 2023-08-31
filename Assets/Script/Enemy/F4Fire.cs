using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float delay = 3f;
    public float spawnOffset = 1f;
    private float timer = 0f;

    public AudioClip fireSound;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootingBullet();
    }

    void ShootingBullet()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            Vector3 spawnPosition = bulletSpawnPoint.position + bulletSpawnPoint.up * spawnOffset;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, bulletSpawnPoint.rotation);
            source.PlayOneShot(fireSound);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = -bulletSpawnPoint.up * bulletSpeed;
            timer = 0f;
        }
    }

}
