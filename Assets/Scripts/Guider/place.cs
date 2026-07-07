using UnityEngine;

public class place : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider box;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        box = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = false;
        box.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
