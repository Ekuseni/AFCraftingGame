using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ReduceCraftingTime", menuName = "Scriptable Objects/BonusItemEffects/ReduceCraftingTime")]
    public class ReduceCraftingTime : BonusItemEffect
    {
        [SerializeField] private float m_reductionAmount;
        
        public override void ApplyBonusEffect(GameState gameState)
        {
            gameState.ChangeCraftingTimeModifier(-m_reductionAmount);
        }
    }    
}


