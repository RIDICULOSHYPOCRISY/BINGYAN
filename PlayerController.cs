using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D rbBullet;
    Rigidbody2D rbBullet2;
    Vector2 movement;
    //Vector2 movementBullet;
    public float speed;

    public GameObject GameOverText;
    public GameObject RestartButton;
    private float t;

    public bool CanGo;
    public GameObject Bullet;
    public GameObject Bullet2;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
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
        GameOverText.SetActive(false);
        RestartButton.SetActive(false);

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
            speed=10;
            isAttack12Active=false;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("滑稽");
            speed=5;
            isAttack12Active=true;
        }
        
        /*
        if(Input.GetKeyDown("n"))
        {
            Attack3();
        }
        */
        //movementBullet = movement * speedBullet;
         if(RestartButton.activeSelf==true)
        {
            t += Time.deltaTime;
        }
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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")&&life1.activeSelf==true&&life2.activeSelf==true&&life3.activeSelf==true)
        {
            life1.SetActive(false);
            
        }
        else if(other.CompareTag("Enemy")&&life1.activeSelf==false&&life2.activeSelf==true&&life3.activeSelf==true)
        {
            life2.SetActive(false);
            
        }
        else if(other.CompareTag("Enemy")&&life1.activeSelf==false&&life2.activeSelf==false&&life3.activeSelf==true)
        {
            life3.SetActive(false);
            GameOverText.SetActive(true);
            RestartButton.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().enabled=false;

        }

        if(other.CompareTag("passingdoor1"))
        {
            GameObject passingdoor2 = GameObject.FindGameObjectWithTag("passingdoor2");
            this.gameObject.transform.position = new Vector3(passingdoor2.transform.position.x,passingdoor2.transform.position.y+2,0);
        }
        if(other.CompareTag("passingdoor2"))
        {
            GameObject passingdoor1 = GameObject.FindGameObjectWithTag("passingdoor1");
            this.gameObject.transform.position = passingdoor1.transform.position;
            this.gameObject.transform.position = new Vector3(passingdoor1.transform.position.x,passingdoor1.transform.position.y+2,0);
        }

        
    }



    public void RestartGame()
    {
        if(t>3)
            {
                //this.gameObject.SetActive(true);
                SceneManager.LoadScene("Roguelike");
            }
    }

}
