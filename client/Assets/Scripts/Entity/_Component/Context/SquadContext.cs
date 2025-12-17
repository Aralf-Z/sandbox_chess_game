using System.Collections.Generic;
using FastGameDev.Core;
using Game.Config.Character;

namespace Game
{
    public class SquadContext: IGetModule
    {
        private readonly Dictionary<GridPoint, CharacterEntity> mCharacters = new Dictionary<GridPoint, CharacterEntity>();

        public CharacterEntity this[GridPoint point]
        {
            get => mCharacters.GetValueOrDefault(point, null);
            set => mCharacters[point] = value;
        }
        
        public GridPoint gridPoint;
        
         public bool SetCharacter(int row, int column, CharacterEntity character)
        {
            var point = Rc2Point(row, column);

            if (CheckPosition(point, character))
            {
                var table = this.Module().Config.Tables.TbSubrace[character.Info.subrace];
                var bodyType = table.BodyType;
                
                switch (bodyType)
                {
                    case EmBodyType.Small: SetRect(point.X, point.Y, 1, 2, character); break;//1*2
                    case EmBodyType.Medium: SetRect(point.X, point.Y, 2, 2, character); break;//2*2
                    case EmBodyType.Large: SetRect(point.X, point.Y-2, 3, 4, character); break;//3*4
                    case EmBodyType.Gargantuan: SetRect(point.X, point.Y-4, 6, 6, character); break;//6*6
                }
                
                return true;
            }
            
            return false;
        }
        
        private static GridPoint Rc2Point(int row, int column)
        {
            return row switch
            {
                1 => new GridPoint(column, 5),
                2 => new GridPoint(column, 3),
                3 => new GridPoint(column, 1),
                _ => new GridPoint(0,0),
            };
        }
        
        private bool CheckPosition(GridPoint point, CharacterEntity host)
        {
            var table = this.Module().Config.Tables.TbSubrace[host.Info.subrace];
            var bodyType = table.BodyType;

            return bodyType switch
            {
                EmBodyType.Small => CheckRect(point.X, point.Y, 1, 2),//1*2
                EmBodyType.Medium => CheckRect(point.X, point.Y, 2, 2),//2*2
                EmBodyType.Large => CheckRect(point.X, point.Y-2, 3, 4),//3*4
                EmBodyType.Gargantuan => CheckRect(point.X, point.Y-4, 6, 6),//6*6
                _ => false
            };
        }
        
        private bool CheckRect(int x, int y, int w, int h)
        {
            for (var i = 0; i < w; i++)
            {
                for (var j = 0; j < h; j++)
                {
                    if (Check(i + x, j + y))
                    {
                        return false;
                    } 
                }
            }

            return true;

            bool Check(int xp, int yp) =>  mCharacters.TryGetValue(new GridPoint(xp, yp), out var id) && id != null;
        }
        
        private void SetRect(int x, int y, int w, int h, CharacterEntity character)
        {
            for (var i = 0; i < w; i++)
            {
                for (var j = 0; j < h; j++)
                {
                    var xp = x + i;
                    var yp = y + j;
                    mCharacters[new GridPoint(xp, yp)] = character;
                }
            }
        }
    }
}