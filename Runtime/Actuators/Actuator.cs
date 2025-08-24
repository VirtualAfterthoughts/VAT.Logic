using UnityEngine;

namespace VAT.Logic
{
    public abstract class Actuator : Node
    {
        [SerializeField]
        [Tooltip("The default input node that this actuator will read from.")]
        private Node _defaultInput = null;

        public Node DefaultInput
        {
            get
            {
                return _defaultInput;
            }
            set
            {
                _defaultInput = value;
            }
        }

        private Node _input = null;
        public Node Input
        {
            get
            {
                return _input;
            }
            set
            {
                if (_input != null)
                {
                    _input.OnValueChanged -= OnInputChanged;
                }

                _input = value;

                if (value != null)
                {
                    _input.OnValueChanged += OnInputChanged;

                    OnInputChanged(_input.Value);
                }
            }
        }

        private void Awake()
        {
            Input = DefaultInput;
        }

        private void OnDestroy()
        {
            Input = null;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            Input = DefaultInput;
        }
#endif

        protected abstract void OnInputChanged(float value);
    }
}
