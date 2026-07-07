using UnityEngine;

public class EnemySoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Stop();   // 범위를 벗어나면 즉시 종료
        }
    }
}
