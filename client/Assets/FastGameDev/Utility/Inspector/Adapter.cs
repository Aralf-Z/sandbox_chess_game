using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FastGameDev.Utility.Inspector
{
    public abstract class Adapter
    {
        public abstract bool CanHandle(Type type);
        public abstract string Content(NodeBase node);
        public abstract void Search(NodeBase node, int childDepth);
    }
    
    public class NodeAdapter: Adapter
    {
        public override bool CanHandle(Type type) => true;

        public override string Content(NodeBase node)
        { 
            return $"{node.name}<{node.tag}> ";
        }

        public override void Search(NodeBase node, int childDepth)
        {
            if (node is FieldNode or RootNode)
            {
                var obj = node is FieldNode ? node.GetValue() : ((RootNode)node).instance;
                var type = obj.GetType();
                var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            
                foreach (var field in fields)
                {
                    var fieldNode = new FieldNode
                    {
                        parent = node,
                        info = field, 
                        owner = obj,
                        name = field.Name,
                        depth = childDepth,
                    };
                
                    node.children.Add(fieldNode);
                }
            }
            else
            {
                throw new Exception("invalid node, only class or struct is supported.");
            }
        }
    }
    
    public class IntAdapter: Adapter
    {
        public override bool CanHandle(Type type) => type == typeof(int);
        
        public override string Content(NodeBase node)
        {
            return $"{node.name}: {node.GetValue()}";
        }

        public override void Search(NodeBase node, int childDepth) { }
    }
    
    public class FloatAdapter: Adapter
    {
        public override bool CanHandle(Type type) => type == typeof(float);
        
        public override string Content(NodeBase node)
        {
            return $"{node.name}: {node.GetValue()}";
        }

        public override void Search(NodeBase node, int childDepth) { }
    }
    
    public class BoolAdapter: Adapter
    {
        public override bool CanHandle(Type type) => type == typeof(bool);
        
        public override string Content(NodeBase node)
        {
            return $"{node.name}: {node.GetValue()}";
        }

        public override void Search(NodeBase node, int childDepth) { }
    }
    
    public class StringAdapter: Adapter
    {
        public override bool CanHandle(Type type) => type == typeof(string);
        
        public override string Content(NodeBase node)
        {
            return $"{node.name}: {node.GetValue()}";
        }

        public override void Search(NodeBase node, int childDepth) { }
    }

    public class ListAdapter : Adapter
    {
        public override bool CanHandle(Type type)
        {
            if (type.IsArray) return true;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>)) return true;
            
            return false;
        }

        public override string Content(NodeBase node)
        {
            return $"{node.name}[]: ";
        }

        public override void Search(NodeBase node, int childDepth)
        {
            var value = node.GetValue();
            var list = value as IList;
            
            if (list == null) return;
            
            for (var i = 0; i < list.Count; i++)
            {
                var leaf = new ListElementLeaf()
                {
                    parent = node,
                    owner = list,
                    index = i,
                    collection = list,
                    name = $"[{i}]",
                    depth = childDepth,
                };
                
                node.children.Add(leaf);
            }
        }
    }
    
    public class DictionaryAdapter : Adapter
    {
        public override bool CanHandle(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        
        public override string Content(NodeBase node)
        {
            return  $"{node.name}[k,v]: ";
        }

        public override void Search(NodeBase node, int childDepth)
        {
            var value = node.GetValue();
            var map = value as IDictionary;
            
            if (map == null) return;

            foreach (DictionaryEntry entry in map)
            {
                var leaf = new DictionaryElementLeaf()
                {
                    parent = node,
                    owner = map,
                    key = entry.Key,
                    collection = map,
                    name = $"[{entry.Key}]",
                    depth = childDepth,
                };
                
                node.children.Add(leaf);
            }
        }
    }
}