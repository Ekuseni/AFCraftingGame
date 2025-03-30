using Data;
using Models;
using UnityEngine;
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
        
        [SerializeField] private Views.BonusItem bonusItemPrefab;
        [SerializeField] private RectTransform bonusItemsParent;
        
        [SerializeField] private Data.Quest[] quests;
        [SerializeField] private Views.Quest questPrefab;
        [SerializeField] private RectTransform questsParent;
        
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
            
            foreach (var (key, value) in gameState.bonusItems)
            {
                var item = Instantiate(bonusItemPrefab, bonusItemsParent);
                item.InitializeItemView(itemData.GetBonusItemById(key));
                
                new ViewModels.BonusItem(value, item);
            }
            
            startingConditions.ApplyStartingConditions(gameState);
            
            foreach (var quest in quests)
            {
                var questView = Instantiate(questPrefab, questsParent);
                var questModel = new Models.Quest(quest, gameState);
                questView.InitializeQuestView(questModel);
                
                gameState.quests.Add(questModel);
                new ViewModels.Quest(questModel, questView);
            }
            
            await Awaitable.NextFrameAsync();
            
            
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
                gameState.machines.Add(machineModel);
                new ViewModels.Machine(machineSidePanel, machineMainPanel, machineModel, gameState);
            }
            
            machineMainPanel.gameObject.SetActive(false);
            
            mainCanvasGroup.alpha = 1;
            mainCanvasGroup.interactable = true;
        }
    }
}