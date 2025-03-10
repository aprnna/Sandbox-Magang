    using System;
    using GameInput;
    using UnityEngine;

    public class BuildingPlacer : MonoBehaviour
    {
        public event Action ActiveBuildableChange;
        [field:SerializeField]
        public BuildableItem ActiveBuildable { get; private set; }

        [SerializeField] private float _maxBuildingDistance = 3f;
        
        [SerializeField] private ConstructionLayer _constructionLayer;
        [SerializeField] private PreviewLayer _previewLayer;
        [SerializeField] private MouseUser _mouseUser;

        private void Update()
        {
            if (_constructionLayer == null)
            {
                _previewLayer.ClearPreview();
                return;
            }
            Vector2 mousePos = _mouseUser.MouseInWorldPosition;
            if (ActiveBuildable == null) return;
            if (_mouseUser.IsMouseButtonPressed(MouseButton.Right))
            {
                _constructionLayer.Destroy(mousePos);
            }
            _previewLayer.ShowPreview(
                ActiveBuildable, mousePos,
                _constructionLayer.IsEmpty(mousePos) 
                && _constructionLayer.IsValidConstructionArea(mousePos) 
                );
            if (
                _mouseUser.IsMouseButtonPressed(MouseButton.Left) && 
                _constructionLayer.IsEmpty(mousePos) 
                )
            {
                _constructionLayer.Build(mousePos, ActiveBuildable);
            }
        }
        
        private bool IsMouseWithinBuildableRange()
        {
            return Vector3.Distance(_mouseUser.MouseInWorldPosition, transform.position) <= _maxBuildingDistance;
        }

        public void setActiveBuildable(BuildableItem item)
        {
            ActiveBuildable = item;
            ActiveBuildableChange?.Invoke();
        }
        
    }
