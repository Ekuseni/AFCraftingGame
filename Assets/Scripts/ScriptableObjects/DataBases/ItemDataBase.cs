using Data;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Scriptable Objects/ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    //Should add id sanity check
    [SerializeField] private Item[] m_items;
}
