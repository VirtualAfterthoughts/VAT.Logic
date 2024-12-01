using UnityEngine;
using UnityEngine.Events;

namespace VAT.Logic
{
    public class UnityEventNode : Node
    {
        [SerializeField]
        private Node _input;

        [SerializeField]
        private Threshold _threshold = new();

        [SerializeField]
        private UnityEvent _onThresholdMet;

        [SerializeField]
        private UnityEvent _onThresholdLost;

        private void OnEnable()
        {
            _input.OnValueChanged += OnInputChanged;
        }

        private void OnDisable()
        {
            _input.OnValueChanged -= OnInputChanged;
        }

        private void OnInputChanged(float value)
        {
            Value = value;

            switch (_threshold.SendInput(Value))
            {
                case Threshold.ThresholdPulse.HIGH:
                    _onThresholdMet?.Invoke();
                    break;
                case Threshold.ThresholdPulse.LOW:
                    _onThresholdLost?.Invoke();
                    break;
            }
        }
    }
}
