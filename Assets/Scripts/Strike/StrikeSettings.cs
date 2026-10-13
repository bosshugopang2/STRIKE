using UnityEngine;

namespace Strike
{
    public class StrikePlayerCameraRig : MonoBehaviour
    {
        [SerializeField] private Vector3 offset = new Vector3(0f, 0.4f, 0.2f);

        private void Start()
        {
            if (Camera.main == null)
            {
                var cameraObj = new GameObject("Main Camera");
                cameraObj.tag = "MainCamera";
                var camera = cameraObj.AddComponent<Camera>();
                cameraObj.AddComponent<AudioListener>();
            }

            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = offset;
        }
    }
}
