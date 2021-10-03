using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject doorR,doorL,doorU,doorD;
    public bool roomR=false,roomL=false,roomU=false,roomD=false;
    // Start is called before the first frame update
    void Start()
    {
        doorR.SetActive(roomR);
        doorL.SetActive(roomL);
        doorU.SetActive(roomU);
        doorD.SetActive(roomD);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraController.instance.ChangeTarget(transform);
        }
    }
}
