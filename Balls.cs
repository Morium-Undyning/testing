using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public float speed;
    Vector2 dVector;
    Rigidbody2D rb;
    private float fallReTime;
    public float ZRotate;
    private bool start;
    public bool stat;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ZRotate = transform.rotation.z*120f;
    }


    void Update()
    {
        if(stat==false)
        {
        transform.Translate(Vector2.right * speed *Time.deltaTime);
        }
        fallReTime-=Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag =="balls"&&tag =="balls"||other.tag =="Rball"&&tag =="Rball"||other.tag =="Bball"&&tag =="Bball"){
            Destroy(other.gameObject);               
            Destroy(gameObject);
        }
        else if(other.tag == "fall"&&fallReTime<0)
        {
            transform.rotation = Quaternion.Euler(0f,0f, ZRotate-90f);
            fallReTime = 1f;
        }
        else if(other.tag == "foll"&&fallReTime<0)
        {
            transform.rotation = Quaternion.Euler(0f,0f, -ZRotate+180f);
            fallReTime = 1f;
        }
        else if(other.tag == "fill"&&fallReTime<0 && transform.rotation.z*120f<90f)
        {
            transform.rotation = Quaternion.Euler(0f,0f, ZRotate+180f);
            fallReTime = 1f;
        }else if(other.tag == "fill"&& fallReTime<0 && transform.rotation.z*120f>90f)
        {
            transform.rotation = Quaternion.Euler(0f,0f, ZRotate+90f);
            fallReTime = 1f;
        }
        else{
            speed = 0;
        }
        
        
    }
}
