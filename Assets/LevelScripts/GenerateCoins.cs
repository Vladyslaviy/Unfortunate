using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateCoins : MonoBehaviour
{
    enum ObjectType
    {
        Coin
    }
    public GameObject coin_Object;
    // Start is called before the first frame update
    void Start()
    {
        for (; current_coins < max_coins; current_coins++)
        {
            SpawnOjectRandomSpotGrounded(coin_Object, ObjectType.Coin);
        }
    }

    //0.7
    List<GameObject> coins = new List<GameObject>();
    int max_coins = 20;
    int current_coins = 0;
    void Update()
    {

    }
    void SpawnOjectRandomSpotGrounded(GameObject objectToSpawn, ObjectType objectType)
    {
        objectToSpawn.transform.position = getRandomSpawnVector3(objectToSpawn, 1.2f);
        GameObject newObject = Instantiate(objectToSpawn);
        if (objectType==ObjectType.Coin)
        {
            coins.Add( newObject );
        }
        
    }
    float getRandomXCoordinate()
    {
        return (float)Math.Round((double)UnityEngine.Random.Range(-145.0f, 145.0f), 1);
    }
    float getRandomZCoordinate()
    {
        return (float)Math.Round((double)UnityEngine.Random.Range(-145.0f, 145.0f), 1);
    }
    float getRandomYCoordinate()
    {
        return (float)Math.Round((double)UnityEngine.Random.Range(0.9f, 145.0f), 1);
    }
    Vector3 getRandomSpawnVector3(GameObject objectToSpawn) {
        Vector3 spawnPos = new Vector3 { x = getRandomXCoordinate(), y = getRandomYCoordinate(), z = getRandomZCoordinate() };
        Vector3 objectScale = objectToSpawn.transform.localScale;
        float radius = Math.Max(Math.Max(objectScale.x, objectScale.y), objectScale.z);
        while (Physics.CheckSphere(spawnPos, radius))
        {
            spawnPos = new Vector3 { x = getRandomXCoordinate(), y = getRandomYCoordinate(), z = getRandomZCoordinate() };
        }
        return spawnPos;
    }
    Vector3 getRandomSpawnVector3(GameObject objectToSpawn, float y)
    {
        Vector3 spawnPos = new Vector3 { x = getRandomXCoordinate(), y = y, z = getRandomZCoordinate() };
        Vector3 objectScale = objectToSpawn.transform.localScale;
        float radius = Math.Max(Math.Max(objectScale.x, objectScale.y), objectScale.z);
        while (Physics.CheckSphere(spawnPos, radius))
        {
            spawnPos = new Vector3 { x = getRandomXCoordinate(), y = y, z = getRandomZCoordinate() };
        }
        return spawnPos;
    }
}
