using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    [Header("Map Settings")]
    public Transform startPt;
    public GameObject[] tiles;
    public int tileSize = 4;
    public Vector3 offset = new Vector3(0, 0, 0);

        int[,] grid = new int[,]
        {
            {1, 2, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 1},
            {1, 0, 1, 1, 1, 1, 1, 1, 1, 2, 1, 0, 1, 0, 1},
            {1, 0, 1, 3, 0, 0, 2, 0, 0, 0, 1, 3, 1, 0, 2},
            {1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1},
            {0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            {1, 1, 2, 0, 1, 1, 1, 0, 1, 1, 2, 1, 1, 0, 1},
            {1, 3, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 1, 0, 0, 0, 1, 3, 1, 0, 0, 0, 0, 0, 1},
            {1, 0, 2, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 2},
            {2, 0, 1, 0, 1, 3, 0, 0, 0, 0, 1, 3, 1, 0, 1},
            {1, 0, 1, 0, 1, 1, 1, 0, 1, 2, 1, 0, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 2, 1, 1, 1, 0, 1, 1, 1, 1, 2, 1, 1}
        };



    [Header("Object Settings")]
    public GameObject carrot;
    public GameObject player;
    public Transform playerStart;



    public void Start(){
        CreateMap(grid);
    }

    // generate a map based on the 2D array
    public void CreateMap(int[,] m){
        for (int x = 0; x < m.GetLength(0); x++)
        {
            for (int z = 0; z < m.GetLength(1); z++)
            {
                GameObject tile = null;
                if (m[x, z] == 1){
                    tile = Instantiate(tiles[0], Offset(new Vector3(x * tileSize, 0, z * tileSize)), Quaternion.identity);
                }
                else if (m[x, z] == 2){
                    tile = Instantiate(tiles[1], Offset(new Vector3(x * tileSize, 0, z * tileSize)), Quaternion.identity);
                }
                else if (m[x, z] == 3){
                    tile = Instantiate(carrot, Offset(new Vector3(x * tileSize, 2, z * tileSize)), Quaternion.identity);
                }

                if(tile != null)
                    tile.transform.parent = startPt;
            }
        }

        // Place the player at the starting position
        player.transform.position = playerStart.position;
        player.GetComponent<PlayerMovement>().score = 0;
    }

    public Vector3 Offset(Vector3 p){
        Vector3 sp = startPt.position;
        return new Vector3(sp.x + (p.x) + offset.x, p.y + sp.y + offset.y, sp.z + (p.z) + offset.z);
    }


    public void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            foreach (Transform child in startPt){
                Destroy(child.gameObject);
            }
            CreateMap(grid);
        }
    }
}
