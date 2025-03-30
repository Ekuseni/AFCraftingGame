using System;

namespace Models
{
    public class CraftingProcess
    {
        public event Action<Data.Recipe, float> OnCraftingProgressChanged;
        public event Action<Data.Recipe, bool> OnCraftingFinished;
        public Data.Recipe data { get; }

        private readonly float adjuestedTime;
        private float timeLeft;
        private GameState gameState;
        
        public CraftingProcess(Data.Recipe recipe, GameState gameState)
        {
            data = recipe;
            adjuestedTime = recipe.craftTime - gameState.craftingTimeModifier;
            timeLeft = adjuestedTime;
            this.gameState = gameState;
        }
        
        public void Update(float deltaTime)
        {
            timeLeft -= deltaTime;
            
            OnCraftingProgressChanged?.Invoke(data, timeLeft/adjuestedTime);
            
            if (timeLeft <= 0)
            {
                OnCraftingFinished?.Invoke(data, data.IsCraftingSuccessful(gameState));
            }
        }
    }    
}


