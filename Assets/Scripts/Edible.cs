using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : MonoBehaviour
{
    [SerializeField] private ParticleSystem _plus;
    [SerializeField] private ParticleSystem _minus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Product product))
        {
            if (product.IsEdible == true)
                _plus.Play();
            else
                _minus.Play();
        }
    }
}
