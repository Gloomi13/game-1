using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _timeGames;

    private float _currentTimeGames =99;

    public static event UnityAction TimeExpired;

    private void UpdateTime()
    {    
        _text.text = Mathf.Floor(_currentTimeGames ).ToString();
    }

    private void Restart()
    {
        _currentTimeGames  = _timeGames;
    }

    private void FixedUpdate()
    {
        _currentTimeGames  -= Time.deltaTime;
        UpdateTime();

        if (_currentTimeGames  <= 0)
        {
            _currentTimeGames  = 0;
            UpdateTime();
            TimeExpired?.Invoke();
        }
    }

    private void OnEnable()
    {
        Pause.Restart += Restart;
        WelcomeMenu.Beginning += Restart;
    }

    private void OnDisable()
    {
        Pause.Restart  -= Restart;
        WelcomeMenu.Beginning -= Restart;
    }
}
