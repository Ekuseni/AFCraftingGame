using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    [SerializeField] private Image[] m_ingredients;
    [SerializeField] private TextMeshProUGUI[] m_ingredientCount;
    [SerializeField] private Image[] m_products;
    [SerializeField] private TextMeshProUGUI[] m_productCount;
    [SerializeField] private TextMeshProUGUI m_craftTime;
    [SerializeField] private TextMeshProUGUI m_successChance;
    [SerializeField] private Button m_craftButton;
    [SerializeField] private Slider m_progressSlider;

    private Models.Recipe m_currentRecipe;
    
    public void DisplayRecipe(Models.Recipe recipe, Action<Data.Recipe> onCraftCallback)
    {
        if (m_currentRecipe == recipe) return;

        if (m_currentRecipe != null)
        {
            m_currentRecipe.OnFinished -= Finished;
            m_currentRecipe.OnProgressChanged -= UpdateProgress;
            
            m_progressSlider.gameObject.SetActive(false);
        }
        
        m_currentRecipe = recipe;
        
        for (int i = 0; i < m_ingredients.Length; i++)
        {
            if(recipe.data.inputs.Length > i)
            {
                m_ingredients[i].gameObject.SetActive(true);
                m_ingredients[i].sprite = recipe.data.inputs[i].item.icon;
                m_ingredientCount[i].text = recipe.data.inputs[i].amount.ToString();
            }
            else
            {
                m_ingredients[i].gameObject.SetActive(false);
            }
        }
        
        for (int i = 0; i < m_products.Length; i++)
        {
            if(recipe.data.outputs.Length > i)
            {
                m_products[i].gameObject.SetActive(true);
                m_products[i].sprite = recipe.data.outputs[i].item.icon;
                m_productCount[i].text = recipe.data.outputs[i].amount.ToString();
            }
            else
            {
                m_products[i].gameObject.SetActive(false);
            }
        }
        
        m_craftTime.text = $"Craft time: {recipe.data.craftTime.ToString()}";
        m_successChance.text = $"Success chance: {recipe.data.successRate.ToString()}%";
        
        m_craftButton.onClick.RemoveAllListeners();
        m_craftButton.onClick.AddListener(() => onCraftCallback?.Invoke(recipe.data));
        
        recipe.OnProgressChanged += UpdateProgress;
        recipe.OnFinished += Finished;
    }

    private void UpdateProgress(float progress)
    {
        m_progressSlider.gameObject.SetActive(true);
        m_progressSlider.value = progress;
    }

    private void Finished(bool success)
    {
        m_progressSlider.gameObject.SetActive(false);
    }
}