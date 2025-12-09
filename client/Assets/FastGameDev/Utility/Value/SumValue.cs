using System.Collections.Generic;

namespace FastGameDev.Value
{
    /// <summary>
    /// 总值
    /// </summary>
    public class SumValue
    {
        public float Value { get; private set; }

        public float BaseValue { get;}
        
        public IEnumerable<SourceValue> Values => mSourceValues;

        private HashSet<SourceValue> mSourceValues;

        public SumValue(float value)
        {
            BaseValue = Value = value;
        }
        
        public void Add(SourceValue value)
        {
            mSourceValues.Add(value);
            Value += value.Value;
        }

        public void Remove(SourceValue value)
        {
            mSourceValues.Remove(value);
            Value -= value.Value;
        }
        
        //todo ToString
    }
}