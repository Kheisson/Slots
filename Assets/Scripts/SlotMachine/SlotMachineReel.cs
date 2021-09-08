using System.Collections;
using System;
using UnityEngine;

namespace GizmoSlots
{
    public class SlotMachineReel : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        [Range(0f, 10f)]
        private float _spinningSpeed = 5f;

        #endregion

        #region Fields
        private Coroutine _spinCoroutine;
        #endregion

        #region Methods

        public void Spin(float spinTime, SlotIndex slotIndex, Action startSpin, Action endSpin)
        {
            _spinCoroutine =  StartCoroutine(SpinCoroutine(spinTime, slotIndex,startSpin,endSpin));
        }

        private IEnumerator SpinCoroutine(float spinTime, SlotIndex slotIndex, Action startSpin, Action endSpin)
        {
            var endSpinTime = Time.time + spinTime;

            IsSpinning = true;
            startSpin?.Invoke();

            while (true)
            {
                if(Time.time >= endSpinTime)
                {
                    transform.rotation = Quaternion.Euler(45 * (int)slotIndex, 0, 0);
                    IsSpinning = false;
                    endSpin?.Invoke();
                    yield break;
                }
                transform.RotateAround(transform.position, -Vector3.right, _spinningSpeed);
                yield return null;
            }
        }

        private void OnDestroy()
        {
            if(_spinCoroutine != null)
                StopCoroutine(_spinCoroutine);
        }

        #endregion

        #region Properties
        public bool IsSpinning { get; private set; }
        #endregion

    }
}
