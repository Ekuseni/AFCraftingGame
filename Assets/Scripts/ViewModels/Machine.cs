using System;
using Models;

namespace ViewModels
{
    public class Machine
    {
        private readonly Views.MachineSidepanel m_sidePanel;
        private readonly Views.MachineMainPanel m_mainPanel;
        private readonly Models.Machine m_model;
        private readonly GameState m_gameState;
        
        public Machine(Views.MachineSidepanel sidePanel, Views.MachineMainPanel mainPanel, Models.Machine model, GameState gameState)
        {
            m_sidePanel = sidePanel;
            m_mainPanel = mainPanel;
            m_model = model;
            m_gameState = gameState;
            
            m_sidePanel.SetupMachineView(model, OnClick, OnUpdate);
        }

        private void OnClick()
        {
            m_mainPanel.DisplayMachine(m_model, CraftClicked);
            m_model.UpdateQueue();
        }

        private void CraftClicked(Data.Recipe recipe)
        {
            var craftingProcess = new CraftingProcess(recipe);
            craftingProcess.OnCraftingProgressChanged += UpdateProgress;
            craftingProcess.OnCraftingFinished += CraftingFinished;
            m_model.Enqueue(craftingProcess);
        }

        private void UpdateProgress(Data.Recipe recipe, float progress)
        {
            m_sidePanel.UpdateProgress(progress);
            
            m_model.recipes[recipe].UpdateProgress(progress);
        }

        private void OnUpdate(float deltaTime)
        {
            m_model.currentCraftingProcess?.Update(deltaTime);
        }
        
        private void CraftingFinished(Data.Recipe recipe, bool success)
        {
            m_model.currentCraftingProcess.OnCraftingProgressChanged -= UpdateProgress;
            m_sidePanel.HideProgress();
            m_model.recipes[recipe].Finish(success);
            m_model.Dequeue();
            
            if(success)
            {
               m_gameState.AddItems(recipe.outputs);
            }
        }
    }
}