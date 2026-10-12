using UnityEngine;

namespace Strike
{
    [CreateAssetMenu(fileName = "StrikeSettings", menuName = "STRIKE/Settings")]
    public class StrikeSettings : ScriptableObject
    {
        [SerializeField] private int maxBots = 6;
        [SerializeField] private float matchTime = 180f;
        [SerializeField] private bool mobileMode = true;
        [SerializeField] private bool webGlMode = true;

        public int MaxBots => maxBots;
        public float MatchTime => matchTime;
        public bool MobileMode => mobileMode;
        public bool WebGlMode => webGlMode;
    }
}
