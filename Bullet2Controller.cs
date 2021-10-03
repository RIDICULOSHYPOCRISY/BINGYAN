using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Controller : MonoBehaviour
{
    Rigidbody2D rbBullet2;
    public float speedBullet2 = 10.0f;
    private float t;
    //public bool toUp=false;
    //public bool toDown=false;
    //public bool toLeft=false;
    //public bool toRight=false;
    // Start is called before the first frame update
    void Start()
    {
        rbBullet2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("i"))
        {
            transform.Translate(Vector2.up*Time.deltaTime*speedBullet2);
        }
        if(Input.GetKey("k"))
        {
            transform.Translate(Vector2.down*Time.deltaTime*speedBullet2);
        }
        if(Input.GetKey("j"))
        {
            transform.Translate(Vector2.left*Time.deltaTime*speedBullet2);
        }
        if(Input.GetKey("l"))
        {
            transform.Translate(Vector2.right*Time.deltaTime*speedBullet2);
        }
        /*
        if(rbBullet2.velocity.sqrMagnitude==0)
        {
            Destroy(this.gameObject);
        }
        */
        t += Time.deltaTime;
        if(t>1)
        {
            Destroy(this.gameObject);
        }
    }
    /*
    public void UpGo()
    {
        transform.Translate(Vector2.up*Time.deltaTime*speedBullet2);
        toUp=false;
    }
    */
    public void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
