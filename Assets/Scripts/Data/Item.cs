using UnityEngine;

namespace Data
{
    //Hand added enum value in case of future removal of the ItemType enum
    //this will prevent serialization breaking hence unity serializes enum by int value
    public enum ItemType
    {
        Resource = 0,
        Crafted = 1
    }
    
    [CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite m_icon;
        [SerializeField] private int m_id;
        //Name and description should be a localized string as soon as possible
        [SerializeField] private string m_itemName;
        [SerializeField] private string m_description;
        [SerializeField] private ItemType m_type;
        
        public Sprite icon => m_icon;
        public int id => m_id;
        public string itemName => m_itemName;
        public string description => m_description;
        public ItemType type => m_type;
        
    }    
}


