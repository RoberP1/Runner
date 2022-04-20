using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundTile : MonoBehaviour
{
    private GraundSpawner graundspawner;
    [SerializeField]private GameObject ObstaclePrefab;
    [SerializeField]private GameObject CoinPrefab;
    public int MaxCoinSpawn;
    public int MinCoinSpawn;

    void Start()
    {
        graundspawner = FindObjectOfType<GraundSpawner>();
        SpawnObstacle();
        SpawnCoin();
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


    public void SpawnCoin()
    {
        int coinToSpawn = Random.Range(MinCoinSpawn, MaxCoinSpawn);
        for (int i = 0; i < coinToSpawn; i++)
        {
            GameObject temp = Instantiate(CoinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            1,
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        return point;
    }
}
