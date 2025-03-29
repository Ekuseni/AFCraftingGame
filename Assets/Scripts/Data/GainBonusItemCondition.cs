using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GainBonusItemCondition", menuName = "Scriptable Objects/StartingConditions/GainBonusItemCondition")]
    public class GainBonusItemCondition : StartingCondition
    {
        [SerializeField] private BonusItem item;
        [SerializeField] private GainChance gainItemChance;

        public override void ApplyStartingCondition(GameState gameState)
        {
           gameState.bonusItems[item.id] += gainItemChance.GetGain();
        }
    }    
}


