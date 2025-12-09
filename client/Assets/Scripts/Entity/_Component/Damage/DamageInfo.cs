namespace Game
{
    public struct DamageInfo
    {
        public float acid;
        public float fire;
        public float lightning;
        public float poison;
        public float bludgeoning;
        public float piercing;
        public float slashing;
        /// <summary>
        /// 命中骰
        /// </summary>
        public int attackRoll;
        /// <summary>
        /// 命中加值
        /// </summary>
        public int attackBonus;
        
        //todo attacker & defender
        
        // public IAbility attacker;
        // public IResource defender;
    }
}