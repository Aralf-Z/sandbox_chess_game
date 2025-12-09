using System.Collections.Generic;

namespace Game
{
    public interface IItemPacket
    {
        EquipmentGroup EquipmentGroup { get; set; }

        void SetArtifact(int index, int id);
        int GetArtifact(int index);
    }
    public interface IHaveItemPacket
    {
        IItemPacket ItemPacket{ get; }
    }
}