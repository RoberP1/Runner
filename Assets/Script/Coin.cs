using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationspeed = 90f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationspeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>())
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
