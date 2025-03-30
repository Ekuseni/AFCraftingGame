using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MachineSidepanel : MonoBehaviour
    {
        [SerializeField] private Image m_image;
        [SerializeField] private TextMeshProUGUI m_nameText;
        [SerializeField] private Slider m_slider;
        [SerializeField] private Button m_button;
        [SerializeField] private CanvasGroup m_canvasGroup;
        [SerializeField] private CanvasGroup m_sliderCanvasGroup;
        
        private Action<float> m_onUpdateCallback;
        
        public void SetupMachineView(Models.Machine machine, Action onClick, Action<float> onUpdateCallback)
        {
            m_image.sprite = machine.data.icon;
            m_nameText.text = machine.data.machineName;
            m_sliderCanvasGroup.alpha = 0;
            m_canvasGroup.interactable = machine.data.isUnlocked;
            m_canvasGroup.alpha = machine.data.isUnlocked ? 1 : 0.5f;
            m_button.onClick.AddListener(() => onClick?.Invoke());
            
            m_onUpdateCallback = onUpdateCallback;
        }

        public void Update()
        {
            m_onUpdateCallback?.Invoke(Time.deltaTime);
        }
        
        public void UpdateProgress(float progress)
        {
            m_sliderCanvasGroup.alpha = 1;
            m_slider.value = progress;
        }
        
        public void HideProgress()
        {
            m_sliderCanvasGroup.alpha = 0;
        }

        public void Unlock()
        {
            m_canvasGroup.alpha = 1;
            m_canvasGroup.interactable = true;
        }
    }
}


