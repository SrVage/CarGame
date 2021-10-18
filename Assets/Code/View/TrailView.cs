using Code.InputLogic;
using UnityEngine;

namespace Code.View
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