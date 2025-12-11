using System.Collections.Generic;

namespace Game
{
    public interface ISquads
    {
        List<SquadEntity> AllSquads { get; }
    }

    public interface IHaveSquads
    {
        ISquads Squads { get; }
    }
}