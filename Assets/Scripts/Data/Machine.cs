using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "MachineData", menuName = "Scriptable Objects/MachineData")]
    public class Machine : ScriptableObject
    {
        [SerializeField] private Sprite m_icon;
        [SerializeField] private string m_machineName;
        [SerializeField] private string m_description;
        [SerializeField] private Recipe[] m_recipes;
        [SerializeField] private bool m_isUnlocked;
        
        public Sprite icon => m_icon;
        public string machineName => m_machineName;
        public string description => m_description;
        public Recipe[] recipes => m_recipes;
        public bool isUnlocked => m_isUnlocked;
    }
}