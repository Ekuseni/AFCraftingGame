using System.Collections.Generic;

namespace Models
{
    public class Quest
    {
        public Data.Quest data { get; }

        private List<QuestProgress> questProgress { get; }
        
        public event System.Action<float> OnQuestProgress;

        public Quest(Data.Quest data, GameState gameState)
        {
            this.data = data;

            questProgress = new List<QuestProgress>();
            
            foreach (var requirement in data.requirements)
            {
                questProgress.Add(requirement.GetQuestProgress(gameState));
            }

            foreach (var progress in questProgress)
            {
                progress.OnQuestProgress += CalculateProgress;
            }
        }
        
        private void CalculateProgress()
        {
            var progressSum = 0f;
            var total = 0f;
            
            foreach (var progress in questProgress)
            {
                progressSum += progress.GetProgress();
                total += 1f;
            }
            
            OnQuestProgress?.Invoke(progressSum / total);
        }
    }
}