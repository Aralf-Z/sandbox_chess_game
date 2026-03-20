using FastGameDev.Utility.Inspector;
using UnityEngine;

namespace FastGameDev.Note
{
    [Inspectable]
    public abstract class NoteBase
    {
        protected internal abstract void Init();
    }
}