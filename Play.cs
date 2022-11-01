using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public float offset;
    public GameObject[] Aball ;
    public GameObject[] ball ;
    public Transform SpawnBall;
    private int OpswapColoure = 0;
    private float ReBalls=0;
    public bool isLevelRandom;
    public Transform StartGeneration;

    public Menu Main;

    void Start(){
        if(isLevelRandom==true){
            for(int j = 0;j < 3;j++){
                for(int i = 0;i < 5;i++){
                Instantiate(ball[Random.Range(0, 3)],new Vector3(StartGeneration.position.x + 1.02f*i,StartGeneration.position.y - 1.02f*j,StartGeneration.position.z),transform.rotation);
            }
            }
            
        }
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        float rotateZ = Mathf.Atan2(difference.y,difference.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotateZ + offset);
        ReBalls-=Time.deltaTime;
        

        if(Input.GetMouseButtonDown(0)&&ReBalls<0)
        {
            if(Main.isBallRandom==false){
                if(OpswapColoure==0){
                Instantiate(Aball[0], SpawnBall.position,transform.rotation);
                OpswapColoure++;
                ReBalls+=2f;
            }     
            else if(OpswapColoure==1){
                Instantiate(Aball[1], SpawnBall.position,transform.rotation);
                OpswapColoure++;
                ReBalls+=2f;
            }else{
                Instantiate(Aball[2], SpawnBall.position,transform.rotation);
                OpswapColoure=0;
                ReBalls+=2f;
            }
            }else{
                Instantiate(Aball[Random.Range(0, 2)], SpawnBall.position,transform.rotation);
                ReBalls+=2f;
            }
            
        }
    }
}
