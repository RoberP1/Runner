using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationspeed = 90f;
    [SerializeField] private float translationspeed = 90f;
    public GameManager gameManager;
    public Transform player;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationspeed * Time.deltaTime);
        if (gameManager.PowerUpIman && Vector3.Distance(player.position, transform.parent.position) < 10)
        {
            Vector3 mov = (player.position - transform.parent.position ).normalized;
            mov.y = 0;
            transform.parent.Translate(mov * translationspeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool spawn = other.gameObject.GetComponent<Obstacle>() || other.gameObject.GetComponent<Coin>() || other.gameObject.GetComponent<PowerUp>() || other.gameObject.CompareTag("Pared");
        if (!gameManager.PowerUpIman && spawn)
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            
            gameManager.UpdatCoins();
            Destroy(gameObject);
        }
    }
}
