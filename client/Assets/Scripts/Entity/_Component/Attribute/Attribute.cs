using System;
using System.Collections.Generic;
using GameDev.Entity;
using GameDev.Helper;
using GameDev.Utility.Value;

namespace Game
{
    /// <summary>
    /// 获得属性是固定的，如果是资源属性则返回其上限
    /// </summary>
    public class Attribute: ComponentBase
    {
        /// <summary> key, preValue, nextValue </summary>
        public event Action<string, float, float> Evt_OnValueChange;

        /// <summary> key, preValue, nextValue </summary>
        public event Action<string, float, float> Evt_OnRatioChange;
        
        private readonly Dictionary<string, SumValue> mAttri = new ();
        
        public float this[string attributeName] => mAttri[attributeName].Value;
        
        public int Int(string attributeName) => mAttri[attributeName].Value.Floor();
        
        public float Float(string attributeName) => mAttri[attributeName].Value;
        
        public void Add(string attributeName, float baseValue) => mAttri.Add(attributeName, new SumValue(baseValue));

        public void Remove(string attributeName) => mAttri.Remove(attributeName);
        
        public void AddValue(string attributeName, SourceValue value)
        {
            var pack = mAttri[attributeName];
            var pre = pack.Value;
            pack.Add(value);
            Evt_OnValueChange?.Invoke(attributeName, pre, pack.Value);
        }

        public void RemoveValue(string attributeName, SourceValue value)
        {
            var pack = mAttri[attributeName];
            var pre = pack.Value;
            pack.Remove(value);
            Evt_OnValueChange?.Invoke(attributeName, pre, pack.Value);
        }
        
        public void AddRatio(string attributeName, SourceValue value)
        {
            var pack = mAttri[attributeName];
            var pre = pack.Value;
            pack.AddRatio(value);
            Evt_OnRatioChange?.Invoke(attributeName, pre, pack.Value);
        }

        public void RemoveRatio(string attributeName, SourceValue value)
        {
            var pack = mAttri[attributeName];
            var pre = pack.Value;
            pack.RemoveRatio(value);
            Evt_OnRatioChange?.Invoke(attributeName, pre, pack.Value);
        }
        
        public static int CalculateModifier(int value) => (value - 10) / 2;
    }
}