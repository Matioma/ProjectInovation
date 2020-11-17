using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedPlayerController : MonoBehaviour, IPlayerActions
{
    [SerializeField]
    GameGrid gameGrid;

    [SerializeField]
    Vector2Int position;
    Vector2Int direction;



    void Start() {
        direction = new Vector2Int((int)transform.forward.x, (int)transform.forward.z);
        gameGrid.PlaceGameObjectOnCell(this.gameObject, position.x, position.y);
    }

    public void MoveBackwards(float speed)
    {

        gameGrid.RemoveObjectFromCell(position.x, position.y);
        position = position - direction;
        gameGrid.PlaceGameObjectOnCell(this.gameObject, position.x, position.y);
    }
    public void MoveForward(float speed)
    {
        gameGrid.RemoveObjectFromCell(position.x, position.y);
        position = position + direction;
        gameGrid.PlaceGameObjectOnCell(this.gameObject, position.x, position.y);
    }

    public void MoveLeft(float speed)
    {
       throw new System.NotImplementedException();
    }




    public void MoveRight(float speed)
    {
        throw new System.NotImplementedException();
    }

    public void TurnLeft(float amount = 90)
    {
        if (direction.x > 0)
        {
            direction.x = 0;
            direction.y = 1;
        }
        else if (direction.y < 0)
        {
            direction.x = 1;
            direction.y = 0;
        }
        else if (direction.x < 0)
        {
            direction.x = 0;
            direction.y = -1;
        }
        else if (direction.y > 0)
        {
            direction.x = -1;
            direction.y = 0;
        }

        transform.LookAt(transform.position + new Vector3(direction.x, 0, direction.y));
    }

    public void TurnRight(float amount = 90)
    {
        if (direction.x > 0)
        {
            direction.x = 0;
            direction.y = -1;
        }
        else if (direction.y < 0)
        {
            direction.x = -1;
            direction.y = 0;
        }
        else if (direction.x < 0)
        {
            direction.x = 0;
            direction.y = 1;
        }
        else if (direction.y > 0)
        {
            direction.x = 1;
            direction.y = 0;
        }

        transform.LookAt(transform.position + new Vector3(direction.x, 0, direction.y));
    }
}
