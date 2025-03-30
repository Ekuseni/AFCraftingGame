using System.Linq;
using Data;
using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ItemDataBase", menuName = "Scriptable Objects/ItemDataBase")]
    public class ItemDataBase : ScriptableObject
    {
        //Should add id sanity check
        [SerializeField] private Item[] m_items;
        [SerializeField] private BonusItem[] m_bonusItems;
        
        public Item GetItemById(int id)
        {
           return m_items.FirstOrDefault(item => item.id == id);
        }
        
        public BonusItem GetBonusItemById(int id)
        {
            return m_bonusItems.FirstOrDefault(item => item.id == id);
        }
        
        
        public void BuildInventory(GameState gameState)
        {
            foreach (var item in m_items)
            {
                if (!gameState.inventory.TryAdd(item.id, new Models.Item(item)))
                {
                    throw new System.Exception($"Item with id {item.id} already exists in inventory");
                }
            }
            
            foreach (var bonusItem in m_bonusItems)
            {
                if (!gameState.bonusItems.TryAdd(bonusItem.id,  new Models.BonusItem(bonusItem)))
                {
                    throw new System.Exception($"BonusItem with id {bonusItem.id} already exists in bonusItems");
                }
            }
        }
    }
    
}

