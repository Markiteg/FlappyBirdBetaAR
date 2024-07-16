using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate;
    public float heightOffset;
    private float timer;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (BirdController.IsPlay)
        {
            timer += Time.deltaTime;
            if (timer >= spawnRate)
            {
                SpawnPipe();
                timer = 0;
            }
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), Quaternion.identity);
    }
}
