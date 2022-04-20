using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]private int Tipo;
    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() || other.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            gameManager = FindObjectOfType<GameManager>();

            switch (Tipo)
            {
                case 0:
                    gameManager.Multiplayer();
                    break;
                case 1:
                    gameManager.Iman();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
