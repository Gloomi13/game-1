using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointSpawn;
    [SerializeField] private Product _product;
    [SerializeField] private Sprite[] _edible;
    [SerializeField] private Sprite[] _notEdible;
    private int _numberObjects;
    private Coroutine _createObject;

    private void Start()
    {
        StartCreateObject();
    }

    private void StopCreateObject()
    {
        if (_createObject != null)
            StopCoroutine(_createObject);
    }

    private void StartCreateObject()
    {
        if (_createObject != null)
            StopCoroutine(_createObject);
        _createObject = StartCoroutine(CreateObject());
    }

    private void AddObject()
    {
        _numberObjects--;
        StartCreateObject();
    }

    private IEnumerator CreateObject()
    {
        WaitForSeconds waitFor = new WaitForSeconds(0.2f);

        while (_numberObjects < 8)
        {
            Product product = Instantiate(_product, _pointSpawn);

            if (Random.Range(0, 2) == 0)
            {
                product.Add(_edible[Random.Range(0, _edible.Length)], true);
            }
            else
            {
                product.Add(_notEdible[Random.Range(0, _notEdible.Length)], false);
            }

            product.Deleted += AddObject;
            _numberObjects++;

            yield return waitFor;
        }

        StopCreateObject();
    }
}
