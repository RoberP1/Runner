using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundTile : MonoBehaviour
{
    private GraundSpawner graundspawner;
    [SerializeField]private GameObject ObstaclePrefab;
    void Start()
    {
        graundspawner = FindObjectOfType<GraundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            graundspawner.SpawnTile();
            Destroy(gameObject);
        }
    }

    public void SpawnObstacle()
    {
        int obstaclePotition = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstaclePotition).transform;
        Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity,transform);
    }

}
