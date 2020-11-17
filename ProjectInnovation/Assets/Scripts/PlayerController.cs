using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IPlayerActions
{
    Rigidbody rigidbody;
    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void MoveBackwards(float speed)
    {
        rigidbody.velocity = transform.forward * -speed;
    }

    public void MoveForward(float speed)
    {
        rigidbody.velocity =transform.forward* speed;
    }

    public void MoveLeft(float speed)
    {
        rigidbody.velocity = transform.right * -speed;
    }

    public void MoveRight(float speed)
    {
        rigidbody.velocity = transform.right * speed;
    }
}
