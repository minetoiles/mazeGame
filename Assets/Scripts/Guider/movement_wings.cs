using UnityEngine;

public class movement_wings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void stop()
    {
        GetComponent<movement_wings>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0));
    }
}
