using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
   
    public float scrollSpeed = 0.5f;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        float offset = Time.time * scrollSpeed;
        _renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}

