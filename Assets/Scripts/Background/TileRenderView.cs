using JoostenProductions;
using UnityEngine;
using UnityEngine.Events;

namespace CarInput
{
    public sealed class TileRenderView : MonoBehaviour
    {
        #region Field
        private Camera _camera;
        private TrailRenderer _trailRenderer;
        private float _currentTouchX;
        #endregion
        #region Life cycle
        public void Init(UnityAction startGame)
        {
            _camera = Camera.main;
            _trailRenderer = GetComponent<TrailRenderer>();
            _trailRenderer.emitting = false;
            UpdateManager.SubscribeToUpdate(OnUpdate);
        }
        private void OnUpdate()
        {
            CreateTileRender();
        }
        private void CreateTileRender()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                var touchWorldPos = _camera.ScreenToWorldPoint(touch.position);
                var trailRendererPos = _trailRenderer.transform.position;

                trailRendererPos.x = touchWorldPos.x;
                trailRendererPos.y = touchWorldPos.y;

                _trailRenderer.transform.position = trailRendererPos;

                if (touch.phase == TouchPhase.Began)
                {
                    _currentTouchX = touch.position.x;
                }

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (_trailRenderer.emitting == false)
                        _trailRenderer.emitting = true;
                    var step = 0f;

                    if (touch.position.x != _currentTouchX)
                    {
                        step = touch.position.x - _currentTouchX;
                        _currentTouchX = touch.position.x;
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    _trailRenderer.emitting = false;
                }
            }
        }
        internal void Init(System.Action startGame, object dailyRewardGame)
        {
            throw new System.NotImplementedException();
        }
        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(OnUpdate);
        }
    }
    #endregion
}