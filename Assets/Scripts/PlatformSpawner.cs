using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject testPrefab;
    [SerializeField]
    GameObject floorPrefab;
    [SerializeField]
    Transform spawnTransform;
    Tier[] Tiers;
    private void Start()
    {
        Tiers = GetComponentsInChildren<Tier>();
        for(int i = 0; i < Tiers.Length; i++)
        {
            Instantiate(testPrefab, Tiers[i].transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        {
            Instantiate(floorPrefab, spawnTransform.position, Quaternion.identity);
        }
    }
}
