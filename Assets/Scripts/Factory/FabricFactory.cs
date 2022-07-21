using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FabricFactory : Factory
{
    [SerializeField] private Transform _yarnPoint;

    public override void OnPanelClick(Player player)
    {
        if (player.ContainsBallOfYarn())
        {
            player.GiveItem(_yarnPoint);
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
