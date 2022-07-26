using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
   
   [SerializeField] private GameObject _pauseMenu;
   [SerializeField] private GameObject Touchpad;

    public static event UnityAction Restart;

    public void RestartGame()
    {
        Touchpad.SetActive(true);
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Restart?.Invoke();
    }

    private void ThePause()
    {
        Touchpad.SetActive(false);
        _pauseMenu.SetActive(true);
        Time.timeScale=0f;
    }


    private void OnDisable()
    {
        Timer.TimeGamesExpired -= ThePause;
    }

    private void OnEnable()
    {
        Timer.TimeGamesExpired += ThePause;
    }
}
