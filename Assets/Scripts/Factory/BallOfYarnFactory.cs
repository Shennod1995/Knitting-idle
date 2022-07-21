using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallOfYarnFactory : Factory
{
    private float _timeToSpawn = 4f;
    private float _timeRemaining = 4f;
    private bool _timerIsRunning = false;

    private void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                _timerIsRunning = false;
                _timeRemaining = _timeToSpawn;
            }
        }      
    }

    public override void OnPanelClick(Player player)
    {
        if (player.HaveItem == false && _timerIsRunning == false)
        {
            ItemSpawn();
            _timerIsRunning = true;
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
