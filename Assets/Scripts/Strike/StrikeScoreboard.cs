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
        [SerializeField] private int enemyCount;

        private float elapsedTime;
        private StrikeHUD hud;

        private void Start()
        {
            hud = FindObjectOfType<StrikeHUD>();
            elapsedTime = 0f;
            matchState = StrikeMatchState.Active;
            UpdateEnemyCount();
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

            UpdateEnemyCount();
            UpdateHud();
        }

        public void SetState(StrikeMatchState state)
        {
            matchState = state;
            UpdateHud();
        }

        public StrikeMatchState MatchState => matchState;
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
            UpdateEnemyCount();
            if (enemyCount <= 0)
            {
                SetState(StrikeMatchState.Won);
            }
            UpdateHud();
        }

        private void UpdateEnemyCount()
        {
            enemyCount = FindObjectsOfType<StrikeEnemyBot>().Length;
        }

        private void UpdateHud()
        {
            if (hud != null)
            {
                hud.UpdateMatchState(matchState, roundTime - elapsedTime);
            }
        }
    }
}
