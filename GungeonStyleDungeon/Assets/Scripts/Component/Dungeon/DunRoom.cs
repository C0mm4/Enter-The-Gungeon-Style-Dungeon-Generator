using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunRoom : MonoBehaviour
{
    public int roomID;
    public int x, y;
    public int centerX, centerY;
    public GameObject Tiles;
    public List<Tile> tiles = new List<Tile>();

    public List<GameObject> doorTiles;
    public List<GameObject> Doors;
    public List<GameObject> DoorObjs;

    public List<DunRoom> ConnectRoom;
    public List<GameObject> ConnectCorridor;

    public int sizeX, sizeY;

    public GameObject enterTrigger;

    public bool isClear = false;
    public bool isActivate = false;

    public int mobCount = 0;

    public List<Transform> spawnTrans;


    // Start Room
    public void ActivateRoom()
    {
        if(spawnTrans.Count > 0)
        {
            CloseDoor();
        }
        if (!isActivate)
        {
            isActivate = true;
            if(spawnTrans.Count > 0 )
            {
                CloseDoor();
                StartCoroutine(MobSpawn());

            }
            else
            {
                // If spawn Trans is 0 this room is clear
                GameManager.StageC.ClearRoom();
            }
        }

    }

    // When Start Room, Mob Spawns 1 seconds, and activate 1 seconds
    public virtual IEnumerator MobSpawn()
    {
        // Mob Spawn Code
        yield return 0;
    }


    // When Start Room Closed Door
    // Find Corridor linked tile and doors set
    public void CloseDoor()
    {
        foreach(GameObject go in Doors) 
        {
            GameObject door = GameManager.Resource.Instantiate("Dungeon/Door/Door", GameManager.MapGen.Doors.transform);
            switch (go.GetComponent<Tile>().types)
            {
                case 2:
                    door.transform.position = go.transform.position + new Vector3(0, 2, -1);
                    break;
                case 4:
                    door.transform.position = go.transform.position + new Vector3(-2, 0, -1);
                    break;
                case 6:
                    door.transform.position = go.transform.position + new Vector3(2, 0, -1);
                    break;
                case 8:
                    door.transform.position = go.transform.position + new Vector3(0, -2, -1);
                    break;
            }
            door.GetComponent<Gate>().Activate();
            DoorObjs.Add(door);
        }
    }

    // When Clear Room Open Door
    public virtual void OpenDoor()
    {
        foreach(GameObject gate in DoorObjs)
        {
            gate.GetComponent<Gate>().DeActivate();
        }
        DoorObjs.Clear();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "Player")
        {
            GameManager.StageC.moveRoom(roomID);
        }
    }

    public (Vector3, Vector3) roomRange()
    {
        int left = x - centerX;
        int down = y - centerY;

        int right = x + sizeX - centerX -1;
        int top = y + sizeY - centerY -1;

        return (new Vector3(left * 2.56f,down * 2.56f),  new Vector3(right * 2.56f,top * 2.56f));
    }
}
