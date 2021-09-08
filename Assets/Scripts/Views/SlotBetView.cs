using UnityEngine;
using UnityEngine.UI;
using GizmoSlots.Models;

namespace GizmoSlots.Views
{

    public class SlotBetView : MonoBehaviour
    {
        #region Editor
        [SerializeField]
        private Text _betAmountText;
        [SerializeField]
        private Text _betMultiplierText;
        [SerializeField]
        private SlotMachineConfig _slotMachineConfig;
        [SerializeField]
        private PlayerModel _playerModel;
        [SerializeField]
        private Button _spinButton;
        #endregion

        #region Methods
        private void Awake()
        {
            _betAmountText.text = _slotMachineConfig.SpinCost.ToString();
            _betMultiplierText.text = _slotMachineConfig.BetMultiplier.ToString();
            _slotMachineConfig.OnBetCostChanged -= OnCoinBalanceChanged;
            _slotMachineConfig.OnBetCostChanged += OnCoinBalanceChanged;
        }

        private void OnDestroy()
        {
            _slotMachineConfig.OnBetCostChanged -= OnCoinBalanceChanged;
        }

        public void IncreaseBet()
        {
            var unit = _slotMachineConfig.IncreaseBet();
            SetText(unit);
        }

        public void DecreaseBet()
        {
            var unit = _slotMachineConfig.DecreaseBet();
            SetText(unit);
        }

        private void SetText(int textToSet)
        {
            _betMultiplierText.text = textToSet.ToString();
            _betAmountText.text = _slotMachineConfig.SpinCost.ToString();
        }

        private void OnCoinBalanceChanged()
        {
            _spinButton.interactable = _slotMachineConfig.SpinCost <= _playerModel.CoinsBalance;
        }
        #endregion
    }

}