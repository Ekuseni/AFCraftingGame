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
        
        public void DisplayMachine(Machine machine)
        {
            machinePanel.SetActive(true);
            machineImage.sprite = machine.icon;
            machineNameText.text = machine.machineName;
            machineDescriptionText.text = machine.description;

            for (int i = 0; i < recipes.Length; i++)
            {
                recipes[i].DisplayRecipe(machine.recipes[i]);
            }
        }
    }

}

