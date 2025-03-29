using Models;
using UnityEngine;

namespace Data
{
    public abstract class BonusItemEffect : ScriptableObject
    {
        public abstract void ApplyBonusEffect(GameState gameState);
    }   
}
