using UnityEngine;

namespace Strike
{
    public class StrikeSessionConfig : ScriptableObject
    {
        [SerializeField] private string sessionName = "STRIKE Lobby";
        [SerializeField] private string mapName = "Arena_01";
        [SerializeField] private int maxPlayers = 8;
        [SerializeField] private bool enableMobileControls = true;
        [SerializeField] private bool enableWebGLBuild = true;

        public string SessionName => sessionName;
        public string MapName => mapName;
        public int MaxPlayers => maxPlayers;
        public bool EnableMobileControls => enableMobileControls;
        public bool EnableWebGLBuild => enableWebGLBuild;
    }
}
