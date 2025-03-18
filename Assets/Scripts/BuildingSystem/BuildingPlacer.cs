    using System;
    using GameInput;
    using UnityEngine;

    public class BuildingPlacer : MonoBehaviour
    {
        public event Action ActiveBuildableChange;
        
        [SerializeField] private BuildableItem _activeBuildable;
        public BuildableItem ActiveBuildable => _activeBuildable;

        [SerializeField] private ConstructionTilemap constructionTilemap;
        [SerializeField] private PreviewTilemap previewTilemap;
        [SerializeField] private BuildingArea _buildingArea;
        [SerializeField] private MouseUser _mouseUser;
        private Vector2 _mousePos;

        private void Update()
        {
            _mousePos = _mouseUser.MouseInWorldPosition;
            if (constructionTilemap == null)
            {
                previewTilemap.ClearPreview();
                return;
            }
            
            if (_activeBuildable != null)
            {
                previewTilemap.ShowPreview(
                    ActiveBuildable, _mousePos,
                    constructionTilemap.IsEmpty(_mousePos, ActiveBuildable) 
                    && _buildingArea.IsAvailabelArea(_mousePos, ActiveBuildable)
                );
            }
        }

        private void OnEnable()
        {
            _mouseUser.RightMouseClicked += OnRightMouseClicked;
            _mouseUser.LeftMouseClicked += OnLeftMouseClicked;
            _mouseUser.RotateLeftPerformed += OnRotationLeftPerformed;
            _mouseUser.RotateRightPerformed += OnRotationRightPerformed;
        }

        private void OnDisable()
        {
            _mouseUser.RightMouseClicked -= OnRightMouseClicked;
            _mouseUser.LeftMouseClicked -= OnLeftMouseClicked;
            _mouseUser.RotateRightPerformed -= OnRotationRightPerformed;
            _mouseUser.RotateLeftPerformed -= OnRotationLeftPerformed;
        }
    
        public void OnRightMouseClicked()
        {
            if(ActiveBuildable == null) return;
            constructionTilemap.Destroy(_mousePos);
        }

        public void OnLeftMouseClicked()
        {
            if(ActiveBuildable == null) return;
            if (constructionTilemap.IsEmpty(_mousePos, ActiveBuildable)
                && _buildingArea.IsAvailabelArea(_mousePos, ActiveBuildable))
            {
                constructionTilemap.Build(_mousePos, ActiveBuildable);
            }
        }

        public void OnRotationLeftPerformed()
        {
            if (ActiveBuildable == null) return;
            ActiveBuildable.Rotate(RotationPerformed.Left);
        }
        
        public void OnRotationRightPerformed()
        {
            if (ActiveBuildable == null) return;
            ActiveBuildable.Rotate(RotationPerformed.Right);
        }
        
        public void SetActiveBuildable(BuildableItem item)
        {
            _activeBuildable = item;
            ActiveBuildableChange?.Invoke();
        }
        
    }
