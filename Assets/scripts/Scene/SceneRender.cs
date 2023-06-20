using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRender
{
    private float _screenWidth;
    
   public float MinX{ get; private set;}
   public float MaxX{ get; private set;}
    public SceneRender( float screenWidth)
    {
        _screenWidth = screenWidth;
    }

    public void UpdataRenderArea(Vector3 playerPosition)
    {
        MinX = playerPosition.x - _screenWidth;
        MaxX = playerPosition.x + _screenWidth;
    }
}
