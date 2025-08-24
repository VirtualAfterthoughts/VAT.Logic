using UnityEngine;

namespace VAT.Logic
{
    public sealed class ValueNode : Node
    {
        [SerializeField]
        [Range(-1f, 1f)]
        [Tooltip("The default constant value that this node will output.")]
        private float _defaultValue = 1f;

        public float DefaultValue
        {
            get
            {
                return _defaultValue;
            }
            set
            {
                _defaultValue = value;
            }
        }

        private void OnEnable()
        {
            Value = DefaultValue;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            Value = DefaultValue;
        }
#endif
    }
}