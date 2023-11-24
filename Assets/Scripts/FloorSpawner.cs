using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public static Action onSpawnFloor;
    public List<GameObject> floors;
    public GameObject startingFloor;
    Vector3 previousFloor;
    public List<float> offsets;

    private void Start()
    {

        onSpawnFloor += spawnFloor;
        Application.targetFrameRate = 60;

        previousFloor = startingFloor.GetComponent<PolygonCollider2D>().bounds.center;

        offsets.Add(-0.3f);
        offsets.Add(-4.68f);
        offsets.Add(2.01f);
        offsets.Add(4.09f);
        for(int i = 0; i < 49; i++)
        {
            spawnFloor();
        }

    }


    private void spawnFloor()
    {
        int randomNumber = UnityEngine.Random.Range(0,floors.Count);
   
        Vector3 newFloorBounds = floors[randomNumber].GetComponent<PolygonCollider2D>().bounds.size;

        Vector3 newFloorSpawnLocation = newFloorBounds; //size of new floor
        newFloorSpawnLocation.x += previousFloor.x; //adds x of previous floor to line it up

        //CREATE A SPECIFIC Y VALUE FOR EACH FLOOR AND ADD PREVIOUSFLOOR'S EXTENTS X TO MAKE SURE IT GOES IN THE RIGHT X SPOT AND MANUALLY FOR EACH FLOOR PUT IT IN ITS OWN Y SPOT
        newFloorSpawnLocation.y = offsets[randomNumber];
        
        Instantiate(floors[randomNumber], newFloorSpawnLocation, Quaternion.identity);

        previousFloor += newFloorBounds;
    }


    private void OnDestroy()
    {
        onSpawnFloor -= spawnFloor;
    }


}
