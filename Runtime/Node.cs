using System;

using UnityEngine;

namespace VAT.Logic
{
    public abstract class Node : MonoBehaviour
    {
        private float _value = 0f;
        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;

                OnValueChanged?.Invoke(value);
            }
        }

        public event Action<float> OnValueChanged;

        private void Update()
        {
            OnReadInputs(Time.deltaTime);

            OnWriteOutputs(Time.deltaTime);
        }

        protected virtual void OnReadInputs(float deltaTime) { }

        protected virtual void OnWriteOutputs(float deltaTime) { }
    }
}