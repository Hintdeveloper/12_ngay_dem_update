using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Camera m_Camera;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy downwards in the Y axis
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        DestroyOffBounds();
    }

    void DestroyOffBounds()
    {
        Vector2 sceenBounds = m_Camera.WorldToScreenPoint(transform.position);

        if (sceenBounds.y < 0 || sceenBounds.y > m_Camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
