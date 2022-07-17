using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Factory : MonoBehaviour
{
    [SerializeField] private PanelActivator _panelActivator;
    [SerializeField] private Item _itemTemplate;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _movePoint;
    [SerializeField] private Utilizer _utilizer;

    public Item ItemTemplate => _itemTemplate;
    public Transform SpawnPoint => _spawnPoint;
    public Transform MovePoint => _movePoint;
    public Transform UtilizerPoint => _utilizer.transform;

    private void OnEnable()
    {
        _panelActivator.Activate += OnPanelClick;
        _utilizer.Revised += ItemSpawn;
    }

    private void OnDisable()
    {
        _panelActivator.Activate -= OnPanelClick;
        _utilizer.Revised -= ItemSpawn;
    }

    public abstract void ItemSpawn();
    public abstract void OnPanelClick(Player player);
}
