using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public List<GameObject> bossAttacks = new List<GameObject>();
    public GameObject bossAttack;
    public GameObject Win;
    //public List<GameObject> WinText = new List<GameObject>();
    private int count=6;
    private float t=0;
    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        if(count<=0)
        {
            this.gameObject.SetActive(false);
            t+=Time.deltaTime;
            if(t>2)
            {
                SceneManager.LoadScene("End");
            }
            
            //Instantiate(Win,this.gameObject.transform.position,Quaternion.identity);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            bossAttacks.Add(Instantiate(bossAttack,new Vector3(Random.Range(this.gameObject.transform.position.x-5,this.gameObject.transform.position.x+5), Random.Range(this.gameObject.transform.position.y-5,this.gameObject.transform.position.y+5), 0),Quaternion.identity));
            bossAttacks.Add(Instantiate(bossAttack,new Vector3(Random.Range(this.gameObject.transform.position.x-5,this.gameObject.transform.position.x+5), Random.Range(this.gameObject.transform.position.y-5,this.gameObject.transform.position.y+5), 0),Quaternion.identity));
            bossAttacks.Add(Instantiate(bossAttack,new Vector3(Random.Range(this.gameObject.transform.position.x-5,this.gameObject.transform.position.x+5), Random.Range(this.gameObject.transform.position.y-5,this.gameObject.transform.position.y+5), 0),Quaternion.identity));
            bossAttacks.Add(Instantiate(bossAttack,new Vector3(Random.Range(this.gameObject.transform.position.x-5,this.gameObject.transform.position.x+5), Random.Range(this.gameObject.transform.position.y-5,this.gameObject.transform.position.y+5), 0),Quaternion.identity));
            bossAttacks.Add(Instantiate(bossAttack,new Vector3(Random.Range(this.gameObject.transform.position.x-5,this.gameObject.transform.position.x+5), Random.Range(this.gameObject.transform.position.y-5,this.gameObject.transform.position.y+5), 0),Quaternion.identity));
            count --;
        
        }
    }
}
