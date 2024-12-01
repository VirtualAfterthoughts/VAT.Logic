using UnityEngine;

namespace VAT.Logic
{
    public class ActiveNode : Node
    {
        [SerializeField]
        private Node _input;

        [SerializeField]
        private Threshold _threshold = new();

        [SerializeField]
        private GameObject _targetGameObject = null;

        private void Awake()
        {
            _input.OnValueChanged += OnInputChanged;
        }

        private void OnDestroy()
        {
            _input.OnValueChanged -= OnInputChanged;
        }

        private void OnInputChanged(float value)
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