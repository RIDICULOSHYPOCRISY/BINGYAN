using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public float speed=3f;
    private bool movingRight=true;
    //private GameObject tempGround;
    Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(movingRight)
        {
            transform.Translate(Vector3.right*speed*Time.deltaTime);
            if(transform.position.x>tempPos.x+5)
            {
                movingRight=false;
            }
        }
        else
        {
            transform.Translate(Vector3.left*speed*Time.deltaTime);
            if(transform.position.x<tempPos.x-5)
            {
                movingRight=true;
            }
        }

        
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("ground"))
        {
            tempPos = other.gameObject.GetComponent<Transform>().position;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
