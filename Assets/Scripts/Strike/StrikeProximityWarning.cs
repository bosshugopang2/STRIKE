using UnityEngine;

namespace Strike
{
    public class StrikeWorldEffects : MonoBehaviour
    {
        [SerializeField] private Color ambientColor = new Color(0.25f, 0.25f, 0.35f);

        private void Start()
        {
            RenderSettings.ambientLight = ambientColor;
        }
    }
}
