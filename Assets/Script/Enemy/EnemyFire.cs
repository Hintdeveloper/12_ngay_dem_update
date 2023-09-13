using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public Transform SpawnPoint;
    public Transform rocketSpawnPoint;
    public float bulletSpeed = 10f;
    public float rocketSpeed = 10f;
    public float spawnOffset = 0.5f; // Offset distance in front of the player

    //Play weapon fire sound
    //Check for cooldown
    bool isShoot = false;
    bool isRocketShoot = false;
    //Rocket cooldown
    public float rocketDuration;
    //Bullet cooldown
    public float bulletDuration;

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
    void Update()
    {
        if (!PauseBehavior.isPaused) 
        {
            ShootingBullet();
            ShootingRocket();
        }
    }

    void ShootingBullet()
    {
        if (isShoot == false)
        {
            isShoot = true;
            Vector3 spawnPosition = SpawnPoint.position + SpawnPoint.up * spawnOffset;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.Euler(0,0,180));
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = -SpawnPoint.up * bulletSpeed;
            manager.PlaySFX(manager.GunFire);
            CoolDown(bulletDuration);
        }
    }

    void ShootingRocket()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isRocketShoot == false)
        {
            isRocketShoot = true;
            Vector3 spawnPosition = rocketSpawnPoint.position + rocketSpawnPoint.up * spawnOffset;
            GameObject rocket = Instantiate(rocketPrefab, spawnPosition, Quaternion.Euler(0, 0, 180));
            Rigidbody2D rocketRigidbody = rocket.GetComponent<Rigidbody2D>();
            rocketRigidbody.velocity = -rocketSpawnPoint.up * rocketSpeed;
            manager.PlaySFX(manager.MissileFire);
            RocketCoolDown(rocketDuration);
        }
    }
    void CoolDown(float second)
    {
        if (isShoot == true)
        {
            StartCoroutine(Timer());
        }
    }
    void RocketCoolDown(float second)
    {
        if (isRocketShoot == true)
        {
            StartCoroutine(RocketTimer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(bulletDuration);
        EndTimer();
    }
    IEnumerator RocketTimer()
    {
        yield return new WaitForSeconds(rocketDuration);
        RocketEndTimer();
    }

    void EndTimer()
    {
        isShoot = false;
    }
    void RocketEndTimer()
    {
        isRocketShoot = false;
    }

}
