using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button resetbn;
    [SerializeField] private Text CoinsTx;
    [SerializeField] private int coins;
    public bool PowerUpMultiplayer;
    public bool PowerUpIman;
    private Timer timer;
    private MovimientoPlayer player;

    void Start()
    {
        PowerUpMultiplayer = false;
        Cursor.lockState = CursorLockMode.Locked;
        resetbn.gameObject.SetActive(false);
        timer = FindObjectOfType<Timer>();
        player = FindObjectOfType<MovimientoPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown("r")) Reset();
    }
    public void Finish()
    {
        timer.Stop();
        player.Finish();
        resetbn.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void Reset() => SceneManager.LoadScene(0);
    public void UpdatCoins()
    {
        coins++;
        if (PowerUpMultiplayer) coins++;
        CoinsTx.text = coins.ToString();
    }
    public void Multiplayer() => StartCoroutine(MDuration(10));
    public IEnumerator MDuration(float d)
    {
        PowerUpMultiplayer = true;
        yield return new WaitForSeconds(d);
        PowerUpMultiplayer = false;
    }
    public void Iman() => StartCoroutine(ImanDuration(10));
    public IEnumerator ImanDuration(float d)
    {
        PowerUpIman = true;
        yield return new WaitForSeconds(d);
        PowerUpIman = false;
    }
}
