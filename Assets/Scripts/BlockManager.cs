using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject fallingBlock;
    public float spawnInterval = 1;
    public Vector2 sizeLimits = new Vector2(.3f, 3);
    public float angleLimit = 20;
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
            SpawnBlock();
        }
        
    }

    void SpawnBlock() {
        float blockSize = Random.Range(sizeLimits.x, sizeLimits.y);
        float spawnAngle = Random.Range(-angleLimit, angleLimit);
        Vector2 spawnPoint = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + blockSize);
        // spawn block
        GameObject block = (GameObject) Instantiate(fallingBlock, spawnPoint, Quaternion.Euler(Vector3.forward * spawnAngle));

        // Alter block's size
        block.transform.localScale = Vector3.one * blockSize;
    }
}
