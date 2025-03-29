using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Objects/QuestData")]
    public class Quest : ScriptableObject
    {
        [SerializeField] private string m_questName;
        [SerializeField] private string m_description;
        [SerializeField] private QuestRequirement[] m_requirements;
        
        public string questName => m_questName;
        public string description => m_description;
        public QuestRequirement[] requirements => m_requirements;
    }
}