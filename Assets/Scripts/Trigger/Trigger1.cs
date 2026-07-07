using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.GetComponent<Enemy1Controller>().enabled = true;
        }
    }

}
