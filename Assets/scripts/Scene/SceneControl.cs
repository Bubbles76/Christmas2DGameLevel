using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneControl : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    List<SceneView> platformViews;

    [SerializeField]
    List<SceneObjectItem> sceneOjbectItems;

    SceneRender renderArea;

    List<GameObject> currentPlatformView;

    [SerializeField, Header("Register to know when I create a scene object item")]
    ObjectItemCreated objectItemCreated;


    // Start is called before the first frame update
    void Start()
    {
        SetRenderArea();
        currentPlatformView = new List<GameObject>();
        
    }
    

    // Update is called once per frame
    void Update()
    {
        updateEnvironment();

    }

    void SetRenderArea()
    {
        float height = 2f*Camera.main.orthographicSize;// mulitply by two to display the full height
        float width = height*Camera.main.aspect;

        renderArea = new SceneRender(width);
    }

    void updateEnvironment()
    {
        float newPlatformPosistion = 0;
        bool newPlatformNeeded = true;
        List<GameObject> viewToRemove = new List<GameObject>();

        

        // update my render min max position based on players position
        renderArea.UpdataRenderArea(player.position);

        foreach (GameObject goPlatformView in currentPlatformView)
        {
            SceneViewBoundry platfromViewBounds =
                goPlatformView.GetComponent<SceneViewBoundry>();


            // when there are no more new platforms needed
            if (platfromViewBounds.MinX > renderArea.MaxX)
            {
                newPlatformNeeded = false;
            }

            // to removed the previous platforms as the player doesnt need them
            if(platfromViewBounds.MaxX<renderArea.MinX)
            {
                viewToRemove.Add(goPlatformView);
            }
            // to set the new position
            float xPos=platfromViewBounds.MaxX+ platfromViewBounds.Width*0.5f;

            newPlatformPosistion = Mathf.Max(newPlatformPosistion, xPos);
           
        } 
        // to removed unused platforms as not needed
           RemovedUnusedPlatforms(viewToRemove);
        // if new platforms are needed to add them in
        if(newPlatformNeeded==true)
        {
            AddNewPlatform(newPlatformPosistion);
        }
    }

    void RemovedUnusedPlatforms(List<GameObject> unusedPlatforms)
    {

        foreach(GameObject RemovedUsusedPlatform in unusedPlatforms)
        {
            
            currentPlatformView.Remove(RemovedUsusedPlatform);
            Destroy(RemovedUsusedPlatform);
        }
    }

    void AddNewPlatform(float xPosition)
    {
        SceneView platformView;
        int randomIndex = 0;

        if(platformViews.Count>1)
        {
            randomIndex = Random.Range(0, platformViews.Count);

        }
        platformView = platformViews[randomIndex];

        // to create brand new game object
        GameObject newPlatformView = platformView.CreateItem(new Vector3(xPosition, 0, 0));

        // to add a brand new platform to the current list
        currentPlatformView.Add(newPlatformView);
        // to add a scene object items to platform
        SceneViewBoundry platfromViewBounds = newPlatformView.GetComponent<SceneViewBoundry>();

        AddSceneOjbectItem(platfromViewBounds.GetBounds());
    }

    void AddSceneOjbectItem(Bounds bounds)
    {
        foreach(SceneObjectItem sceneObject in sceneOjbectItems)
        {
            int num = Random.Range(1, sceneObject.MaxNumber + 1);
            for(int i = 0; i < num; i++)
            {
                GameObject newObjectItem = sceneObject.CreateItem(bounds);

                // Notify observers that object created
                if (objectItemCreated != null)
                {
                    objectItemCreated.Invoke(newObjectItem);
                }
            }
        }
    }


}
