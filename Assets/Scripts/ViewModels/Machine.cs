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
            
            m_sidePanel.SetupMachineView(model.data, OnClick);
        }
        
        private void OnClick()
        {
            m_mainPanel.DisplayMachine(m_model.data);
        }
    }
}