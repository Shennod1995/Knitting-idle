using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FabricFactory : Factory, ICreateble
{
    public event UnityAction Spawned;

    public override void OnPanelClick(Player player)
    {
        if (player.ContainsBallOfYarn())
        {
            player.GiveItem(UtilizerPoint);
        }
    }

    public override void ItemSpawn()
    {
        var template = Instantiate(ItemTemplate, SpawnPoint.position, SpawnPoint.transform.rotation);
        template.MoveToTarget(MovePoint);
        Spawned?.Invoke();
    }
}
