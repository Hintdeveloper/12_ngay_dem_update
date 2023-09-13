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

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PauseBehavior.isPaused)
        {
            ShootingBullet();
        }
    }

    void ShootingBullet()
    {
        if (isShoot == false)
        {
            isShoot = true;
            Vector3 spawnPosition = bulletSpawnPoint.position + bulletSpawnPoint.up * spawnOffset;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.Euler(0, 0, 180));
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = -bulletSpawnPoint.up * bulletSpeed;
            audioManager.PlaySFX(audioManager.GunFire);
            CoolDown(bulletDuration);
        }
    }

    void CoolDown(float second)
    {
        if (isShoot == true)
        {
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(bulletDuration);
        EndTimer();
    }
    void EndTimer()
    {
        isShoot = false;
    }


}
