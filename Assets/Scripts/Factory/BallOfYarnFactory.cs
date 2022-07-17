using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallOfYarnFactory : Factory, ICreateble
{
    private float _timeToSpawn = 4f;
    private float _timeRemaining = 4f;
    private bool _timerIsRunning = false;

    public event UnityAction Spawned;

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
            var template = Instantiate(ItemTemplate, SpawnPoint.position, player.transform.rotation);
            template.MoveToTarget(MovePoint);
            _timerIsRunning = true;
            Spawned?.Invoke();
        }
    }

    public override void ItemSpawn()
    {
    }
}
