using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button resetbn;
    private Timer timer;
    private MovimientoPlayer player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        resetbn.gameObject.SetActive(false);
        timer = FindObjectOfType<Timer>();
        player = FindObjectOfType<MovimientoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Reset();
        }
    }
    public void Finish()
    {
        timer.Stop();
        player.Finish();
        resetbn.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

}
