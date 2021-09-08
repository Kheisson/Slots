using UnityEngine;
using GizmoSlots.Models;
using UnityEngine.UI;

namespace GizmoSlots.Views
{
    public class CoinBalanceView : MonoBehaviour
    {
        #region Editor
        [SerializeField]
        private PlayerModel _playerModal;

        [SerializeField]
        private Text _coinBalanceText;
        #endregion

        #region Methods
        private void Awake()
        {
            _coinBalanceText.text = _playerModal.CoinsBalance.ToString();
            _playerModal.CoinsBalanceChanged -= OnCoinsBalanceChanged;
            _playerModal.CoinsBalanceChanged += OnCoinsBalanceChanged;
        }

        private void OnDestroy()
        {
            _playerModal.CoinsBalanceChanged -= OnCoinsBalanceChanged;
        }

        private void OnCoinsBalanceChanged(int oldBalance, int newBalance)
        {
            _coinBalanceText.text = newBalance.ToString();
        }
        #endregion
    }
}