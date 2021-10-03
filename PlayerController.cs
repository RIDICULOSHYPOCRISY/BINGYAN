using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D rbBullet;
    Rigidbody2D rbBullet2;
    Vector2 movement;
    //Vector2 movementBullet;
    public float speed;
    
    public bool CanGo;
    public GameObject Bullet;
    public GameObject Bullet2;
    public Sprite 太阳雨;
    public Sprite 滑稽;
    private bool isAttack12Active=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbBullet = GetComponent<Rigidbody2D>();
        rbBullet2 = GetComponent<Rigidbody2D>();
        Bullet = Resources.Load<GameObject>("Bullet");
        Bullet2 = Resources.Load<GameObject>("Bullet2");
    }
    /*
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("door"))
        {
            CanGo=true;
        }
        else
        {
            CanGo=false;
        }

        if (other.CompareTag("ground")&&CanGo==false)
        {
            other.gameObject.GetComponent<Transform>();
            //Mathf.Clamp(float rb.position.x,float other.gameObject.transform.position.x-5,float other.gameObject.transform.position.x+5);
            //Mathf.Clamp(float rb.position.y,float other.gameObject.transform.position.y-5,float other.gameObject.transform.position.y+5);

            rb.position = new Vector3(Mathf.Clamp(rb.position.x,other.gameObject.transform.position.x-6,other.gameObject.transform.position.x+6), Mathf.Clamp(rb.position.y,other.gameObject.transform.position.y-6,other.gameObject.transform.position.y+6), 0);

            //rb.position.x < other.gameObject.transform.position.x+5;
            //rb.position.x > other.gameObject.transform.position.x-5;
            //rb.position.y < other.gameObject.transform.position.y+5;
            //rb.position.y > other.gameObject.transform.position.y-5;
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown("m")&&isAttack12Active==true)
        {
            Attack1();
        }
        if((Input.GetKeyDown("i")||Input.GetKeyDown("j")||Input.GetKeyDown("k")||Input.GetKeyDown("l"))&&isAttack12Active==true)
        {
            Attack2();
        }
        if(Input.GetKey("n"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("太阳雨");
            isAttack12Active=false;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("滑稽");
            isAttack12Active=true;
        }
        
        /*
        if(Input.GetKeyDown("n"))
        {
            Attack3();
        }
        */
        //movementBullet = movement * speedBullet;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement*speed*Time.fixedDeltaTime);
        //Bullet.MovePosition(rb.position + movementBullet*speedBullet*Time.fixedDeltaTime);
    }
    
    private void Attack1()
    {
        GameObject tempBullet = Instantiate(Bullet,rb.position,Quaternion.identity);
        tempBullet.AddComponent<BulletController>();
    }

    private void Attack2()
    {
        GameObject tempBullet2 = Instantiate(Bullet2,rb.position,Quaternion.identity);
        tempBullet2.AddComponent<Bullet2Controller>();
    }
    /*
    private void Attack3()
    {
        if(Input.GetKey("n"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("太阳雨");
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("滑稽");
        }
    
    }
    */

}
