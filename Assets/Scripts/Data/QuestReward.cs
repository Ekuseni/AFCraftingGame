using Models;
using UnityEngine;

namespace Data
{
    public abstract class QuestReward : ScriptableObject
    {
        public abstract void ClaimReward(GameState gameState);
    }
}


