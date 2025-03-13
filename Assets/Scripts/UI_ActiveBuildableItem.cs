using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActiveBuildableItem :MonoBehaviour
{
    [SerializeField] private BuildingPlacer _buildingPlacer;
    private Image _icon;
    private void Awake()
    {
        _icon = GetComponent<Image>();
        _buildingPlacer.ActiveBuildableChange += OnActiveBuildableChanged;
    }

    private void OnDisable()
    {
        _buildingPlacer.ActiveBuildableChange -= OnActiveBuildableChanged;
    }

    private void Start()
    {
        OnActiveBuildableChanged();
    }

    private void OnActiveBuildableChanged()
    {
        if (_buildingPlacer.ActiveBuildable != null)
        {
            _icon.enabled = true;
            _icon.sprite = _buildingPlacer.ActiveBuildable.UIIcon;
        }
        else
        {
            _icon.enabled = false;
        }
    }
}