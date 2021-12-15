using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject fallingBlock;
    public float spawnInterval = 1;
    float nextSpawnTime;
    Vector2 screenHalfSize;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + spawnInterval;
            Vector2 spawnPoint = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + .5f);
            Instantiate(fallingBlock, spawnPoint, Quaternion.identity);
        }
        
    }
}
