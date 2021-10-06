using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public float speedEnemy;
    
    Rigidbody2D rbEnemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Random.Range(-100,100),Random.Range(-100,100))*speedEnemy*Time.deltaTime);
       
       
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("ground"))
        {
            other.gameObject.GetComponent<Transform>();
            
            rbEnemy.position = new Vector3(Mathf.Clamp(rbEnemy.position.x,other.gameObject.transform.position.x-5,other.gameObject.transform.position.x+5), Mathf.Clamp(rbEnemy.position.y,other.gameObject.transform.position.y-5,other.gameObject.transform.position.y+5), 0);

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
