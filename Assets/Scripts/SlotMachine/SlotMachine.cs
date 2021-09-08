using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace GizmoSlots
{
    public class SlotMachine : MonoBehaviour
    {
        #region Editor
        [SerializeField]
        private SlotMachineReel[] _reels;
        [SerializeField]
        private Button _spinButton;
        #endregion

        #region Fields
        private Action<SpinResult> _onMachineSpinEnd;
        private SpinResult _lastSpinResult;
        #endregion

        #region Methods
        public void Spin(Action onBeginSpin, Action<SpinResult> onMachineSpinEnd)
        {
            onBeginSpin?.Invoke();
            _onMachineSpinEnd = onMachineSpinEnd;
            _lastSpinResult = ResultGenerator.GenerateSpinResult();
         
            _reels[0].Spin(Random.Range(2.5f, 5f), _lastSpinResult.LeftIndex, OnReelSpinStart, OnReelSpinStop);
            _reels[1].Spin(Random.Range(2.5f, 5f), _lastSpinResult.MiddleIndex, OnReelSpinStart, OnReelSpinStop);
            _reels[2].Spin(Random.Range(2.5f, 5f), _lastSpinResult.RightIndex, OnReelSpinStart, OnReelSpinStop);
        }

        private void OnReelSpinStart()
        {
            _spinButton.interactable = false;
        }

        private void OnReelSpinStop()
        {
            if (!IsSpinning)
            {
                _onMachineSpinEnd?.Invoke(_lastSpinResult);
                _spinButton.interactable = true;
            }
        }

        private bool GetIsMachineSpinning()
        {
            foreach(var reel in _reels)
            {
                if (reel.IsSpinning)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Properties
        public bool IsSpinning => GetIsMachineSpinning();
        #endregion
    }
}