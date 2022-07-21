using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Money _moneyTemplate;

    private Girl _client = new Girl();
    private int _count = 5;
    private float _radius = 2;
    private Vector3 _center;

    private void Start()
    {
        _center = transform.position;
    }

    private void OnDisable()
    {
        _client.Payed -= OnPayed;
    }

    public void Init(Girl client)
    {
        _client = client;
        _client.Payed += OnPayed;
    }


    private void OnPayed()
    {
        for (int i = 0; i < _count; i++)
        {
            Vector3 position = Random.insideUnitSphere * _radius + _center;
            Instantiate(_moneyTemplate, position, Quaternion.identity);
        }
    }
}