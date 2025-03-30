using UnityEngine;

namespace ViewModels
{
    public class Quest
    {
        private readonly Views.Quest m_view;
        private readonly Models.Quest m_model;

        public Quest(Models.Quest model, Views.Quest view)
        {
            m_model = model;
            m_view = view;
            
            model.OnQuestProgress += view.UpdateProgress;
        }
    }
}