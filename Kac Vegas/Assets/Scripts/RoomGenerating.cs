using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerating : MonoBehaviour
{
    public GameObject Room;
    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;
    public GameObject Room4;
    public GameObject Room5;
    public GameObject Corridor;
    public GameObject Corridor2;

    private int xPos =0;
    private int yPos =0;
    private int a;
    private int roomsCount;
    private int lastRoom;
    void Start()
    {
        yPos+=12;

    }
    

    void RoomsPlan()
    {
        a = Random.Range(0,4);
        if(a==0){
             Instantiate(Room, new Vector2(xPos,yPos),Quaternion.identity);
             roomsCount++;
             lastRoom = a;


        }
        if(a==1){
             Instantiate(Room1, new Vector2(xPos,yPos),Quaternion.identity);
             roomsCount++;
             lastRoom = a;

        }
        if(a==2){
             Instantiate(Room2, new Vector2(xPos,yPos),Quaternion.identity);
             roomsCount++;
             lastRoom = a;

        }
        if(a==3){
             Instantiate(Room3, new Vector2(xPos,yPos),Quaternion.identity);
             roomsCount++;
             lastRoom = a;

        }
        if(a==4){
             Instantiate(Room4, new Vector2(xPos,yPos),Quaternion.identity);
             roomsCount++;
             lastRoom = a;

        }
        if(a==5){
             Instantiate(Room5, new Vector2(xPos,yPos),Quaternion.identity);
             roomsCount++;
             lastRoom = a;

        }
       

    }
    void SpawnCorridors()
    {
        if(a==0){
            
            Instantiate(Corridor2, new Vector2(Room.transform.position.x -8 ,Room.transform.position.y +5),Quaternion.identity);
            

        }
    }

  
}
