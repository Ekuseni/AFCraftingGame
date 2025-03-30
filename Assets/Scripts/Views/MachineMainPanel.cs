using System;
using System.Collections.Generic;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MachineMainPanel : MonoBehaviour
    {
        [SerializeField] private GameObject machinePanel;
        [SerializeField] private Button machinePanelCloseButton;
        [SerializeField] private Image machineImage;
        [SerializeField] private TextMeshProUGUI machineNameText;
        [SerializeField] private TextMeshProUGUI machineDescriptionText;
        
        [SerializeField] private Recipe[] recipes;
        [SerializeField] private Queue queue;
        
        private Machine m_currentMachine;
        
        private void Start()
        {
            machinePanelCloseButton.onClick.AddListener(() =>
            {
                machinePanel.SetActive(false);
            });
        }
        
        public void DisplayMachine(Machine machine, Action<Data.Recipe> onCraftClicked)
        {
            if (m_currentMachine == machine) return;
            
            if (m_currentMachine != null)
            {
                m_currentMachine.OnQueueChanged -= UpdateQueue;
            }
            
            m_currentMachine = machine;
            
            machinePanel.SetActive(true);
            machineImage.sprite = machine.data.icon;
            machineNameText.text = machine.data.machineName;
            machineDescriptionText.text = machine.data.description;

            int i = 0;
            
            foreach (var keyValue in machine.recipes)
            {
                recipes[i].DisplayRecipe(keyValue.Value, onCraftClicked);
                i++;
            }
            
            machine.OnQueueChanged += UpdateQueue;
        }

        private void UpdateQueue(Queue<CraftingProcess> queue)
        {
           this.queue.DisplayQueue(queue);
        }
    }
}

