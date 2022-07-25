using System.Collections;
using UnityEngine;

public class BallOfYarnFactory : Factory
{
    private float _timeToSpawn = 4f;
    private float _timeRemaining;
    private bool _timerIsRunning = false;

    private void Start()
    {
        _timeRemaining = _timeToSpawn;
    }

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
