using System;
using System.Collections.Generic;

namespace Models
{
    public class Machine
    {
        public Data.Machine data { get; }
        
        public Queue<CraftingProcess> craftingQueue { get; } = new();
        public CraftingProcess currentCraftingProcess { get; set; }

        public Dictionary<Data.Recipe, Recipe> recipes { get; } = new();
        
        public Machine(Data.Machine data)
        {
            this.data = data;
            
            foreach (var recipe in data.recipes)
            {
                recipes.Add(recipe, new Recipe(recipe));
            }
        }
    }

}

