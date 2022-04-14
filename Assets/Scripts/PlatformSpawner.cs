using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject floorPrefab;
    [SerializeField]
    Transform spawnTransform;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        {
            Instantiate(floorPrefab, spawnTransform.position, Quaternion.identity);
        }
    }
}
