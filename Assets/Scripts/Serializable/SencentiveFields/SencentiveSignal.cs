namespace Assets.Scripts.Serializable.SencentiveFields
{
    [System.Serializable]
    public class SencentiveSignal : SencentiveField<Signal3>
    {
        public SencentiveSignal(int sensitivity = 3) : base(Signal3.None, sensitivity)
        {
        }

        protected override bool Compare(Signal3 value)
        {
            return value == Signal3.None;
        }
    }
}