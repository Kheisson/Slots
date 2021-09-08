using GizmoSlots.Models;
using UnityEditor;
using UnityEngine;

namespace GizmoSlots.CustomInspectors
{
    [CustomEditor(typeof(SlotMachineConfig))]
    public class SlotMachineConfigInspector : Editor
    {
        #region Fields
        private string startIncreament = "1";
        private string endIncreament = "4";
        private string jumpFactor = "2";
        #endregion

        #region Methods

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
            var slotConfig = (SlotMachineConfig)target;
            GUILayout.Space(10);
            GUILayout.Label("Slot Config", EditorStyles.boldLabel);
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Multiplier set");
            GUILayout.Label("Start");
            startIncreament = GUILayout.TextField(startIncreament);
            GUILayout.Label("End");
            endIncreament = GUILayout.TextField(endIncreament);
            GUILayout.Label("Jump by");
            jumpFactor = GUILayout.TextField(jumpFactor);

            if (GUILayout.Button("SET"))
            {
                int start = int.Parse(startIncreament);
                int end = int.Parse(endIncreament);
                int jump = int.Parse(jumpFactor);
                slotConfig.SetMultiplier(start,end,jump);
            }

            GUILayout.EndHorizontal();

        }

        #endregion
    }
}