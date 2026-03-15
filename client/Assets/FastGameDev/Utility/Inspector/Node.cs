using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FastGameDev.Utility.Inspector
{
    public abstract class NodeBase
    {
        public NodeBase parent;
        public object owner;
        public Type type;//todo 添加Type
        public string tag;
        public string name;
        public int depth;
        public Adapter adapter;

        public abstract object GetValue();
        public abstract void SetValue(object value);
        
        public readonly List<NodeBase> children = new();
    }

    public class RootNode : NodeBase
    {
        public object instance;

        public override object GetValue() => instance;

        public override void SetValue(object value) {}
    }
    
    public class FieldNode: NodeBase
    {
        public FieldInfo info;

        public override object GetValue() => info.GetValue(owner);

        public override void SetValue(object value) => info.SetValue(owner, value);
    }
    
    public abstract class CollectionElementLeaf<T> : NodeBase
    {
        public T collection;
    }

    public class ListElementLeaf : CollectionElementLeaf<IList>
    {
        public int index;

        public override object GetValue() => collection[index];

        public override void SetValue(object value) => collection[index] = value;
    }
    
    public class DictionaryElementLeaf : CollectionElementLeaf<IDictionary>
    {
        public object key;

        public override object GetValue() => collection[key];

        public override void SetValue(object value) => collection[key] = value;
    }
}