using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class LoopedMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private MeshRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        var offset = Time.time * _speed;
        _renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
