using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausar : MonoBehaviour
{
    // Start is called before the first frame update
    public static Pausar current;
    public GameObject pause;
    public Boolean paused=false;
    void Start()
    {
        current=this;
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused){
                Time.timeScale=1;
                paused=false;
                pause.SetActive(false);
            }
            else{
                Time.timeScale=0;
                paused=true;
                pause.SetActive(true);

            }
        }
        
    }
}
