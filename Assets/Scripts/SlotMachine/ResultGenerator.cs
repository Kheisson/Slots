using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GizmoSlots
{
    public static class ResultGenerator
    {
        public static SpinResult GenerateSpinResult()
        {
            return new SpinResult
            {
                LeftIndex = (SlotIndex)Random.Range(0, 8),
                MiddleIndex = (SlotIndex)Random.Range(0, 8),
                RightIndex = (SlotIndex)Random.Range(0, 8)
            };
        }
    }
}