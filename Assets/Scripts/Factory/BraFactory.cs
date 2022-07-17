using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BraFactory : Factory, ICreateble
{
    public event UnityAction Spawned;

    public override void ItemSpawn()
    {
        var template = Instantiate(ItemTemplate, SpawnPoint.position, SpawnPoint.transform.rotation);
        template.MoveToTarget(MovePoint);
        Spawned?.Invoke();
    }

    public override void OnPanelClick(Player player)
    {
        if (player.ContainsFabrick())
        {
            player.GiveItem(UtilizerPoint);
        }
    }
}
