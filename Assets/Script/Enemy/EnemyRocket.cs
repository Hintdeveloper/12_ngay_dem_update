using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    private Renderer bulletRenderer;
    public float damage = 100;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}