using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CraftItemRequirement", menuName = "Scriptable Objects/QuestRequirement/CraftItemRequirement")]
    public class CraftItemRequirement : QuestRequirement
    {
        [SerializeField] private Item m_itemToCraft;
        [SerializeField] private int m_amountToCraft;

        public override QuestProgress GetQuestProgress(GameState gameState)
        {
            return new CraftItemProgress(m_amountToCraft, gameState.inventory[m_itemToCraft.id]);
        }
    }
}