using System.Collections.Generic;
using Data;

namespace Models
{
    public class GameState
    {
        public Dictionary<int, Item> inventory { get; private set; } = new();
        public Dictionary<int, BonusItem> bonusItems { get; private set; } = new();

        public List<Machine> machines { get; private set; } = new();
        
        public List<Quest> quests { get; private set; } = new();
        
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

        public void AddItems(RecipeItem[] recipeItems)
        {
            foreach (var recipeItem in recipeItems)
            {
                if (inventory.TryGetValue(recipeItem.item.id, out var item))
                {
                    item.Count += recipeItem.amount;
                }
                else
                {
                    inventory.Add(recipeItem.item.id, new Item(recipeItem.item){Count = recipeItem.amount});
                }
            }
        }
       
    }
}