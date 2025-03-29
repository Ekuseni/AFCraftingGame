using Data;
using UnityEngine;

[CreateAssetMenu(fileName = "PercentageChance", menuName = "Scriptable Objects/GainChance/PercentageChance")]
public class PercentageChance : GainChance
{
    [SerializeField] private float m_percentageChance;
    [SerializeField] private int m_gain;
    
    public override int GetGain()
    {
        return Random.Range(0f, 100f) <= m_percentageChance ? m_gain : 0;
    }
}
