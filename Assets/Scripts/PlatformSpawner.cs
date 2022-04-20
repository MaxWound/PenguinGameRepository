using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField][Range(0f,1f)]
    float ObstacleSpawnChance;
    public static bool FirstSpawned;
    [SerializeField]
    GameObject SnakePrefab;
    [SerializeField]
    GameObject GiraffePrefab;
    [SerializeField]
    GameObject ElephantPrefab;

    GameObject[] Obstacles;

    [SerializeField]
    private Transform FirstFirstGroundPos;
    [SerializeField]
    private Transform FirstSecondGroundPos;

    [SerializeField]
    private Transform SecondFirstGroundPos;
    [SerializeField]
    private Transform SecondSecondGroundPos;

    [SerializeField]
    private Transform ThirdFirstGroundPos;
    [SerializeField]
    private Transform ThirdSecondGroundPos;

    private bool nextSpawned;
    [SerializeField]
    GameObject testPrefab;
    [SerializeField]
    GameObject floorPrefab;
    [SerializeField]
    Transform spawnTransform;
    Tier[] Tiers;
    private void Start()
    {
        FirstSpawned = false;
        Obstacles = new GameObject[] {SnakePrefab, GiraffePrefab, ElephantPrefab};
        nextSpawned = false;
        SpawnObstacles();
        /*Tiers = GetComponentsInChildren<Tier>();
        for(int i = 0; i < Tiers.Length; i++)
        {
            Instantiate(testPrefab, Tiers[i].transform.position, Quaternion.identity);
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(nextSpawned != true)
        {
            SpawnNextFloor();
        }
        else
        {

        }
    }
    void SpawnNextFloor()
    {
        Instantiate(floorPrefab, spawnTransform.position, Quaternion.identity);
        nextSpawned = true;
    }
    void SpawnObstacles()
    {
        if (RandomBool() == true)
        {
            Vector3 FirstRandPos = new Vector3(Random.Range(FirstFirstGroundPos.position.x, FirstSecondGroundPos.position.x), FirstFirstGroundPos.position.y, 0f);
            Instantiate(RandomObstacle(), FirstRandPos, Quaternion.identity);
        }
        if (RandomBool() == true)
        {
            Vector3 SecondRandPos = new Vector3(Random.Range(SecondFirstGroundPos.position.x, SecondSecondGroundPos.position.x), SecondFirstGroundPos.position.y, 0f);
            Instantiate(RandomObstacle(), SecondRandPos, Quaternion.identity);
        }
        if (RandomBool() == true && FirstSpawned == true)
        {
            Vector3 ThirdRandPos = new Vector3(Random.Range(ThirdFirstGroundPos.position.x, ThirdSecondGroundPos.position.x), ThirdFirstGroundPos.position.y, 0f);
            Instantiate(RandomObstacle(), ThirdRandPos, Quaternion.identity);
            FirstSpawned = true;
        }
    }
    GameObject RandomObstacle()
    {
       GameObject RandObstacle = Obstacles[Mathf.RoundToInt(Random.Range(0f, Obstacles.Length - 1.01f))];
        return RandObstacle;
    }
    bool RandomBool()
    {
        float RandValue = (Random.Range(0f, 1f));
        if(RandValue <= ObstacleSpawnChance)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
