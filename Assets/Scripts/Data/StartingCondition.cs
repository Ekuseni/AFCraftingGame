using Models;
using UnityEngine;

namespace Data
{
    public abstract class StartingCondition : ScriptableObject
    {
        public abstract void ApplyStartingCondition(GameState gameState);
    }    
}


