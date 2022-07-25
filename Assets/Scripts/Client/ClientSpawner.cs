using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField] private Girl _girlTemplate;
    [SerializeField] private Transform _reseption;
    [SerializeField] private Exit _exit;

    private void Start()
    {
        CreateGirl();
    }

    private void OnEnable()
    {
        _exit.GirlExit += CreateGirl;
    }

    private void OnDisable()
    {
        _exit.GirlExit -= CreateGirl;
    }

    private void CreateGirl()
    {
        var template = Instantiate(_girlTemplate, transform.position, transform.rotation);
        template.Init(_exit.transform);
        template.MoveToReseption(_reseption);
    }
}