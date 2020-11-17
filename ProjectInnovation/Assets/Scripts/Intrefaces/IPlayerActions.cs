﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerActions
{
    void MoveForward(float speed);
    void MoveLeft(float speed);
    void MoveRight(float speed);

    void MoveBackwards(float speed);

    void TurnLeft(float amount = 90);
    void TurnRight(float amount = 90);
}