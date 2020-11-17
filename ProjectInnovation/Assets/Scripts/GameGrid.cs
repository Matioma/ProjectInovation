using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField]
    int gridSizeX=10;
    [SerializeField]
    int gridSizeZ=10;
    
    
    [SerializeField]
    int gridElementSize = 10;

    [SerializeField]
    GameObject[,] grid;






    private void OnValidate()
    {
        grid = new GameObject[gridSizeX, gridSizeZ];
        for (int i = 0; i < gridSizeX; i++) {
            for (int j = 0; j < gridSizeZ; j++) {
                grid[i, j] = null;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < gridSizeZ; x++) {
            Vector3 startPosition = new Vector3(x * gridElementSize, 0, 0) + transform.position;
            Vector3 endPosition = new Vector3(x * gridElementSize, 0, gridSizeZ * gridElementSize) + transform.position;
            Gizmos.DrawLine(startPosition, endPosition);
        }
        for (int z = 0; z < gridSizeZ; z++)
        {
            Vector3 startPosition = new Vector3(0, 0, z*gridElementSize) + transform.position;
            Vector3 endPosition = new Vector3(gridSizeX * gridElementSize, 0, z * gridElementSize) + transform.position;
            Gizmos.DrawLine(startPosition, endPosition);
        }
    }


    public Vector3 GetCellCenter(int x, int z) {
        if (x < 0 || x >= gridSizeX) { throw new System.IndexOutOfRangeException(); }
        if (z < 0 || z >= gridSizeZ) { throw new System.IndexOutOfRangeException(); }

        float xPos = transform.position.x + x * gridElementSize + gridElementSize / 2;
        float zPos = transform.position.z + z * gridElementSize + gridElementSize / 2;

        return new Vector3(xPos, 0, zPos);
    }

    public bool IsCellEmpty(int x, int z){
        return grid[x,z] == null;
    }

    public void PlaceGameObjectOnCell(GameObject objectToPlace, int x, int z) {
        if (IsCellEmpty(x, z)) {
            grid[x, z] = objectToPlace;
        }
        objectToPlace.transform.position = GetCellCenter(x, z);
    }

    public void RemoveObjectFromCell(int x, int z) {
        grid[x, z] = null;
    }
}


public struct GridCollision { 
        



} 
