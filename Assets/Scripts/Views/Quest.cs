using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class Quest : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI m_nameText;
        [SerializeField] private TextMeshProUGUI m_descriptionText;
        [SerializeField] private Slider m_slider;
        
        public void InitializeQuestView(Models.Quest quest)
        {
            m_nameText.text = quest.data.questName;
            m_descriptionText.text = quest.data.description;
        }
        
        public void UpdateProgress(float progress)
        {
            m_slider.value = progress;
        }
    }
}


