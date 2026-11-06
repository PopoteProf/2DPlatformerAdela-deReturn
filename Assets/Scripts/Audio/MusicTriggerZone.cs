using UnityEngine;

public class MusicTriggerZone : MonoBehaviour
{
    [SerializeField] private bool _changeMusic;
    [SerializeField] private AudioClip _music;

    [SerializeField] private bool _changeAmbiance;
    [SerializeField] private AudioClip _ambiance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_changeMusic) AudioManager.Instance.PlayMusic(_music);
            if (_changeAmbiance) AudioManager.Instance.PlayAmbiance(_music);
        }
    }
}
