using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(SpriteRenderer))]

public class Product : MonoBehaviour
{
    public event UnityAction Deleted;
    public static event UnityAction<int> ChangedPoints;

    public bool isEdible { get; private set; }

    public void Add(Sprite sprite, bool isEdible)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        this.isEdible = isEdible;
    }
    private void Destroy()
    {
        Deleted?.Invoke();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Edible седобно))
        {
            ChangePoints(1);
            Destroy();
        }

        if (collision.gameObject.TryGetComponent(out NotEdible неСедобно))
        {
            ChangePoints(-1);
            Destroy();
        }
    }

    private void ChangePoints(int uuu)
    {
        if (isEdible == true)
        {
            ChangedPoints?.Invoke(uuu);
        }
        else
        {
            ChangedPoints?.Invoke(-uuu);
        }
    }
}
