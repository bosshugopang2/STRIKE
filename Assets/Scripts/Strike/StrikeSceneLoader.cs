using UnityEngine;

namespace Strike
{
    public class StrikeAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource sfxSource;

        public void PlayShot(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }

            if (sfxSource == null)
            {
                sfxSource = gameObject.AddComponent<AudioSource>();
            }

            sfxSource.PlayOneShot(clip);
        }
    }
}
