using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GizmoSlots.Models
{
    [CreateAssetMenu(fileName = "Slot Machine Config", menuName = "Gizmo Slots/Models/Slot Machine Config")]
    public class SlotMachineConfig : ScriptableObject
    {
        #region Editor
        [SerializeField]
        private int _spinCost;
        [SerializeField]
        private int _betMultiplier;
        [SerializeField]
        private int _maxBet;
        [SerializeField]
        private List<int> _betMultipliers = new List<int>();
        #endregion

        #region Fields
        private int _iterator;
        public event Action OnBetCostChanged;
        #endregion

        #region Properties
        public int SpinCost { get { return _spinCost * _betMultiplier; }}
        public int BetMultiplier => _betMultiplier;
        public int MaxBet => _maxBet;
        #endregion

        #region Methods
        public void SetMultiplier(int start, int end, int jump)
        {
            if(start >= end || jump <= 0 || start <= 0)
            {
                throw new System.FormatException("Invalid item passed as argument");
            }

            //---Initialization---
            _betMultipliers.Clear(); //Clear list
            if (start != 1)
                _betMultipliers.Add(1); //Always add 1 to the beginning of the list
            _iterator = 0;


            var incremented = start;
            do
            {
                _betMultipliers.Add(incremented);
                incremented += jump;
                if (incremented > end)
                    break;
            }
            while (incremented < end);
        }

        public int IncreaseBet()
        {
            _iterator += 1;
            try
            {
                int returnable = _betMultipliers[_iterator];
                SetRound(returnable);
                return returnable;
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                _iterator = 0;
                SetRound(_betMultipliers[_iterator]);
                return _betMultipliers[_iterator];
            }
            
        }

        public int DecreaseBet()
        {
            _iterator -= 1;
            try
            {
                int returnable = _betMultipliers[_iterator];
                SetRound(returnable);
                return returnable;
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                _iterator = _betMultipliers.Count - 1;
                SetRound(_betMultipliers[_iterator]);
                return _betMultipliers[_iterator];
            }
        }

        private void SetRound(int betMultiplier)
        {
            _betMultiplier = betMultiplier;
            OnBetCostChanged?.Invoke();
        }
        #endregion
    }

}