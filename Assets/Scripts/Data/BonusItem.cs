using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "BonusItem", menuName = "Scriptable Objects/BonusItemData")]
    public class BonusItem : ScriptableObject
    {
        [SerializeField] private Sprite m_icon;
        [SerializeField] private int m_id;
        [SerializeField] private string m_itemName;
        [SerializeField] private string m_description;
        [SerializeField] private BonusItemEffect[] m_effects;
        
        public Sprite icon => m_icon;
        public int id => m_id;
        public string itemName => m_itemName;
        public string description => m_description;
        public BonusItemEffect[] effects => m_effects;
    }
    
}

