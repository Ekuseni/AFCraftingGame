using System;
using System.Collections.Generic;

namespace Models
{
    public class Machine
    {
        public Data.Machine data { get; }
        
        
        private Queue<CraftingProcess> craftingQueue { get; } = new();
        public CraftingProcess currentCraftingProcess { get; private set; }

        public Dictionary<Data.Recipe, Recipe> recipes { get; } = new();
        
        public event Action<Queue<CraftingProcess>> OnQueueChanged; 
        
        public Machine(Data.Machine data)
        {
            this.data = data;
            
            foreach (var recipe in data.recipes)
            {
                recipes.Add(recipe, new Recipe(recipe));
            }
        }
        
        public void Enqueue(CraftingProcess process)
        {
            if (currentCraftingProcess == null)
            {
                currentCraftingProcess = process;
            }
            else
            {
                craftingQueue.Enqueue(process);
                OnQueueChanged?.Invoke(craftingQueue);
            }
        }
        
        public void Dequeue()
        {
            if (craftingQueue.Count > 0)
            {
                currentCraftingProcess = craftingQueue.Dequeue();
                OnQueueChanged?.Invoke(craftingQueue);
            }
            else
            {
                currentCraftingProcess = null;
            }
        }

        public void UpdateQueue()
        {
            OnQueueChanged?.Invoke(craftingQueue);
        }
        
    }
}

