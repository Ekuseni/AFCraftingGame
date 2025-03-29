namespace Models
{
    public class Item
    {
        private readonly Data.Item data;

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
        
        public Item (Data.Item data)
        {
           this.data = data;
        }
    }    
}


