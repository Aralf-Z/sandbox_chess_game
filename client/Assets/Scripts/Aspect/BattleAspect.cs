using System;

namespace Game
{
    public class SquadBattleAspect
    {
        public Attribute attri;
        public Resources res;
        public SquadInfo info;
        public SquadContext ctx;

        public SquadBattleAspect(Entity en)
        {
            attri = en.Get<Attribute>();
            res = en.Get<Resources>();
            info = en.Get<SquadInfo>();
            ctx = en.Get<SquadContext>();
        }
    }
}