using UnityEngine;

namespace VAT.Logic
{
    public abstract class Actuator : Node
    {
        [SerializeField]
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
                }
            }
        }

        private void Awake()
        {
            if (Input != null)
            {
                Input.OnValueChanged += OnInputChanged;
            }
        }

        private void OnDestroy()
        {
            if (Input != null)
            {
                Input.OnValueChanged -= OnInputChanged;
            }
        }

        protected abstract void OnInputChanged(float value);
    }
}
