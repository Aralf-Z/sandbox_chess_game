using UnityEditor;
using UnityEngine;

namespace FastGameDev.Editor
{
    public abstract class DevConfig<T>: ScriptableObject where T : ScriptableObject
    {
        public static T Instance
        {
            get
            {
                if (sInstance == null)
                {
                    var cfgGuids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
                    switch (cfgGuids.Length)
                    {
                        case 0:
                            sInstance = CreateInstance<T>();
                            AssetDatabase.CreateAsset(sInstance, $"Assets/Editor/FastGameDev/{sInstance.GetType().Name}.asset");
                            break;
                        case 1:
                            sInstance = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(cfgGuids[0]));
                            break;
                        default:
                            throw new DevConfigException("more than one instance of " + typeof(T).Name);
                    }
                }
                
                return sInstance;
            }
        }

        private static T sInstance;
    }
}