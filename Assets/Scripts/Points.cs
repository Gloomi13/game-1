using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private TMP_Text _current;
    [SerializeField] private TMP_Text _best;
    private int _currentResult;
    private int _bestResult;

    private void OnEnable()
    {
        Product.ChangedPoints += ChangingCurrentResult;
        Timer.TimeGamesExpired += ChangeBestResult;
        Pause.Restart += Restart;
        WelcomeMenu.Beginning += Restart;
    }

    private void OnDisable()
    {
        Product.ChangedPoints -= ChangingCurrentResult;
        Timer.TimeGamesExpired -= ChangeBestResult;
        Pause.Restart -= Restart;
        WelcomeMenu.Beginning -= Restart;
    }

    private void Restart()
    {
        _currentResult = 0;
        UpdateText();
    }

    private void ChangeBestResult()
    {
        if (_bestResult < _currentResult)
        {
            _bestResult = _currentResult;
            _best.text = _bestResult.ToString();
        }
    }
    private void ChangingCurrentResult(int point)
    {
        _currentResult += point;
        if (_currentResult < 0)
            _currentResult = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        _current.text = _currentResult.ToString();
    }
}
