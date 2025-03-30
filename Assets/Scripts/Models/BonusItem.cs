namespace Models
{
    public class BonusItem
    {
        private readonly Data.BonusItem data;

        private int count;
        
        public event System.Action<int> OnCountChanged;
        
        public int Count
        {
            get => count;
            set
            {
                if (count == value) return;
                OnCountChanged?.Invoke(value);
                count = value;
            }
        }
        
        public BonusItem (Data.BonusItem data)
        {
           this.data = data;
        }
    }    
}


