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
        [SerializeField] private int score;

        private float elapsedTime;
        private StrikeHUD hud;

        private void Start()
        {
            hud = FindObjectOfType<StrikeHUD>();
            elapsedTime = 0f;
            matchState = StrikeMatchState.Active;
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
        public float TimeRemaining => Mathf.Max(0f, roundTime - elapsedTime);
        public int Score => score;

        public void RegisterPlayerDeath()
        {
            if (matchState == StrikeMatchState.Active)
            {
                SetState(StrikeMatchState.Lost);
            }
        }

        public void RegisterEnemyDestroyed()
        {
            score += 100;
            if (FindObjectsOfType<StrikeEnemyAI>().Length <= 0)
            {
                SetState(StrikeMatchState.Won);
            }
            UpdateHud();
        }

        private void UpdateHud()
        {
            if (hud != null)
            {
                hud.UpdateDisplay(matchState, TimeRemaining, score);
            }
        }
    }
}
