using Data;
using Models;
using UnityEngine;
using Views;

namespace Installers
{
    public class MainInstaller : MonoBehaviour
    {
        [SerializeField] private ItemDataBase itemData;
        [SerializeField] private StartingConditions startingConditions;
        
        [SerializeField] private MachineDataBase machineData;
        [SerializeField] private MachineView machineViewPrefab;
        [SerializeField] private RectTransform machinesParent;

        void Start()
        {
            GameState gameState = new GameState();

            itemData.BuildInventory(gameState);

            startingConditions.ApplyStartingConditions(gameState);

            Debug.Log(GetInventoryString());

            string GetInventoryString()
            {
                var stringBuilder = new System.Text.StringBuilder();

                stringBuilder.AppendLine("Inventory:");
                foreach (var (key, value) in gameState.inventory)
                {
                    stringBuilder.AppendLine($"Item ID: {itemData.GetItemById(key).itemName}, Amount: {value}");
                }

                stringBuilder.AppendLine("Bonus Items:");
                foreach (var (key, value) in gameState.bonusItems)
                {
                    stringBuilder.AppendLine(
                        $"Bonus Item ID: {itemData.GetBonusItemById(key).itemName}, Amount: {value}");
                }

                return stringBuilder.ToString();
            }

            foreach (var machine in machineData.machines)
            {
                var machineView = Instantiate(machineViewPrefab, machinesParent);
                machineView.SetupMachineView(machine, null);
            }
        }
    }
}