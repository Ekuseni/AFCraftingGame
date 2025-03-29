using Models;
using UnityEngine;

namespace Data
{
    public abstract class GainChance : ScriptableObject
    {
        public abstract int GetGain();
    }
}