using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARManager : MonoBehaviour
{
    public GameObject gameScenePrefab;
    private ARRaycastManager raycastManager;
    private GameObject spawnedGameScene;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;
                    if (spawnedGameScene == null)
                    {
                        spawnedGameScene = Instantiate(gameScenePrefab, hitPose.position, hitPose.rotation);
                    }
                    else
                    {
                        spawnedGameScene.transform.position = hitPose.position;
                    }
                }
            }
        }
    }
}
