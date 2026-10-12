using UnityEngine;
using UnityEngine.SceneManagement;

namespace Strike
{
    public class StrikeSceneLoader : MonoBehaviour
    {
        public void LoadSceneByName(string sceneName)
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
