using System;
using GameDev.Entity;

namespace Game
{
    public class SquadBattleAspect
    {
        public readonly Attribute attri;
        public readonly Resources res;
        public readonly SquadInfo info;
        public readonly SquadContext ctx;

        public SquadBattleAspect(EntityBase en)
        {
            attri = en.Get<Attribute>();
            res = en.Get<Resources>();
            info = en.Get<SquadInfo>();
            ctx = en.Get<SquadContext>();
        }
    }
    
    public class CharacterBattleAspect
    {
        public readonly Attribute attri;
        public readonly Resources res;
        public readonly CharacterInfo info;

        public CharacterBattleAspect(EntityBase en)
        {
            attri = en.Get<Attribute>();
            res = en.Get<Resources>();
            info = en.Get<CharacterInfo>();
        }
    }
}