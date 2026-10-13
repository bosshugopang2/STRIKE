using UnityEngine;

namespace Strike
{
    [CreateAssetMenu(fileName = "StrikeSettings", menuName = "STRIKE/Settings")]
    public class StrikeSettings : ScriptableObject
    {
        [SerializeField] private int maxBots = 6;
        [SerializeField] private float matchDuration = 180f;
        [SerializeField] private bool mobileControls = true;
        [SerializeField] private bool webGlReady = true;
        [SerializeField] private bool iosReady = true;

        public int MaxBots => maxBots;
        public float MatchDuration => matchDuration;
        public bool MobileControls => mobileControls;
        public bool WebGlReady => webGlReady;
        public bool IosReady => iosReady;
    }
}
