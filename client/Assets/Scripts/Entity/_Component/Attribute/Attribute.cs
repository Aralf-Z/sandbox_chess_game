using System.Collections.Generic;
using FastGameDev.Entity;
using FastGameDev.Utility.Value;

namespace Game
{
    public class Attribute: ComponentBase
    {
        private readonly Dictionary<string, SumValue> mAttri;
        
        public float this[string attributeName] => mAttri[attributeName].Value;
        
        public void Add(string attributeName, float baseValue) => mAttri.Add(attributeName, new SumValue(baseValue));

        public void Remove(string attributeName) => mAttri.Remove(attributeName);
        
        public void AddValue(string attributeName, SourceValue value) => mAttri[attributeName].Add(value);

        public void RemoveValue(string attributeName, SourceValue value) => mAttri[attributeName].Remove(value);
        
        public void AddRatio(string attributeName, SourceValue value) => mAttri[attributeName].AddRatio(value);

        public void RemoveRatio(string attributeName, SourceValue value) => mAttri[attributeName].RemoveRatio(value);
        
        public static int CalculateModifier(int value) => (value - 10) / 2;
    }
}