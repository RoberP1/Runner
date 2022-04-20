using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Timer timer;
    private MovimientoPlayer player;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Finish()
    {
        timer.Stop();
        player.Finish();
    }
}
