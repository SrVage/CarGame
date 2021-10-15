using UnityEngine;

namespace Code.View
{
    internal class Background : MonoBehaviour
    {
        [SerializeField] private float _leftBorder;
        [SerializeField] private float _rightBorder;
        [SerializeField] private float _relativeSpeed;

        public void Move(float value)
        {
            transform.position += Vector3.left * value * _relativeSpeed;
            Vector3 position = transform.position;
            if (position.x <= _leftBorder)
            {
                transform.position = new Vector3(_rightBorder - (_leftBorder - position.x), position.y, position.z);
            }
            else if (position.x >= _rightBorder)
            {
                transform.position = new Vector3(_leftBorder+(_rightBorder-position.x), position.y, position.z);
            }
        }
    }
}