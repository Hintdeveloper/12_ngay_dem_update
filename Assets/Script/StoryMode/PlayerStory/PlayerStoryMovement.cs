using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoryMovement : MonoBehaviour
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


    //Get GameManager
    GameManager gameManager;

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
        yMin = -camHeight + playerHeight / 2.5f;
        yMax = camHeight - playerHeight / 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * leftrightSpeed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * updownSpeed * Time.deltaTime;

        transform.Translate(horizontalInput, verticalInput, 0);

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
            gameManager.GameOver();
        }
        else if (collision.gameObject.CompareTag("Enemy_1"))
        {
            gameManager.GameOver();
        }
        else if (collision.gameObject.CompareTag("Enemy_2"))
        {
            gameManager.GameOver();
        }
        else if (collision.gameObject.CompareTag("Trigger"))
        {
            if (collision.gameObject.name == "Trigger_1")
            {
                Debug.Log("Panel_1");
            }
            else if (collision.gameObject.name == "Trigger_2")
            {
                Debug.Log("Panel_2");
            }
        }
    }

}
