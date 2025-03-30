using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class BonusItem : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemCount;

        public void InitializeItemView(Data.BonusItem item)
        {
            image.sprite = item.icon;
            itemName.text = item.itemName;
            itemCount.text = "0";
        }

        public void UpdateItemCount(int count)
        {
            itemCount.text = count.ToString();
        }
    }
}