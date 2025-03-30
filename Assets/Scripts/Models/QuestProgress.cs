using System;

namespace Models
{
    public abstract class QuestProgress
    {
        public event Action OnQuestProgress;
        
        public abstract float GetProgress();
        
        protected void Update()
        {
            OnQuestProgress?.Invoke();
        }
    }

}

