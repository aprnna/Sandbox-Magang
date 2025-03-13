    using System;
    using GameInput;
    using UnityEngine;
    using UnityEngine.Serialization;

    public class BuildingPlacer : MonoBehaviour
    {
        public event Action ActiveBuildableChange;
        
        [SerializeField] private BuildableItem _activeBuildable;
        public BuildableItem ActiveBuildable => _activeBuildable;

        [SerializeField] private ConstructionTilemap constructionTilemap;
        [SerializeField] private PreviewTilemap previewTilemap;
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
                    constructionTilemap.IsEmpty(_mousePos, ActiveBuildable.Dimenstion) 
                );
            }
        }

        private void OnEnable()
        {
            _mouseUser.RightMouseClicked += OnRightMouseClicked;
            _mouseUser.LeftMouseClicked += OnLeftMouseClicked;
            _mouseUser.RotationPerformed += OnRotationPerformed;
        }

        private void OnDisable()
        {
            _mouseUser.RightMouseClicked -= OnRightMouseClicked;
            _mouseUser.LeftMouseClicked -= OnLeftMouseClicked;
            _mouseUser.RotationPerformed -= OnRotationPerformed;
        }
    
        public void OnRightMouseClicked()
        {
            if(ActiveBuildable == null) return;
            constructionTilemap.Destroy(_mousePos);
        }

        public void OnLeftMouseClicked()
        {
            if(ActiveBuildable == null) return;
            if (constructionTilemap.IsEmpty(_mousePos, ActiveBuildable.Dimenstion))
            {
                constructionTilemap.Build(_mousePos, ActiveBuildable);
            }
        }

        public void OnRotationPerformed()
        {
            if (_activeBuildable == null) return;
            _activeBuildable.Rotate();
        }
        
        public void SetActiveBuildable(BuildableItem item)
        {
            _activeBuildable = item;
            ActiveBuildableChange?.Invoke();
        }
        
    }
