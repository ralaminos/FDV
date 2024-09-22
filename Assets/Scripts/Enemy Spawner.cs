using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MeteoritePrefab;
    public float spawnRatePerMinute=30f;
    public float spawnRateIncrement=5f;
    private float spawnNext=0;
    public float xlimit;
    public float maxTimeLife=4f;

    // Update is called once per frame
    void Update()
    {
        if(Pausar.current.paused){
            return;
        }
        if(Time.time>spawnNext){
            spawnNext=Time.time+ 60/spawnRatePerMinute;
            spawnRatePerMinute+=spawnRateIncrement;
            float rand=Random.Range(-xlimit,xlimit);
            Vector2 spawnPosition=new Vector2(x:rand,y:8f);
            GameObject meteor=Instantiate(MeteoritePrefab,spawnPosition,Quaternion.identity);
            Destroy(meteor,maxTimeLife);
        }
        
    }
}
