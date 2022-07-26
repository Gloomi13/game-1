using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]

public class Product : MonoBehaviour
{
    public event UnityAction  Disabled;
    public static event UnityAction<int> ChangedPoints;

    public bool IsEdible { get; private set; }

    public void Add(Sprite sprite, bool isEdible)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        IsEdible = isEdible;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
        Disabled?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Edible edible))
        {
            ChangePoints(1);
            Disable();
        }

        if (collision.gameObject.TryGetComponent(out NotEdible notEdible))
        {
            ChangePoints(-1);
            Disable();
        }
    }

    private void ChangePoints(int point)
    {
        if (IsEdible == true)
        {
            ChangedPoints?.Invoke(point);
        }
        else
        {
            ChangedPoints?.Invoke(-point);
        }
    }
}
