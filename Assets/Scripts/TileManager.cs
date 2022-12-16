using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpwan = 0;
    public float tileLength = 30;
    public float maxTails;
    public bool hasMaxTails;
    public int numberOfTils = 5;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        if(hasMaxTails)
        {
            for (int i = 0; i < maxTails; i++)
            {
                if (i == 0) SpawnTile(0);
                SpawnTile(Random.Range(0, tilePrefabs.Length - 2));
            }
            SpawnTile(tilePrefabs.Length - 1);
        }else
        {
            for (int i = 0; i < numberOfTils; i++)
            {
                if (i == 0) SpawnTile(0);
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position.z - 35 > zSpwan - (numberOfTils * tileLength )) && !hasMaxTails)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go =  Instantiate(tilePrefabs[tileIndex], transform.forward * zSpwan, transform.rotation);
        activeTiles.Add(go);
        zSpwan += tileLength;
    }
}
