using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "RangeChance", menuName = "Scriptable Objects/GainChance/RangeChance")]
    public class RangeChance : GainChance
    {
        [SerializeField] private int m_minGain;
        [SerializeField] private int m_maxGain;
        
        public override int GetGain()
        {
            return Random.Range(m_minGain, m_maxGain + 1);
        }
    }
    
}

