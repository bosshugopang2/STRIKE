using UnityEngine;

namespace Strike
{
    public class StrikePlayerStats : MonoBehaviour
    {
        [SerializeField] private int score;
        [SerializeField] private int kills;
        [SerializeField] private int deaths;
        [SerializeField] private int assists;

        public int Score => score;
        public int Kills => kills;
        public int Deaths => deaths;
        public int Assists => assists;

        public void AddScore(int amount)
        {
            score += amount;
        }

        public void AddKill()
        {
            kills++;
            score += 100;
        }

        public void AddDeath()
        {
            deaths++;
            score = Mathf.Max(0, score - 25);
        }

        public void AddAssist()
        {
            assists++;
            score += 50;
        }
    }
}
