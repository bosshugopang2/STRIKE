using UnityEngine;

namespace Strike
{
    public class StrikeRoundLogic : MonoBehaviour
    {
        [SerializeField] private float roundDuration = 180f;
        private float remainingTime;

        private void Start()
        {
            remainingTime = roundDuration;
        }

        private void Update()
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0f)
            {
                remainingTime = 0f;
                var manager = FindObjectOfType<StrikeGameManager>();
                if (manager != null)
                {
                    manager.SetState(StrikeMatchState.Won);
                }
            }
        }
    }
}
