using System;

using UnityEngine;

namespace VAT.Logic
{
    [Serializable]
    public class Threshold
    {
        public enum ThresholdPulse
        {
            IDLE,
            HIGH,
            LOW,
        }

        [SerializeField]
        private float _lowThreshold = 0.1f;

        [SerializeField]
        private float _highThreshold = 0.9f;

        private bool _state = false;

        public bool State => _state;

        public ThresholdPulse SendInput(float value)
        {
            if (value >= _highThreshold && !_state)
            {
                _state = true;
                return ThresholdPulse.HIGH;
            }
            else if (value <= _lowThreshold && _state)
            {
                _state = false;
                return ThresholdPulse.LOW;
            }

            return ThresholdPulse.IDLE;
        }
    }
}