using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] platform;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] planet;
    [SerializeField] private GameObject gameCamera;
    private Vector3 playerPosition;
    private Vector3 cameraPosition;
    public float levelWidth = 2.5f;
    public float minY = .4f;
    public float maxY = 1.4f;
    private int numberOfPlatform = 50;
    private float maxPlatformHeight = -4;
    private float maxPlanetHeight = 4;
    private float offset = 10;

    void Awake()
    {
        ActivatePlatforms();
        GeneratePlanets();
    }

    void Update()
    { 

        playerPosition = player.transform.position;
        cameraPosition = gameCamera.transform.position;

        if (maxPlatformHeight < offset + playerPosition.y)
            ActivatePlatforms();

        if (maxPlanetHeight < offset + playerPosition.y)
            GeneratePlanets();
    }

    private void FixedUpdate()
    {
        DeactivatePlatforms();
    }

    private void GeneratePlanets()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = maxPlanetHeight + Random.Range(10, 50);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        Instantiate(planet[Random.Range(0,6)], spawnPosition, Quaternion.identity);
        maxPlanetHeight = spawnPosition.y;
    }

    private void ActivatePlatforms()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = maxPlatformHeight;

        for (int i = 0; i < numberOfPlatform; i++)
        {
            if (platform[i].activeSelf == false)
            {
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                spawnPosition.y += Random.Range(minY, maxY);
                platform[i].transform.position = spawnPosition;
                platform[i].SetActive(true);
            }
        }
        maxPlatformHeight = spawnPosition.y;
    }


    private void DeactivatePlatforms()
    {
        for(int i = 0; i < numberOfPlatform; i++)
        {
            if (platform[i].activeSelf == true)
            {
                if (cameraPosition.y - offset > platform[i].transform.position.y)
                    platform[i].SetActive(false);
            }
        }
    }
}
