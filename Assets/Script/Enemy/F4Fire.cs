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

    bool isShoot = false;
    public float bulletDuration;
    float remainingDuration;

    AudioManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
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
        if (isShoot == false)
        {
            isShoot = true;
            Vector3 spawnPosition = bulletSpawnPoint.position + bulletSpawnPoint.up * spawnOffset;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.Euler(0,0,180));
            manager.PlaySFX(manager.GunFire);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = -bulletSpawnPoint.up * bulletSpeed;
            CoolDown(bulletDuration);
        }
    }

    void CoolDown(float second)
    {
        remainingDuration = second;
        if (isShoot == true)
        {
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        while (remainingDuration >= 0)
        {
            remainingDuration -= 0.1f;
            yield return null;
        }
        EndTimer();
    }
    void EndTimer()
    {
        isShoot = false;
    }


}
