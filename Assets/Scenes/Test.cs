
using UnityEngine;
using System.Collections;
using System;


public class Test : MonoBehaviour
{

   

    private float time = 0;
    private bool running = false;
   
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 30;
        AutoJob jump = new AutoJob();
        jump.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Space);
        };
        jump.Run();

        AutoJob attack = new AutoJob();
        attack.RandomMin = 0.5f;
        attack.RandomMax = 1f;
        attack.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha2);
        };
        attack.Run();

    }
}
