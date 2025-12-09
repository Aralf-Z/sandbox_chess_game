namespace FastGameDev.Value
{
    public class SourceValue
    {
        public string Name { get; private set; }
        public float Value { get; private set; }

        public SourceValue(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public SourceValue(string name, float value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{(Value >= 0 ? "+" : "-")}{Value} [{Name}]";
        }
        
        public string ToPercentString()
        {
            return $"{(Value >= 0 ? "+" : "-")}{Value * 100}% [{Name}]";
        }

        public string ToIntString()
        {
            var value = (int)Value;
            return $"{(value >= 0 ? "+" : "-")}{value} [{Name}]";
        }
    }
}