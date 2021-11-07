using UnityEngine;

namespace Code.MainLogic.View
{
    public class TrailView:MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailRenderer;

        public void ShowTrail(bool show)
        {
            _trailRenderer.enabled = show;
        }
    }
}