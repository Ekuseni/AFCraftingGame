using System;

namespace Models
{
    public class CraftingProcess
    {
        public event Action<Data.Recipe, float> OnCraftingProgressChanged;
        public event Action<Data.Recipe, bool> OnCraftingFinished;
        
        private readonly Data.Recipe data;
        
        private readonly float adjuestedTime;
        private float timeLeft;
        
        public CraftingProcess(Data.Recipe recipe)
        {
            data = recipe;
            adjuestedTime = recipe.craftTime;
            timeLeft = adjuestedTime;
        }
        
        public void Update(float deltaTime)
        {
            timeLeft -= deltaTime;
            
            OnCraftingProgressChanged?.Invoke(data, timeLeft/adjuestedTime);
            
            if (timeLeft <= 0)
            {
                OnCraftingFinished?.Invoke(data, data.IsCraftingSuccessful());
            }
        }
    }    
}


