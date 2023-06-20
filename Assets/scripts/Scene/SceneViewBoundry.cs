using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneViewBoundry : MonoBehaviour
{
    private Transform ceiling;
    private Transform floor;

    public float Width { get; private set; }

    private float Height
    {
        get { return ceiling.localPosition.y - floor.localPosition.y -2f;}
            
    }

    public float MinX
    {
        get { return transform.position.x - (Width * 0.5f); }
    }

    public float MaxX
    {
        get { return MinX + Width; }
    }

    private void Awake()
    {
        floor = transform.Find("Floor");
        ceiling = transform.Find("ceiling");

        if(floor != null)
        {
            Width = floor.localScale.x;
        }
    }

    public Bounds GetBounds()
    {
        return new Bounds(transform.position, new Vector3(Width, Height));
    }

}
