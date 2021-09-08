using System;
using UnityEngine;

namespace GizmoSlots.Models
{
    [CreateAssetMenu(menuName = "Gizmo Slots/Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<int, int> CoinsBalanceChanged;

        #endregion
        
        #region Editor

        [SerializeField]
        private int _coinsBalance;

        #endregion

        #region Methods

        public void AddCoins(int coinsToAdd)
        {
            var oldBalance = _coinsBalance;
            _coinsBalance += coinsToAdd;
            
            CoinsBalanceChanged?.Invoke(oldBalance, _coinsBalance);
        }

        public void WithdrawCoins(int coinsToWithdraw)
        {
            var oldBalance = _coinsBalance;
            _coinsBalance = Mathf.Max(0, _coinsBalance - coinsToWithdraw);
            CoinsBalanceChanged?.Invoke(oldBalance, _coinsBalance);
        }

        #endregion
        
        #region Properties

        public int CoinsBalance => _coinsBalance;

        #endregion
    }
}