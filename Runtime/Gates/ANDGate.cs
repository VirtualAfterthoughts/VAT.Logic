using UnityEngine;

namespace VAT.Logic
{
    public class ANDGate : Node
    {
        [SerializeField]
        private Node[] _inputs = new Node[0];

        protected override void OnReadInputs(float deltaTime)
        {
            base.OnReadInputs(deltaTime);

            float minimum = 0f;
            bool hasInput = false;

            foreach (var input in _inputs)
            {
                if (!hasInput)
                {
                    minimum = input.Value;
                    hasInput = true;
                    continue;
                }

                minimum = Mathf.Min(minimum, input.Value);
            }

            Value = minimum;
        }
    }
}