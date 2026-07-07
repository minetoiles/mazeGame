using UnityEngine;

public class Guider : MonoBehaviour
{

    [SerializeField] GameObject[] flags;
    [SerializeField] int[] direction;
    [SerializeField] movement_wings movement_Wings;
    [SerializeField] BoxCollider wings;

    AudioSource drop_sound;

    int count = 0;
    int order = 0;

    float time = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        drop_sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        move();

    }

    void drop()
    {
        Instantiate(flags[order], transform.position, Quaternion.identity);
        drop_sound.Play();
        order = (order+1) % flags.Length;
    }
    void move()
    {
        if (time > 1)
        {
            count++;
            time = 0;
            drop();
        }
        Vector3 temp = Vector3.zero;
        if (count >= direction.Length) {
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<CapsuleCollider>().isTrigger = false;
            wings.isTrigger = false;
            this.GetComponent<Guider>().enabled = false;
            movement_Wings.stop();
            return;
        }
        switch (direction[count])
        {
            case 0:
                temp = Vector3.forward;
                break;
            case 1:
                temp = Vector3.back;
                break;
            case 2:
                temp = Vector3.right;
                break;
            case 3:
                temp = Vector3.left;
                break;
        }
        transform.Translate(temp * 10 / Application.targetFrameRate);
        
    }
}
