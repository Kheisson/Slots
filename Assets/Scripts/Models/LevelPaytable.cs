using UnityEngine;

namespace GizmoSlots.Models
{
    [CreateAssetMenu(menuName = "Gizmo Slots/Models/Level Paytable", fileName = "Level Paytable")]
    public class LevelPaytable : ScriptableObject
    {
        #region Editor

        [SerializeField]
        private int _heart = 0;
        
        [SerializeField]
        private int _coin = 0;
        
        [SerializeField]
        private int _gem = 0;
        
        [SerializeField]
        private int _lollipop = 0;
        
        [SerializeField]
        private int _icecream = 0;
        
        [SerializeField]
        private int _health = 0;
        
        [SerializeField]
        private int _cherry = 0;
        
        [SerializeField]
        private int _strawberry = 0;

        #endregion

        #region Methods

        public int GetWin(SpinResult spinResult)
        {
            return GetWinBySlotIndex(spinResult.LeftIndex) +
                GetWinBySlotIndex(spinResult.MiddleIndex) +
                GetWinBySlotIndex(spinResult.RightIndex);
        }

        private int GetWinBySlotIndex(SlotIndex slotIndex)
        {
            switch (slotIndex)
            {
                case SlotIndex.Heart:
                    return _heart;
                case SlotIndex.Coin:
                    return _coin;
                case SlotIndex.Gem:
                    return _gem;
                case SlotIndex.Lollipop:
                    return _lollipop;
                case SlotIndex.Icecream:
                    return _icecream;
                case SlotIndex.Health:
                    return _health;
                case SlotIndex.Cherry:
                    return _cherry;
                case SlotIndex.Strawberry:
                    return _strawberry;
                default:
                    return 0;
            }
        }

        #endregion
        
        #region Properties

        public int Heart => _heart;

        public int Coins => _coin;

        public int Gem => _gem;

        public int Lollipop => _lollipop;

        public int Icecream => _icecream;

        public int Health => _health;

        public int Cherry => _cherry;

        public int Strawberry => _strawberry;

        #endregion
    }
}