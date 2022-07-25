using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerHands _playerHands;

    private Item _item;

    public bool HaveItem => _item != null;

    public event UnityAction ItemTaken;
    public event UnityAction ItemGiven;
    public event UnityAction<int> MoneyTaken;

    private void OnEnable()
    {
        _playerHands.Grabbed += TakeItem;
    }

    private void OnDisable()
    {
        _playerHands.Grabbed -= TakeItem;
    }

    public void TakeItem(Item item)
    {
        _item = item;
        ItemTaken?.Invoke();
    }

    public bool ContainsBallOfYarn() => _item is BallOfYarn;
    public bool ContainsFabrick() => _item is Fabric;
    public bool ContainsBra() => _item is Bra;

    public void TakeMoney(int value)
    {
        MoneyTaken?.Invoke(value);
    }

    public void GiveItem(Transform factoryPoint)
    {
        _item.SetTarget(factoryPoint);
        ItemGiven?.Invoke();
        _item = null;
    }
}