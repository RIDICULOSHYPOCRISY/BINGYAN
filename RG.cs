using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG : MonoBehaviour
{
    public enum Direction{up,down,left,right};
    public Direction direction;
    public List<Room> rooms = new List<Room>();
    

    [Header("房间信息")]
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor,endColor;
    private GameObject endRoom;

    [Header("位置控制")]
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;

    // Start is called before the first frame update
    void Start()
    {
        //将房间添加到列表rooms里
        for(int i = 0;i<roomNumber;i++)
        {
            //直接在前面加getcomponent,以后就不用每次都加了
            rooms.Add(Instantiate(roomPrefab,generatorPoint.position,Quaternion.identity).GetComponent<Room>());
            //改变point位置
            ChangePointPosition();
        }

        rooms[0].GetComponent<SpriteRenderer>().color = startColor;
        endRoom=rooms[0].gameObject;
        foreach(var room in rooms)
        {
            if(room.transform.position.sqrMagnitude<endRoom.transform.position.sqrMagnitude)
            {
                endRoom=room.gameObject;
            }
            SetUpRoom(room,room.transform.position);
        }
        endRoom.GetComponent<SpriteRenderer>().color = endColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePointPosition()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);
            switch (direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;
                }
        }while(Physics2D.OverlapCircle(generatorPoint.position,0.2f,roomLayer));
        //检测某一图层的一定半径范围内是否有碰撞
    }

    public void SetUpRoom(Room newRoom,Vector3 roomPosition)
    {
        newRoom.roomR=Physics2D.OverlapCircle(roomPosition+new Vector3(xOffset,0,0),0.2f,roomLayer);
        newRoom.roomL=Physics2D.OverlapCircle(roomPosition+new Vector3(-xOffset,0,0),0.2f,roomLayer);
        newRoom.roomU=Physics2D.OverlapCircle(roomPosition+new Vector3(0,yOffset,0),0.2f,roomLayer);
        newRoom.roomD=Physics2D.OverlapCircle(roomPosition+new Vector3(0,-yOffset,0),0.2f,roomLayer);

    }
}
