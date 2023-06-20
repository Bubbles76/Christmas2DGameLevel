using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseSceneObject
{
    [SerializeField]
    protected GameObject prefab;

    public GameObject Prefab
    {
        get { return prefab; }
    }

   
    public GameObject CreateItem(Vector3 posistion)
    {
        return CreateGameObject(posistion, new Bounds());
    }
    // the boundry of where to place the object
    public GameObject CreateItem(Bounds bounds)
    {
        return CreateGameObject(prefab.transform.position, bounds);
    }

    private GameObject CreateGameObject(Vector3 posistion,Bounds bounds)
    {
        // to instatiate a brand new game object from the prefab file

        GameObject go = MonoBehaviour.Instantiate(prefab);

        // to position the object
        if(bounds.size==Vector3.zero)
        {
            go.transform.position = posistion;
        }
        else
        {
            go.transform.position = GetPosition(posistion, bounds);
        }
        return go;
    }

    protected abstract Vector3 GetPosition(Vector3 currentPosistion, Bounds bounds); 

}

