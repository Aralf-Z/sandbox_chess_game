using System.Collections.Generic;
using FastGameDev.Entity;
using FastGameDev.Utility.Value;
using UnityEngine;

namespace Game
{
    public class Resources: ComponentBase
    {
        private readonly Dictionary<string, ResPack> mRes = new();
        
        public (float max, float cur) this[string resourceName]
        {
            get
            {
                var pack = mRes[resourceName];
                return (pack.max.Value, pack.curValue);
            }
        }
        
        public float GetMax(string resourceName) => mRes[resourceName].max.Value;
        
        public float GetCur(string resourceName) => mRes[resourceName].curValue;

        public void Add(string resourceName, float baseValue) => mRes.Add(resourceName, new ResPack(baseValue));

        public void Remove(string resourceName) => mRes.Remove(resourceName);
        
        public void AddValue(string resourceName, SourceValue value) => mRes[resourceName].max.Add(value);

        public void RemoveValue(string resourceName, SourceValue value) => mRes[resourceName].max.Remove(value);
        
        public void AddRatio(string resourceName, SourceValue value) => mRes[resourceName].max.AddRatio(value);

        public void RemoveRatio(string resourceName, SourceValue value) => mRes[resourceName].max.RemoveRatio(value);
        
        public void Recover(string resourceName)
        {
            mRes[resourceName].curValue = mRes[resourceName].max.Value;
        }
        
        /// <returns> 恢复溢出值 </returns>
        public float Change(string resourceName, float value)
        {
            var pack = mRes[resourceName];
            var tarValue = pack.curValue + value;
            var overflow = pack.max.Value >= tarValue ? 0 : tarValue - value;
            
            pack.curValue = Mathf.Clamp(tarValue, 0, pack.max.Value);
            return overflow;
        }
        
        private class ResPack
        {
            public readonly SumValue max;
            public float curValue;

            public ResPack(float value)
            {
                max = new SumValue(value);
                curValue = value;
            }
        }
    }
}