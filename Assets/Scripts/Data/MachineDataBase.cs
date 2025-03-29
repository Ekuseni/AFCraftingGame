using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "MachineDataBase", menuName = "Scriptable Objects/MachineDataBase")]
    public class MachineDataBase : ScriptableObject
    {
        [SerializeField] private Machine[] m_machines;

        public Machine[] machines => m_machines;
    }
}