using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code.Rewards.View
{
    public class CurrencyView:MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentGold;
        [SerializeField] private TMP_Text _currentDiamonds;

        private void Awake()
        {
            transform.DOLocalMove(new Vector3(transform.position.x, 200, transform.position.z), 1f).From();
        }

        public int Gold
        {
            set => _currentGold.text=value.ToString();
        }

        public int Diamonds
        {
            set => _currentDiamonds.text=value.ToString();
        }
    }
}