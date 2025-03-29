using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CraftItemRequirement", menuName = "Scriptable Objects/QuestRequirement/CraftItemRequirement")]
    public class CraftItemRequirement : QuestRequirement
    {
        [SerializeField] private Item m_itemToCraft;
        [SerializeField] private int m_amountToCraft;
        
        public override bool CheckRequirement(GameState gameState)
        {
            if(gameState.inventory.TryGetValue(m_itemToCraft.id, out var model))
            {
                return model.Count >= m_amountToCraft;
            }
            
            return false;
        }
    }
}