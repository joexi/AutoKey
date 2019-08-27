
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
        //AutoJob jump = new AutoJob();
        //jump.Job = delegate ()
        //{
        //    AutoJob.SetCursorPos(1920 / 2, 1080 / 2);
        //};
        //jump.Run();

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

        AutoJob loot = new AutoJob();
        loot.RandomMin = 1f;
        loot.RandomMax = 2f;
        loot.Job = delegate ()
        {

            for (int i = -400; i < 400; i += 20)
            {
                for (int j = -400; j < 400; j += 20)
                {
                    AutoJob.SetCursorPos(1920/2 + i, 1080 / 2 + j);
                    AutoJob.ClickKey(KeyCode.Mouse1);
                }
            }
        };
        loot.Run();

    }
}
