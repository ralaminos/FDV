using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed=100f;
    public float maxlifetime=3f;
    public Vector3 targetVector;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,maxlifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Pausar.current.paused){
            return;
        }
        transform.Translate(speed*targetVector*Time.deltaTime);
        
    }
    private void OnCollisionEnter(Collision collision){
        
        if(collision.gameObject.CompareTag("Enemy")){
            
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            UpdateScoreText();
        }
    }
    private void IncreaseScore(){
        Player.SCORE++;
        
    }
    private void UpdateScoreText(){
        GameObject go=GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Asteroides:"+Player.SCORE;
    }
}
