using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitQuest : Quest
{
    [SerializeField]
    float timer;









    //void Update()
    //{
    //    timer -= Time.deltaTime;
    //}


    public override bool CheckCondition()
    {
        timer -= Time.deltaTime;
        return timer<=0;
    }
}
