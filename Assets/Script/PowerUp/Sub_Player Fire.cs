using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Sub_PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform SpawnPoint;
    public float bulletSpeed = 10f;
    public float delay = 3f;
    public float spawnOffset = 0.5f; // Offset distance in front of the player

    private float timer = 0f;

    public AudioClip fireSound;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootingBullet();
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

}
