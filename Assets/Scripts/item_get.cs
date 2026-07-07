using UnityEngine;

public class item_get : MonoBehaviour
{
    [SerializeField] GameObject map_system;
    [SerializeField] int number;

    Map map;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = map_system.GetComponent<Map>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        map.map_get(number);
        Destroy(this.gameObject);
    }
}