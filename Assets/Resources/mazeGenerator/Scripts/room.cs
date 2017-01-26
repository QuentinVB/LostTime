using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private GameObject ground;
    private GameObject doors;
    private GameObject wall;

    private Object groundPrefab;
    private Object doorsPrefab;
    private Object wallPrefab;

    private int x;
    private int y;

    private CellData roomdata;

    public Room(CellData roomdata)
    {
        //load assets
        groundPrefab = Resources.Load("mazeGenerator/maze_ground");
        doorsPrefab = Resources.Load("mazeGenerator/maze_doors");
        wallPrefab = Resources.Load("mazeGenerator/maze_wallSimple");

        //load ctor data
        this.roomdata = roomdata;
        x = roomdata.xPos;
        y = roomdata.yPos;

        //setup ground
        ground = (GameObject)Instantiate(groundPrefab,new Vector3(x*6,0,y*6),Quaternion.Euler(-90,0,0));
        ground.name = string.Format("{0},{1}", x, y);

        //setup door
        doors = (GameObject)Instantiate(doorsPrefab, ground.transform);
        doors.name = string.Format("door_{0},{1}", x, y);

        //doors.transform.Rotate(90, 0, 0);
        //doors.transform.localPosition.Set(0,0,0) ;

        //set the walls
        if (roomdata.northDoor == true) createWall(90);
        if (roomdata.southDoor == true) createWall(-90);
        if (roomdata.eastDoor == true) createWall(180);
        if (roomdata.westDoor == true) createWall(0);
    }
    void createWall(float vertRotation)
    {
        string side = angleToString(vertRotation);
        wall = (GameObject)Instantiate(wallPrefab, ground.transform);
        wall.transform.localPosition = new Vector3(wall.transform.localPosition.x - 2.5f, 0, 0);
        wall.transform.RotateAround(ground.transform.position,Vector3.up, vertRotation);
        wall.name = string.Format("wall_{0},{1}_{2}", x, y,side);
    }
    string angleToString(float angle)
    {
        if (angle == 90) return "north";
        if (angle == -90) return "south";
        if (angle == 0) return "west";
        if (angle == 180) return "east";
        return "none";
    }
}

