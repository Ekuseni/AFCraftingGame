using System;
using Models;

namespace ViewModels
{
    public class Machine
    {
        private readonly Views.MachineSidepanel m_sidePanel;
        private readonly Views.MachineMainPanel m_mainPanel;
        private readonly Models.Machine m_model;
        
        public Machine(Views.MachineSidepanel sidePanel, Views.MachineMainPanel mainPanel, Models.Machine model)
        {
            m_sidePanel = sidePanel;
            m_mainPanel = mainPanel;
            m_model = model;
            
            m_sidePanel.SetupMachineView(model, OnClick, OnUpdate);
        }

        private void OnClick()
        {
            m_mainPanel.DisplayMachine(m_model, CraftClicked);
        }

        private void CraftClicked(Data.Recipe recipe)
        {
            var craftingProcess = new CraftingProcess(recipe);
            craftingProcess.OnCraftingProgressChanged += UpdateProgress;
            craftingProcess.OnCraftingFinished += CraftingFinished;
            
            if (m_model.currentCraftingProcess == null)
            {
                m_model.currentCraftingProcess = craftingProcess;
            }
            else
            {
                m_model.craftingQueue.Enqueue(craftingProcess);    
            }
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
            m_model.currentCraftingProcess = m_model.craftingQueue.Count > 0 ? m_model.craftingQueue.Dequeue() : null;
        }
    }
}