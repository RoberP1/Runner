using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody rb;
    public float speed;
    public int random;
    public bool puedecambiar = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puedecambiar = true;
    }
    void Update()
    {
        if (random == 0) rb.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.Finish();
        }
        if (collision.collider.CompareTag("Pared") && puedecambiar)
        {
                speed *= -1;
                StartCoroutine(Delay(2));
        }
    }
    public IEnumerator Delay(float d)
    {
        puedecambiar = false;
        yield return new WaitForSeconds(d);
        puedecambiar = true;
    }
}
