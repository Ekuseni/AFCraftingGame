using Data;
using Models;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Views;

namespace Installers
{
    public class MainInstaller : MonoBehaviour
    {
        [SerializeField] private ItemDataBase itemData;
        [SerializeField] private StartingConditions startingConditions;
        
        [SerializeField] private Views.Item itemPrefab;
        [SerializeField] private RectTransform itemsParent;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        
        [SerializeField] private MachineDataBase machineData;
        [SerializeField] private MachineSidepanel machineSidePanelPrefab;
        [SerializeField] private Views.MachineMainPanel machineMainPanel;
        [SerializeField] private RectTransform machinesParent;
        
        [SerializeField] private CanvasGroup mainCanvasGroup;

        async void Start()
        {
            mainCanvasGroup.alpha = 0;
            mainCanvasGroup.interactable = false;
            
            GameState gameState = new GameState();

            itemData.BuildInventory(gameState);
            
            foreach (var (key, value) in gameState.inventory)
            {
                var item = Instantiate(itemPrefab, itemsParent);
                item.InitializeItemView(itemData.GetItemById(key));
                
                new ViewModels.Item(value, item);
            }
            
            await Awaitable.NextFrameAsync();
            
            startingConditions.ApplyStartingConditions(gameState);
            var minSize = Vector2.zero;
            
            foreach (RectTransform child in itemsParent)
            {
                var layoutGroup = child.GetComponent<LayoutGroup>();
                minSize.x = Mathf.Max(minSize.x, layoutGroup.preferredWidth);
                minSize.y = Mathf.Max(minSize.y, layoutGroup.preferredHeight);
            }
            
            gridLayoutGroup.cellSize = minSize;

            foreach (var machine in machineData.machines)
            {
                var machineSidePanel = Instantiate(machineSidePanelPrefab, machinesParent);
                var machineModel = new Models.Machine(machine);
                
                new ViewModels.Machine(machineSidePanel, machineMainPanel, machineModel);
            }
            
            machineMainPanel.gameObject.SetActive(false);
            
            mainCanvasGroup.alpha = 1;
            mainCanvasGroup.interactable = true;
        }
    }
}