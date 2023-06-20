using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneView : BaseSceneObject
{

    [SerializeField, Range(1,3)]// range level 1 to level 3
    int level = 1;


    public int Level
    {
        get { return level; }
    }
    protected override Vector3 GetPosition(Vector3 currentPosistion, Bounds bounds)
    {
        return currentPosistion;

    }
}