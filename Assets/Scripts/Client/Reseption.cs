using UnityEngine;

public class Reseption : MonoBehaviour
{
    [SerializeField] private PanelActivator _panel;
    [SerializeField] private BraMover _braMover;
    [SerializeField] private MoneySpawner _moneySpawner;

    private void OnEnable()
    {
        _panel.Activate += OnPanelClick;
    }

    private void OnDisable()
    {
        _panel.Activate -= OnPanelClick;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Girl girl))
        {
            _braMover.Init(girl.BraContainer);
            _moneySpawner.Init(girl);
        }
    }

    private void OnPanelClick(Player player)
    {
        if (player.ContainsBra())
        {
            player.GiveItem(_panel.transform);
        }
    }
}
