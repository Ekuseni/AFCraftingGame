using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GainItemCondition", menuName = "Scriptable Objects/StartingConditions/GainItemCondition")]
    public class GainItemCondition : StartingCondition
    {
        [SerializeField] private Item item;
        [SerializeField] private GainChance gainItemChance;

        public override void ApplyStartingCondition(GameState gameState)
        {
           gameState.inventory[item.id] += gainItemChance.GetGain();
        }
    }    
}


