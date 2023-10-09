using System;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstacleMovement obstaclePrefab;

    private float spawnRate = 1.8f;
    private float heightOffset = 1f;
    private float timer = 0;
    public event EventHandler OnPassingTriggerBox;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
        
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float spawnOffset = 1.5f;
        
        ObstacleMovement newObstacle = Instantiate<ObstacleMovement>(obstaclePrefab, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, highestPoint), transform.position.z - spawnOffset), transform.rotation);
        newObstacle.OnCollidingWithTriggerBox += NewObstacle_OnCollidingWithTriggerBox;
    }

    private void NewObstacle_OnCollidingWithTriggerBox(object sender, System.EventArgs e)
    {
        OnPassingTriggerBox?.Invoke(this, EventArgs.Empty);
    }
}
