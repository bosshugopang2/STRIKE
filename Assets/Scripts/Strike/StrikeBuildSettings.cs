using UnityEngine;

namespace Strike
{
    public class StrikeBuildSettings : MonoBehaviour
    {
        [SerializeField] private bool isWebGLReady = true;
        [SerializeField] private bool isIOSReady = true;
        [SerializeField] private bool isAndroidReady = true;

        public bool IsWebGLReady => isWebGLReady;
        public bool IsIOSReady => isIOSReady;
        public bool IsAndroidReady => isAndroidReady;

        public void ConfigureBuilds()
        {
            // This acts as a build-prep descriptor for future Unity platform configuration.
            Debug.Log("STRIKE build configuration prepared for WebGL, iOS, and Android.");
        }
    }
}
