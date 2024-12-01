using UnityEngine;

namespace VAT.Logic
{
    public class ActiveActuator : Actuator
    {
        [SerializeField]
        private Threshold _threshold = new();

        [SerializeField]
        private GameObject _targetGameObject = null;

        protected override void OnInputChanged(float value)
        {
            Value = value;

            switch (_threshold.SendInput(Value))
            {
                case Threshold.ThresholdPulse.HIGH:
                    _targetGameObject.SetActive(true);
                    break;
                case Threshold.ThresholdPulse.LOW:
                    _targetGameObject.SetActive(false);
                    break;
            }
        }
    }
}