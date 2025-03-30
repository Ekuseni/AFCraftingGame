using System;
using Data;
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
        
        private void Start()
        {
            machinePanelCloseButton.onClick.AddListener(() =>
            {
                machinePanel.SetActive(false);
            });
        }
        
        public void DisplayMachine(Models.Machine machine, Action<Data.Recipe> onCraftClicked)
        {
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
        }
    }
}

