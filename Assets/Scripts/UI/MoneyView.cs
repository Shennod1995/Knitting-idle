using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private GameObject _monyeTemplate;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] [Range(0f, 0.5f)] float _minAnimationDuration;
    [SerializeField] [Range(0.5f, 1f)] float _maxAnimationDuration;

    private int _maxMoneyTemplates = 3;
    private Queue<GameObject> _animatedMoneysQueue = new Queue<GameObject>();

    private void Start()
    {
        PrepareMoneyTemplate();
    }

    private void OnEnable()
    {
        _wallet.MoneyChanged += SetText;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged += SetText;
    }

    private void SetText(int value)
    {
        AnimatedMoney();
        _moneyText.text = value.ToString();
    }

    private void PrepareMoneyTemplate()
    {
        for (int i = 0; i < _maxMoneyTemplates; i++)
        {
            GameObject money = Instantiate(_monyeTemplate);
            money.transform.SetParent(transform);
            money.SetActive(false);
            _animatedMoneysQueue.Enqueue(money);
        }
    }

    private void AnimatedMoney()
    {
        for (int i = 0; i < _maxMoneyTemplates; i++)
        {
            if (_animatedMoneysQueue.Count > 0)
            {
                GameObject money = _animatedMoneysQueue.Dequeue();
                money.SetActive(true);

                money.transform.position = _spawnPoint.position;

                float duration = Random.Range(_minAnimationDuration, _maxAnimationDuration);
                money.transform.DOMove(_target.position, duration)
                    .SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        money.SetActive(false);
                        _animatedMoneysQueue.Enqueue(money);
                    });
            }
        }
    }
}