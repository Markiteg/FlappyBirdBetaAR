using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstaclesMovment : MonoBehaviour
{
    public float speed;
    public GameObject bird;
    private Vector3 moveDirection;
    private bool hasDirection = false;

    private float TimeDestroy = 5;


    private void Start()
    {
        bird = GameObject.Find("Bird");
    }
    private void Update()
    {
        if (BirdController.IsPlay && bird != null)
        {
            if (!hasDirection)
            {
                moveDirection = (bird.transform.position - transform.position);
                moveDirection.y = 0;
                moveDirection = moveDirection.normalized;
                hasDirection = true;
            }

            transform.Translate(moveDirection * speed * Time.deltaTime);


            if (TimeDestroy <= 0)
            {
                Destroy(gameObject);
                TimeDestroy = 5;
            }
            else
                TimeDestroy -= Time.deltaTime;
        }
    }
}
