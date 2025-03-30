using System.Collections.Generic;
using System.Collections.ObjectModel;
using Models;
using UnityEngine;

namespace Views
{
    public class Queue : MonoBehaviour
    {
        [SerializeField] private RectTransform m_queueContainer;

        private List<RecipeQueue> m_recipeQueue = new List<RecipeQueue>();
        
        private void Start()
        {
            m_recipeQueue.Add(m_queueContainer.GetChild(0).GetComponent<RecipeQueue>());
            m_recipeQueue[0].gameObject.SetActive(false);
        }
        
        public void DisplayQueue(Queue<CraftingProcess> craftingQueue)
        {
            using var queueEnumerator = craftingQueue.GetEnumerator();
            var i = 0;

            while (queueEnumerator.MoveNext())
            {
                if (i >= m_recipeQueue.Count)
                {
                    m_recipeQueue.Add(Instantiate(m_recipeQueue[0], m_queueContainer));
                }

                m_recipeQueue[i].gameObject.SetActive(true);
                m_recipeQueue[i].DisplayRecipe(queueEnumerator.Current.data);

                i++;
            }

            if (m_recipeQueue.Count > i)
            {
                for (int j = i; j < m_recipeQueue.Count; j++)
                {
                    m_recipeQueue[j].gameObject.SetActive(false);
                }
            }
        }
    }

}

