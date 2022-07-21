using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BraFactory : Factory
{
    [SerializeField] private Transform _FabricPoint;

    public override void OnPanelClick(Player player)
    {
        if (player.ContainsFabrick())
        {
            player.GiveItem(_FabricPoint);
        }
    }

    public override void ItemSpawn()
    {
        StartCoroutine(DelayToSpawn());
    }

    public override IEnumerator DelayToSpawn()
    {
        yield return new WaitForSeconds(Delay);

        var template = Instantiate(ItemTemplate, SpawnPoint.position, SpawnPoint.transform.rotation);
        template.SetTarget(MovePoint);
    }
}
