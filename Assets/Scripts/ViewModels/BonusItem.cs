using UnityEngine;

namespace ViewModels
{
    public class BonusItem
    {
        private readonly Views.BonusItem m_view;
        private readonly Models.BonusItem m_model;

        public BonusItem(Models.BonusItem model, Views.BonusItem view)
        {
            m_model = model;
            m_view = view;
            
            model.OnCountChanged += view.UpdateItemCount;
        }
    }
}