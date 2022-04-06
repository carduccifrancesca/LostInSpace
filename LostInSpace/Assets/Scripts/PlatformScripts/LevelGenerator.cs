using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platform;
    public GameObject player;
    public GameObject planet;
    public float levelWidth = 2.5f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public int numberOfPlatform;
    private float maxPlatformHeight = -4;
    private float minPlatformHeight = -4;
    private float offset = 20;

    void Awake()
    {
        GeneratePlatforms();
        GeneratePlanets();
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;

        if (maxPlatformHeight < offset + playerPosition.y)
        {
            GeneratePlatforms();
            GeneratePlanets();
        }

        if (minPlatformHeight < playerPosition.y - offset)
            DestroyLowerPlatforms();
    }

    private void GeneratePlatforms()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = maxPlatformHeight;

        for (int i = 0; i < numberOfPlatform; i++)
        {
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            spawnPosition.y += Random.Range(minY, maxY);
            Instantiate(platform, spawnPosition, Quaternion.identity);
        }
        maxPlatformHeight = spawnPosition.y;
    }

    private void GeneratePlanets()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = Random.Range(minPlatformHeight, maxPlatformHeight);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        Instantiate(planet, spawnPosition, Quaternion.identity);
    }

    private void DestroyLowerPlatforms()
    {

    }
}
