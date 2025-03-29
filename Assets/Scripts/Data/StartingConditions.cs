using Data;
using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "StartingConditions", menuName = "Scriptable Objects/StartingConditions/StartWith")]
    public class StartingConditions : ScriptableObject
    {
        [SerializeField] private StartingCondition[] m_conditions;
    
    
        public void ApplyStartingConditions(GameState gameState)
        {
            foreach (var condition in m_conditions)
            {
                condition.ApplyStartingCondition(gameState);
            }
        }
    }

}

