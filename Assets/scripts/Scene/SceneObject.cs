using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneObjectItem : BaseSceneObject
{
    [SerializeField]
    private int maxNumber = 1;
    private bool randomPositionY;
    private float respawnInterval =1.0f; 

    public int MaxNumber
    {
        get { return maxNumber; }
    }
    public bool RandomPositionY
    {
        get { return randomPositionY; }
    }
    public float RespaenInterval
    {
        get { return respawnInterval; }
    }
    protected override Vector3 GetPosition(Vector3 currentPosistion, Bounds bounds)
    {
        Vector3 position;
        if(randomPositionY)
        {
            position = new Vector3(Random.Range(bounds.min.x, bounds.max.x),Random.Range(bounds.min.y, bounds.max.y));// x is random and y is random 
        }
        else
        {
            position = new Vector3(Random.Range(bounds.min.x, bounds.max.x),currentPosistion.y);// only x is random y is the current position
        }

        return position;
    }
}
