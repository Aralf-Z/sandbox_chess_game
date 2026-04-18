using System;
using System.Collections.Generic;
using GameDev.Core;
using GameDev.Entity;
using Game.Config.Character;

namespace Game
{
    public class SquadSetup: ComponentBase
        , IGetModule
    {
        public TroopInfo troopBelong;
        
        public readonly Dictionary<SquadPos, CharacterInfo> members = new ();
        
        public CharacterInfo this[SquadPos stance] => members.GetValueOrDefault(stance, null);

        public bool Set(int row, int column, CharacterInfo info)
        {
            var tables = this.Module().Config.Tables;
            var bodyType = tables.TbRace[info.subrace].BodyType;
            (int w, int h) rect = bodyType switch
            {
                EmBodyType.Small => (1,1), EmBodyType.Medium => (2,1), EmBodyType.Large => (3,2), EmBodyType.Gargantuan => (6,3),
                _ => throw new NotImplementedException()
            };

            if (!CheckRect(row, column, rect.w, rect.h)) return false;

            for (var i = 0; i < rect.w; i++)
            {
                for (var j = 0; j < rect.h; j++)
                {
                    var c = column + i;
                    var r = row + j;
                    members[new SquadPos(r, c)] = info;
                }
            }

            return true;
            
            bool CheckRect(int r, int c, int w, int h)
            {
                for (var i = 0; i < w; i++)
                {
                    for (var j = 0; j < h; j++)
                    {
                        var rp = r + j;
                        var cp = c + i;
                        if (members.ContainsKey(new SquadPos(rp, cp)))
                            return false;
                    }
                }
                
                return true;
            }
        }
    }
}