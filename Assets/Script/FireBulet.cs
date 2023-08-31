using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulet : MonoBehaviour
{

    private Renderer bulletRenderer;
    public float damege = 20;
    // Start is called before the first frame update
    void Start()
    {
        bulletRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsVisibleOnScreen())
        {
            // Destroy the bullet game object when it goes even slightly out of the camera bounds
            Destroy(gameObject);
        }
    }

    private bool IsVisibleOnScreen()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        if (GeometryUtility.TestPlanesAABB(planes, bulletRenderer.bounds))
        {
            return true;
        }

        return false;
    }
    //private void //OnBecameInvisible()
    //{
    //    if (!bulletRenderer.isVisible)
    //    {
    //        // Destroy the bullet game object when it goes out of bounds of the camera
    //        Destroy(gameObject);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthBar>().ReduceHP(damege);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthBar>().ReduceHP(damege);
            Destroy(gameObject);
        }
    }
}
