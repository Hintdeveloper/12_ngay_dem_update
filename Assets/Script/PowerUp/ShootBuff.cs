using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class ShootBuff : MonoBehaviour
{
    public GameObject AAbulletPrefab;
    public GameObject SAMbulletPrefab;
    public float bulletSpeed = 10f;
    public float rocketSpeed = 70f;

    //Play weapon fire sound
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
        //ShootingBullet();
    }

    public void ShootingBullet(Transform transform)
    {
        
        GameObject bullet = Instantiate(AAbulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = new Vector2(0, 1 * bulletSpeed);
    }
    public void ShootingSAM(Transform transform)
    {
        
        GameObject bullet = Instantiate(SAMbulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = new Vector2(0, 1 * rocketSpeed);
    }



}
