using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "IncreaseSuccessRate", menuName = "Scriptable Objects/BonusItemEffects/IncreaseSuccessRate")]
    public class IncreaseSuccessRate : BonusItemEffect
    {
        [SerializeField] private float m_increaseAmount;
        
        public override void ApplyBonusEffect(GameState gameState)
        {
            gameState.ChangeSuccessRateModifier(m_increaseAmount);
        }
    }
}