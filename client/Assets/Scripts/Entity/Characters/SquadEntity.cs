using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public sealed class SquadEntity: MonoEntityBase
    {
        [SerializeField] private Transform[] characters;
        
        protected override string Tag =>　"Squad";
        
        protected override void Init(int configId)
        {
            
        }

        public void Refresh()
        {
            for (var i = 0; i < Setup.characters.Count; i++)
            {
                var chara =  Setup.characters[i];
                chara.transform.SetParent(characters[i]);
                chara.transform.localScale = Vector3.one;
                chara.transform.localPosition = Vector3.zero;
            }
        }
        
        public Attributes Attribute { get; private set; } = new Attributes();
        public SquadInfo Info { get; private set; } = new SquadInfo();
        public SquadSetup Setup { get; private set; } = new SquadSetup();
        public SquadContext Context { get; private set; } = new SquadContext();
    }
}