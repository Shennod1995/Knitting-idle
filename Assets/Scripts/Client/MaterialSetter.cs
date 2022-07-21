using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SkinnedMeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class MaterialSetter : MonoBehaviour
{
    [SerializeField] private Material _material;

    private SkinnedMeshRenderer _renderer;
    private Material[] _chengedMaterials;

    public event UnityAction MaterialChange;

    private void Start()
    {
        _renderer = GetComponent<SkinnedMeshRenderer>();
        _chengedMaterials = _renderer.materials;
        _chengedMaterials[1] = _material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bra bra))
        {
            Destroy(bra.gameObject);
            _renderer.materials = _chengedMaterials;
            MaterialChange?.Invoke();
        }
    }
}