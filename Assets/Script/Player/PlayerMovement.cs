using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed of player
    public float updownSpeed = 10f;
    public float leftrightSpeed = 10f;


    //set clamp position and bounds of camera
    private float camWidth;
    private float camHeight;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private float playerWidth;
    private float playerHeight;


    //Initiate buff
    GameObject shield;
    GameObject sub_player;
    // Start is called before the first frame update
    void Start()
    {
        //Get position
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        xMin = -camWidth + playerWidth / 2.0f;
        xMax = camWidth - playerWidth / 2.0f;
        yMin = -camHeight + playerHeight/2.5f;
        yMax = camHeight - playerHeight/1.5f;

        //Shield Following
        shield = transform.Find("Shield").gameObject;
        shield.transform.position = new Vector3(transform.position.x,transform.position.y,-0.03f);

        //Find Sub_Player
        sub_player = transform.Find("Sub_Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * leftrightSpeed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * updownSpeed * Time.deltaTime;

        transform.Translate(horizontalInput,verticalInput,0);

        CheckBounds();
    }

    void CheckBounds()
    {
        Vector3 pos = transform.position;
        if (pos.x < xMin)
        {
            pos.x = xMin;
        }
        else if (pos.x > xMax)
        {
            pos.x = xMax;
        }
        if (pos.y < yMin)
        {
            pos.y = yMin;
        }
        else if (pos.y > yMax)
        {
            pos.y = yMax;
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            collision.GetComponent<EnemyDamage>().TakeDamage(90);
        }
        else if (collision.gameObject.CompareTag("Enemy_1"))
        {
            collision.GetComponent<EnemyDamage>().TakeDamage(90);
        }
        else if (collision.gameObject.CompareTag("Enemy_2"))
        {
            collision.GetComponent<EnemyDamage>().TakeDamage(90);
        }

    }

    public void ActiveShield()
    {
        shield.SetActive(true);
    }

    public void ActiveSupport()
    {
        sub_player.SetActive(true);
    }
}

