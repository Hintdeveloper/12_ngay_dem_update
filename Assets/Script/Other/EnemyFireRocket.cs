using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireRocket : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform rocketSpawnPoint;
    public float rocketSpeed = 20f;
    public float delay = 15f;
    public float spawnOffset = 0.5f;
    private float timer = 0f;

    public AudioClip rocketfireSound;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            Vector3 spawnPosition = rocketSpawnPoint.position + rocketSpawnPoint.up * spawnOffset;
            GameObject rocket = Instantiate(rocketPrefab, spawnPosition, rocketSpawnPoint.rotation);
            source.PlayOneShot(rocketfireSound);
            Rigidbody2D rocketRigidbody = rocket.GetComponent<Rigidbody2D>();
            rocketRigidbody.velocity = -rocketSpawnPoint.up * rocketSpeed;
            timer = 0f;


        }
    }
}
