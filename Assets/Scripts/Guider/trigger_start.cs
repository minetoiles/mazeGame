using UnityEngine;

public class trigger_start : MonoBehaviour
{
    [SerializeField] Guider guider;
    [SerializeField] movement_wings wings;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        guider.enabled = true;
        wings.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
