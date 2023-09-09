using System.Collections;
using System.Collections.Generic;
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
    AudioManager manager;
    //Check for cooldown
    bool isShoot = false;
    bool isRocketShoot = false;
    //Rocket cooldown
    public float rocketDuration;
    //Bullet cooldown
    public float bulletDuration;
    float remainingDuration;
    float rocketRemainingDuration;

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
        ShootingBullet();
        ShootingRocket();
    }

    void ShootingBullet()
    {
        if (isShoot == false)
        {
            isShoot = true;
            Vector3 spawnPosition = SpawnPoint.position + SpawnPoint.up * spawnOffset;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.Euler(0,0,180));
            manager.PlaySFX(manager.GunFire);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = -SpawnPoint.up * bulletSpeed;
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
            manager.PlaySFX(manager.MissileFire);
            Rigidbody2D rocketRigidbody = rocket.GetComponent<Rigidbody2D>();
            rocketRigidbody.velocity = -rocketSpawnPoint.up * rocketSpeed;
            RocketCoolDown(rocketDuration);
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
    void RocketCoolDown(float second)
    {
        rocketRemainingDuration = second;
        if (isRocketShoot == true)
        {
            StartCoroutine(RocketTimer());
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
    IEnumerator RocketTimer()
    {
        while (rocketRemainingDuration >= 0)
        {
            rocketRemainingDuration -= 0.1f;
            yield return null;
        }
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
