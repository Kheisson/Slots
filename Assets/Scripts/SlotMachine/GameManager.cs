using GizmoSlots.Models;
using UnityEngine;

namespace GizmoSlots
{

    public class GameManager : MonoBehaviour
    {
        #region Editor
        [SerializeField]
        private SlotMachine _slotMachine;
        [SerializeField]
        private LevelPaytable _paytable;
        [SerializeField]
        private PlayerModel _playerModel;
        [SerializeField]
        private SlotMachineConfig _slotMachineConfig;
        #endregion

        #region Methods
        public void OnSpinButtonClicked()
        {
            if (_playerModel.CoinsBalance > _slotMachineConfig.SpinCost)
            {
                _slotMachine.Spin(() =>
                {
                    _playerModel.WithdrawCoins(_slotMachineConfig.SpinCost);
                }
                , result =>
                {
                    GivePlayerPrize(_paytable.GetWin(result));
                });
            }
        }

        private void GivePlayerPrize(int amount)
        {
            _playerModel.AddCoins(amount * _slotMachineConfig.BetMultiplier);
        }
        #endregion
    }

}