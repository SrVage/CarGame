using Code.Tools;
using UnityEngine;

namespace Code.View
{
    internal class Background : MonoBehaviour
    {
        [SerializeField] private float _leftBorder;
        [SerializeField] private float _rightBorder;
        [SerializeField] private float _relativeSpeed;
        [SerializeField] private Transform _sky;
        [SerializeField] private Transform _ground;
        private float _skyKoeff = 0.7f;
        private IReadOnlySubscriptionProperty<float> _diff;

        public void Init(IReadOnlySubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscribeOnChange(Move);
        }

        public void Move(float value)
        {
            _sky.position += Vector3.left * value * _relativeSpeed*_skyKoeff;
            _ground.position += Vector3.left * value * _relativeSpeed;
            Vector3 position = _sky.position;
            if (position.x <= _leftBorder)
            {
                _sky.position = new Vector3(_rightBorder - (_leftBorder - position.x), position.y, position.z);
            }
            else if (position.x >= _rightBorder)
            {
                _sky.position = new Vector3(_leftBorder+(_rightBorder-position.x), position.y, position.z);
            }
            position = _ground.position;
            if (position.x <= _leftBorder)
            {
                _ground.position = new Vector3(_rightBorder - (_leftBorder - position.x), position.y, position.z);
            }
            else if (position.x >= _rightBorder)
            {
                _ground.position = new Vector3(_leftBorder+(_rightBorder-position.x), position.y, position.z);
            }
        }
    }
}