using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.GetComponent<Enemy4Controller>().enabled = true;
        }
    }

}
