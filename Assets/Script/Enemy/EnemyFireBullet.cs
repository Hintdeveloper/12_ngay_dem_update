using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBullet : MonoBehaviour
{
    private Renderer bulletRenderer;
    public float damage = 20f;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
