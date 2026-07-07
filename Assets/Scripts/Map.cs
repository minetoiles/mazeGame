using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using System.Diagnostics;

public class Map : MonoBehaviour
{

    [SerializeField] Image[] maps;
    [SerializeField] bool[] bools = { true };

    [SerializeField] GameObject main;
    [SerializeField] GameObject map_view;


    AudioSource get_sound;
    bool isShow;
    bool hasChange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        get_sound = this.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isShow = true; 
            hasChange = true;
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            isShow= false;
            hasChange = true;
        }

        mapCheck();
    }

    void mapCheck()
    {
        if (hasChange)
        {
            if (isShow)
            {
                for (int i = 0; i < maps.Length; i++)
                {
                    maps[i].enabled = bools[i];
                }
            }
            else
            {
                foreach(Image one in maps)
                {
                    one.enabled = false;
                }
            }
            view_change();
        }
    }

    public void map_get(int order)
    {
        get_sound.Play();
        bools[order] = false;
    }

    void view_change()
    {
        if (isShow)
        {
            main.SetActive(false);
            map_view.SetActive(true);
        }
        else
        {
            main.SetActive(true);
            map_view.SetActive(false);
        }
    }
}
