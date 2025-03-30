using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnlockMachineReward", menuName = "Scriptable Objects/UnlockMachineReward")]
    public class UnlockMachineReward : QuestReward
    {
        [SerializeField] private Machine m_machine;
    
        public override void ClaimReward(GameState gameState)
        {
            gameState.UnlockMachine(m_machine);
        }
    }

}

