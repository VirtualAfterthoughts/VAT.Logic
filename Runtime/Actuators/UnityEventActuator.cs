using UnityEngine;
using UnityEngine.Events;

namespace VAT.Logic
{
    public class UnityEventActuator : Actuator
    {
        [SerializeField]
        private Threshold _threshold = new();

        [SerializeField]
        private UnityEvent _onThresholdMet;

        [SerializeField]
        private UnityEvent _onThresholdLost;

        protected override void OnInputChanged(float value)
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
