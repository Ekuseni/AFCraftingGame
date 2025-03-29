using System.Collections.Generic;

namespace Models
{
    public class GameState
    {
        public Dictionary<int,int> inventory { get; private set; }
        public Dictionary<int,int> bonusItems { get; private set; }
        
        public float craftingTimeModifier { get; private set; }
        public float successRateModifier { get; private set; }
        
        public void ChangeCraftingTimeModifier(float amount)
        {
            craftingTimeModifier += amount;
        }
        
        public void ChangeSuccessRateModifier(float amount)
        {
            successRateModifier += amount;
        }
    }
}