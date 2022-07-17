using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class PanelActivator : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _activatedColor;

    private MeshRenderer _meshRenderer;

    public event UnityAction<Player> Activate;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        RenderDefaultColors();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            RenderActivateColors();
            Activate?.Invoke(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            RenderDefaultColors();
        }
    }

    private void RenderActivateColors()
    {
        _meshRenderer.materials[0].color = _activatedColor;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void RenderDefaultColors()
    {
        _meshRenderer.materials[0].color = _defaultColor;
        transform.GetChild(0).gameObject.SetActive(false);
    } 
}
