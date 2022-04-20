using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundTile : MonoBehaviour
{
    private GraundSpawner graundspawner;
    [SerializeField]private GameObject ObstaclePrefab;
    [SerializeField]private GameObject CoinPrefab;
    [SerializeField]private GameObject[] poweups;
    public int MaxCoinSpawn;
    public int MinCoinSpawn;

    void Start()
    {
        graundspawner = FindObjectOfType<GraundSpawner>();
        SpawnObstacle();
        SpawnPowerUP();
        SpawnCoin();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            graundspawner.SpawnTile();
            StartCoroutine(Delay(2));   
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
    public void SpawnPowerUP()
    {
        if (Random.Range(1, 10) == 1)
        {
            int poweUpPotition = Random.Range(9, 11);
            Transform spawnPoint = transform.GetChild(poweUpPotition).transform;
            GameObject temp = Instantiate(poweups[Random.Range(0, poweups.Length)],spawnPoint.position, Quaternion.identity, transform);
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
    public IEnumerator Delay(float d)
    {
        yield return new WaitForSeconds(d);
        Destroy(gameObject);
    }
}
