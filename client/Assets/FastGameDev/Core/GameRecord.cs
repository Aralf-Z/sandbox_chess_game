using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FastGameDev.Helper;
using FastGameDev.Record;
using UnityEngine;

namespace FastGameDev.Core
{
    public class GameRecord: MonoBehaviour
    {
        private Dictionary<Type, RecordBase> mRecords = new Dictionary<Type, RecordBase>();
        
        internal bool IsInited { get; private set; }
        
        internal void Init()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var count = 0;

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes().Where(t => !t.IsAbstract && typeof(RecordBase).IsAssignableFrom(t)))
                {
                    var record = (RecordBase)Activator.CreateInstance(type);
                    record.Init();
                    mRecords.Add(type, record);
                    count++;
                    LogHelper.Info($"create record [{type.FullName}]", "record");
                }
            }
            
            LogHelper.Info($"record loaded {count}.", "record");
            
            IsInited = true;
        }

        internal void Destroy()
        {
            IsInited = false;
        }

        public T Get<T>() where T : RecordBase => mRecords[typeof(T)] as T;
        
#if UNITY_EDITOR

        [UnityEditor.CustomEditor(typeof(GameRecord))]
        public class GameRecordEditor : UnityEditor.Editor
        {
            private GameRecord mRecord;

            private Utility.Inspector.NodeBase mRootNode;
            private Utility.Inspector.Collector mCollector;
        
            private void OnEnable()
            {
                mRecord = (GameRecord)target;
            
                mCollector = new Utility.Inspector.Collector("记录");

                mRootNode = mCollector.Collect(mRecord.mRecords.Values);
            }

            public override void OnInspectorGUI()
            {
                Draw(mRootNode);

                if (GUILayout.Button("Refresh"))
                {
                    mRootNode = mCollector.Collect(mRecord.mRecords.Values);
                }
            }
        
            private void Draw(Utility.Inspector.NodeBase node)
            {
                if (null == node)
                {
                    UnityEditor.EditorGUILayout.LabelField("error node");
                    return;
                }
            
                UnityEditor.EditorGUILayout.LabelField($"{Pre(node.depth)}{node.adapter.Content(node)}");

                foreach (var child in node.children)
                {
                    Draw(child);
                }
            }
        
            private string Pre(int depth)
            {
                return depth switch
                {
                    0 => "",
                    1 => "-> ",
                    2 => "-----> ",
                    3 => "---------> ",
                    4 => "-------------> ",
                    5 => "------------------> ",
                    _ => "----------------------> ",
                };
            }
        }
    
#endif
    }
}