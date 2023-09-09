using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public float speed = 30f;
    private Vector3 startPosition;
    private float repeatHeight;

    private void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, 2);
        repeatHeight = GetComponent<BoxCollider2D>().size.y / 2;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < startPosition.y - repeatHeight)
        {
            transform.position = startPosition;
        }
    }
}

