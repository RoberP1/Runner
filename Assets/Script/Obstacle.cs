using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody rb;
    public float speed;
    public int random;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (random == 0)
        {
            rb.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.Finish();
        }
        if (collision.collider.CompareTag("Pared"))
        {
            Debug.Log(speed);
            speed *= -1;
            Debug.Log(speed);
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pared"))
        {
            Debug.Log(speed);
            speed *= -1;
            Debug.Log(speed);
        }
    }*/
}
