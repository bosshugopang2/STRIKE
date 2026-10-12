using UnityEngine;

namespace Strike
{
    public enum StrikeMatchState
    {
        Waiting,
        Active,
        Won,
        Lost
    }

    public class StrikeGameManager : MonoBehaviour
    {
        [SerializeField] private StrikeMatchState matchState = StrikeMatchState.Active;
        [SerializeField] private float roundTime = 180f;

        private float elapsedTime;
        private StrikeHUD hud;

        private void Start()
        {
            hud = FindObjectOfType<StrikeHUD>();
            matchState = StrikeMatchState.Active;
            elapsedTime = 0f;
            UpdateHud();
        }

        private void Update()
        {
            if (matchState != StrikeMatchState.Active)
            {
                return;
            }

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= roundTime)
            {
                SetState(StrikeMatchState.Won);
            }

            UpdateHud();
        }

        public void SetState(StrikeMatchState state)
        {
            matchState = state;
            UpdateHud();
        }

        public StrikeMatchState MatchState => matchState;

        public void RegisterPlayerDeath()
        {
            if (matchState == StrikeMatchState.Active)
            {
                SetState(StrikeMatchState.Lost);
            }
        }

        private void UpdateHud()
        {
            if (hud == null)
            {
                return;
            }

            hud.UpdateMatchState(matchState, roundTime - elapsedTime);
        }
    }
}
