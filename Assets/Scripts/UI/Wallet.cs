using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Player player;

    private int _moneyValue;

    public event UnityAction<int> MoneyChanged;

    private void OnEnable()
    {
        player.MoneyTaken += OnMoneyAdded;
    }

    private void OnDisable()
    {
        player.MoneyTaken -= OnMoneyAdded;
    }

    private void OnMoneyAdded(int value)
    {
        _moneyValue += value;
        MoneyChanged?.Invoke(_moneyValue);
    }
}
