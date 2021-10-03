using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //单例模式便于访问
    public static CameraController instance;
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=null)
        {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.position.x,target.position.y,target.position.z - 1),speed*Time.deltaTime);
        }
        
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
