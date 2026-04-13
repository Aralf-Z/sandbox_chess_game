using System.Collections.Generic;
using GameDev.Entity;
using GameDev.Helper;
using GameDev.Utility.Value;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 资源，是可恢复的
    /// </summary>
    public class Resources: ComponentBase
    {
        public Attribute Max {get; private set; }
        
        private readonly Dictionary<string, ResPack> mRes = new();
        
        public float this[string resourceName] => mRes[resourceName].value;
        
        public int Int(string resourceName) => mRes[resourceName].value.Floor();
        
        public float Float(string resourceName) => mRes[resourceName].value;

        public void Add(string resourceName, float value, bool overflowable = false, bool changeOnMaxChanged = true) 
            => mRes.Add(resourceName, new ResPack(resourceName, value, overflowable, changeOnMaxChanged));

        public void Remove(string resourceName) => mRes.Remove(resourceName);
        
        public void Recover(string resourceName)
        {
            mRes[resourceName].value = Max[resourceName];
        }

        protected override void OnAdded()
        {
            Max = Host.GetOrAdd<Attribute>();
            Max.Evt_OnValueChange += OnMaxValueChange;
            Max.Evt_OnRatioChange += OnMaxRatioChange;
        }
        
        public void Change(string resourceName, float value)
        {
            var pack = mRes[resourceName];
            var tarValue = pack.value + value;
            pack.value = pack.overflowable
                ? tarValue 
                : Mathf.Clamp(tarValue, 0, Max[resourceName]);
        }

        private void OnMaxValueChange(string key, float preValue, float nextValue)
        {
            if (mRes.TryGetValue(key, out var pack) && pack.changeOnMaxChanged)
            {
                pack.value += nextValue - preValue;
            }
        }

        private void OnMaxRatioChange(string key,float preValue, float nextValue)
        {
            if (mRes.TryGetValue(key, out var pack) && pack.changeOnMaxChanged)
            {
                pack.value += nextValue - preValue;
            }
        }
        
        private class ResPack
        {
            public readonly string key;
            public float value;
            public readonly bool overflowable;
            public readonly bool changeOnMaxChanged;

            public ResPack(string key, float value, bool overflowable = false, bool changeOnMaxChanged = true)
            {
                this.key = key;
                this.value = value;
                this.overflowable = overflowable;
                this.changeOnMaxChanged = changeOnMaxChanged;
            }
        }
    }
}