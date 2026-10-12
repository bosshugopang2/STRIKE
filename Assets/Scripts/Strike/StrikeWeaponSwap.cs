using UnityEngine;

namespace Strike
{
    public enum StrikeState
    {
        Lobby,
        Active,
        Victory,
        Defeat
    }

    public class StrikeGameState : MonoBehaviour
    {
        [SerializeField] private StrikeState currentState = StrikeState.Lobby;

        public StrikeState CurrentState => currentState;

        public void SetState(StrikeState nextState)
        {
            currentState = nextState;
        }
    }
}
