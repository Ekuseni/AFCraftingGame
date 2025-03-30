using System;
using Models;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class RecipeItem
    {
        [SerializeField] private Item m_item;
        [SerializeField] private int m_amount;
        
        public Item item => m_item;
        public int amount => m_amount;
    }
    
    
    [CreateAssetMenu(fileName = "RecipeData", menuName = "Scriptable Objects/RecipeData")]
    public class Recipe : ScriptableObject
    {
        [SerializeField] private RecipeItem[] m_inputs;
        [SerializeField] private RecipeItem[] m_outputs;
        [SerializeField] private float m_craftTime;
        [SerializeField] private float m_SuccessRate;
        
        public RecipeItem[] inputs => m_inputs;
        public RecipeItem[] outputs => m_outputs;
        public float craftTime => m_craftTime;
        public float successRate => m_SuccessRate;
        
        public bool IsCraftingSuccessful(GameState gameState)
        {
            return UnityEngine.Random.Range(0f, 100f) <= m_SuccessRate + gameState.successRateModifier;
        }
    }
}


