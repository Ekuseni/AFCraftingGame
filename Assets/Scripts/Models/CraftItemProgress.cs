namespace Models
{
    public class CraftItemProgress : QuestProgress
    {
        private int count;
        private int currentCount;
        private Item item;

        public CraftItemProgress(int count, Item item)
        {
            this.count = count;
            this.item = item;

            item.OnCountChanged += (_) =>
            {
                currentCount++;
                Update();
            };
        }

        public override float GetProgress()
        {
            return (float)currentCount / count;
        }
    }
}