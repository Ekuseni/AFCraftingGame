using System;
using Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MachineView : MonoBehaviour
    {
        [SerializeField] private Image m_image;
        [SerializeField] private TextMeshProUGUI m_nameText;
        [SerializeField] private Slider m_slider;
        [SerializeField] private Button m_button;
        [SerializeField] private CanvasGroup m_canvasGroup;
        
        public void SetupMachineView(Machine machine, Action onClick)
        {
            m_image.sprite = machine.icon;
            m_nameText.text = machine.machineName;
            m_slider.gameObject.SetActive(false);
            m_canvasGroup.interactable = machine.isUnlocked;
            m_canvasGroup.alpha = machine.isUnlocked ? 1 : 0.5f;
            m_button.onClick.AddListener(() => onClick?.Invoke());
        }
    }
}


