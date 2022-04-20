using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject graundTile;
    public Vector3 nextSpawnPoint;
    void Start()
    {
        for (int i = 0; i < 20; i++) SpawnTile();
    }
    public void SpawnTile()
    {
        GameObject temp = Instantiate(graundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

}
