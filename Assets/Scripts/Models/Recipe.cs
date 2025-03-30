using System;
using UnityEngine;

namespace Models
{
    public class Recipe
    {
        public readonly Data.Recipe data;
        
        public event Action<float> OnProgressChanged;
        public event Action<bool> OnFinished;
        
        public Recipe (Data.Recipe data)
        {
            this.data = data;
        }
        
        public void UpdateProgress(float progress)
        {
            OnProgressChanged?.Invoke(progress);
        }
        
        public void Finish(bool success)
        {
            OnFinished?.Invoke(success);
        }
    }    
}


