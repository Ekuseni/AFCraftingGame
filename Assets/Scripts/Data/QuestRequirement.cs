using Models;
using UnityEngine;

namespace Data
{
    public abstract class QuestRequirement : ScriptableObject
    {
        public abstract QuestProgress GetQuestProgress(GameState gameState);
    }

}

