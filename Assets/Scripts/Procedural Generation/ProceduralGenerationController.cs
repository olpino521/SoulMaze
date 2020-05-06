using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerationController : MonoBehaviour
{
    /// <summary>
    /// Determines the number of rooms. Ex. If this is 3, the dungeon will be 3x3. Meaning 9 rooms.
    /// </summary>
    [SerializeField] int dungeonSize;
    /// <summary>
    /// This gameobjects will be used to generate the rooms
    /// </summary>
    [SerializeField] GameObject[] roomModules;
    Room[,] rooms;
    int probabilityPivot = 5;
    private void Start()
    {
        rooms = new Room[dungeonSize,dungeonSize];
        GenerateInitialDungeon();
    }

    public void GenerateInitialDungeon()
    {
        for (int i = 0; i < dungeonSize; i++)
        {
            for (int j = 0; j < dungeonSize; j++)
            {
                int randomState = Random.Range(1, 10);
                int randomSize = Random.Range(0,roomModules.Length);
                RoomState newState = RoomState.DARK;
                probabilityPivot--;
                if (randomState > probabilityPivot)
                {
                    newState = RoomState.LIT;
                    probabilityPivot+=2;
                }

                //Add new room to position in the matrix
                Debug.Log(i+""+j+" "+newState);
                Debug.Log(newState);
            }
        }
    }
}
