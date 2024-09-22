using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public float thrustForce=10f;
    public float rotationForce=120f;
    private Rigidbody _rigid;
    public static int SCORE = 0;
    public GameObject gun,bulletPrefab;
    // Start is called before the first frame update
    private static int xborder=8;
    private static int yborder=5;
    private Boolean entrado=false;
    void Start()
    {
        _rigid=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Pausar.current.paused){
            return;
        }
        var newPos=transform.position;
        if(newPos.x>xborder){
            newPos.x=-xborder;
            entrado=true;
        }
        else if(newPos.x<-xborder){
            newPos.x=xborder;
            entrado=true;
        }
        else if(newPos.y>yborder){
            newPos.y=-yborder;
            entrado=true;
        }
        else if(newPos.y<-yborder){
            newPos.y=yborder;
            entrado=true;
        }
        if(entrado){
            transform.position=newPos;
            entrado=false;
        }
        
        float rotation=Input.GetAxis("Horizontal")*Time.deltaTime;
        Vector3 thrustDirection=transform.right;
        transform.Rotate(Vector3.forward,rotation*rotationForce);



        float thrust=Input.GetAxis("Vertical")*Time.deltaTime;
        
        _rigid.AddForce(thrustForce*thrustDirection*thrust);
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet=Instantiate(bulletPrefab,gun.transform.position,Quaternion.identity);
            Bullet bulletscript = bullet.GetComponent<Bullet>();
            bulletscript.targetVector=transform.right;
        }
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag=="Enemy"){
            
            SCORE=0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else{
            Debug.Log(message:"ns quien es");
        }
        
    }
    
}
