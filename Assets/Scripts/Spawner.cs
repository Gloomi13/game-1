using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointSpawn;
    [SerializeField] private Product _product;
    [SerializeField] private Sprite[] _edible;
    [SerializeField] private Sprite[] _notEdible;

    private int _maxObjects = 7;
    private List<Product> _products = new List<Product>();

    private void Start()
    {
        for (int i = 0; i < _maxObjects; i++)
        {
            CreateObject();
        }
    }

    private void CreateObject()
    {
        Product product = Instantiate(_product, _pointSpawn);
        Create(product);
        product.Disabled += Relocate;
        _products.Add(product);
    }

    private void Relocate()
    {
        Product product = _products.First(p => p.gameObject.activeSelf == false);
        {
            product.transform.position = _pointSpawn.position;
            product.gameObject.SetActive(true);
            Create(product);
        }
    }

    private void Create(Product product)
    {
        if (Random.Range(0, 2) == 0)
        {
            product.Add(_edible[Random.Range(0, _edible.Length)], true);
        }
        else
        {
            product.Add(_notEdible[Random.Range(0, _notEdible.Length)], false);
        }
    }

    private void OnDisable()
    {
        foreach (var product in _products)
        {
            product.Disabled -= Relocate;
        }
    }
}
