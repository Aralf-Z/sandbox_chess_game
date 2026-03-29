using GameDev.Utility.Inspector;
using UnityEngine;

namespace GameDev.Note
{
    [Inspectable]
    public abstract class NoteBase
    {
        protected internal abstract void Init();
    }
}