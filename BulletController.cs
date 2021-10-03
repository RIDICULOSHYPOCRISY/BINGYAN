using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speedBullet;
    Rigidbody2D rbBullet;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Random.Range(-400,400),Random.Range(-400,400))*speedBullet*Time.deltaTime);
        t += Time.deltaTime;
        if(t>5)
        {
            Destroy(this.gameObject);
        }
    }
    
    /*
    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("ground"))
        {
            other.gameObject.GetComponent<Transform>();
            
            rbBullet.position = new Vector3(Mathf.Clamp(rbBullet.position.x,other.gameObject.transform.position.x-5,other.gameObject.transform.position.x+5), Mathf.Clamp(rbBullet.position.y,other.gameObject.transform.position.y-5,other.gameObject.transform.position.y+5), 0);

        }
    }
    */

}
