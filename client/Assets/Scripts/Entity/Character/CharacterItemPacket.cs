using System.Collections.Generic;

namespace Game
{
    public class CharacterItemPacket: IItemPacket
    {
        public EquipmentGroup EquipmentGroup { get; set; }
        
        public CharacterItemPacket(int mainHand, int offHand, int body, IEnumerable<int> artifacts)
        {
            //todo 奇物栏
            EquipmentGroup = new EquipmentGroup(){mainHand = mainHand, offHand = offHand, body = body};
        } 
        
        public void SetArtifact(int index, int id)
        {
            throw new System.NotImplementedException();
        }

        public int GetArtifact(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}