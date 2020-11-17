using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPlayerActions))]
public class PlayerInputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            GetComponent<IPlayerActions>().MoveForward(10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<IPlayerActions>().MoveBackwards(10);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<IPlayerActions>().MoveRight(10);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<IPlayerActions>().MoveLeft(10);
        }
    }

}
