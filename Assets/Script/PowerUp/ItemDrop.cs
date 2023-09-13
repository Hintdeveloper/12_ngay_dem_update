using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private Rigidbody2D itemRB;
    public float dropForce = 5f;

    private Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        itemRB = GetComponent<Rigidbody2D>();

        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        itemRB.velocity = new Vector2(0,-1 * dropForce);
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
