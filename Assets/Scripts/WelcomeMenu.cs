using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WelcomeMenu : MonoBehaviour
{
    public static event UnityAction Beginning;

    private void OnDisable()
    {
        SwipeCheck.SwipeMade -= Disable;
    }

    private void OnEnable()
    {
        SwipeCheck.SwipeMade += Disable;
    }

    private void Disable(int i)
    {
        Beginning?.Invoke();
        gameObject.SetActive(false);
    }
}
