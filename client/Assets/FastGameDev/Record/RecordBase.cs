using FastGameDev.Utility.Inspector;
using UnityEngine;

namespace FastGameDev.Record
{
    [Inspectable]
    public abstract class RecordBase
    {
        protected internal abstract void Init();
    }
}