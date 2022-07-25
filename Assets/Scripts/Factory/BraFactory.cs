using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BraFactory : Factory
{
    [SerializeField] private Transform _FabricPoint;

    private Animator _animator;
    private const string Push = "Push";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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
        _animator.SetTrigger(Push);

        yield return new WaitForSeconds(Delay);

        var template = Instantiate(ItemTemplate, SpawnPoint.position, SpawnPoint.transform.rotation);
        template.SetTarget(MovePoint);
    }
}
