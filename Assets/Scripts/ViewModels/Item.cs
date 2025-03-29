using UnityEngine;

namespace ViewModels
{
    public class Item
    {
        private readonly Views.Item m_view;
        private readonly Models.Item m_model;

        public Item(Models.Item model, Views.Item view)
        {
            m_model = model;
            m_view = view;
            
            model.OnCountChanged += view.UpdateItemCount;
        }
    }
}