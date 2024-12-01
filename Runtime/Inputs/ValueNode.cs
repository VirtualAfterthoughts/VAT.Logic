using UnityEngine;

namespace VAT.Logic
{
    public sealed class ValueNode : Node
    {
        [SerializeField]
        [Range(-1f, 1f)]
        private float _value = 1f;

        private void OnEnable()
        {
            Value = _value;
        }
    }
}