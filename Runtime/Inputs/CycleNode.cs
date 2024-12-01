using UnityEngine;

namespace VAT.Logic
{
    public class CycleNode : Node
    {
        [SerializeField]
        [Min(0f)]
        [Tooltip("The offset of the cycle in seconds.")]
        private float _offset = 0f;

        [SerializeField]
        [Min(0.01f)]
        [Tooltip("The time it takes one cycle to complete in seconds.")]
        private float _period = 1f;

        protected override void OnWriteOutputs(float deltaTime)
        {
            base.OnWriteOutputs(deltaTime);

            float periodOffset = 2f * Mathf.PI / _period;
            float cycle = Mathf.Sin(periodOffset * (Time.time + _offset));

            Value = cycle > 0f ? 1f : 0f;
        }
    }
}