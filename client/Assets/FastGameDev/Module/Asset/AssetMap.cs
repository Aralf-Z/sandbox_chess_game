using System.Collections.Generic;

namespace FastGameDev.Module
{
    public class AssetMap
    {
        public readonly Dictionary<string, string> mNamePathDic = new();

        public string this[string key] => mNamePathDic[key];
        
        public void Add(string name, string path)
        {
            mNamePathDic[name] = path;
        }

        public void Remove(string name, string path)
        {
            if(!mNamePathDic.ContainsKey(name))
            {mNamePathDic.Remove(name);}
        }

        public bool Contains(string name)
        {
            return mNamePathDic.ContainsKey(name);
        }
    }
}