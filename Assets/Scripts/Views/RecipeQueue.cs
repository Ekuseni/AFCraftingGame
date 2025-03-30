using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class RecipeQueue : MonoBehaviour
    {
        [SerializeField] private Image[] m_ingredients;
        [SerializeField] private TextMeshProUGUI[] m_ingredientCount;
        [SerializeField] private Image[] m_products;
        [SerializeField] private TextMeshProUGUI[] m_productCount;

        public void DisplayRecipe(Data.Recipe recipe)
        {
            for (int i = 0; i < m_ingredients.Length; i++)
            {
                if (recipe.inputs.Length > i)
                {
                    m_ingredients[i].gameObject.SetActive(true);
                    m_ingredients[i].sprite = recipe.inputs[i].item.icon;
                    m_ingredientCount[i].text = recipe.inputs[i].amount.ToString();
                }
                else
                {
                    m_ingredients[i].gameObject.SetActive(false);
                }
            }

            for (int i = 0; i < m_products.Length; i++)
            {
                if (recipe.outputs.Length > i)
                {
                    m_products[i].gameObject.SetActive(true);
                    m_products[i].sprite = recipe.outputs[i].item.icon;
                    m_productCount[i].text = recipe.outputs[i].amount.ToString();
                }
                else
                {
                    m_products[i].gameObject.SetActive(false);
                }
            }
        }
    }
}