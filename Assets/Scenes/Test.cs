
using UnityEngine;
using System.Collections;
using System;


public class Test : MonoBehaviour
{

   

    private float time = 0;
    private bool running = false;
   
    void Start()
    {
        AutoJob.BringWindowToTop("此电脑");
        UnityEngine.Application.targetFrameRate = 30;
        //AutoJob jump = new AutoJob();
        //jump.Job = delegate ()
        //{
        //    AutoJob.SetCursorPos(1920 / 2, 1080 / 2);
        //};
        //jump.Run();

        AutoJob jump = new AutoJob();
        //jump.RandomMin = 1;
        //jump.RandomMax = 2;
        jump.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Space);
        };
        jump.Run();

        AutoJob aaa = new AutoJob();
        aaa.RandomMin = 30;
        aaa.RandomMax = 40;
        aaa.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha5);
        };
        aaa.Run();



        AutoJob attack = new AutoJob();
        attack.RandomMin = 0.5f;
        attack.RandomMax = 1f;
        attack.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha6);
        };
        attack.Run();

        //AutoJob skillX = new AutoJob();
        //skillX.RandomMin = 10f;
        //skillX.RandomMax = 12f;
        //skillX.Job = delegate ()
        //{
        //    AutoJob.mouse_event((int)AutoJob.MouseEventFlag.LeftDown, 0, 0, 0, 0);
        //    AutoJob.mouse_event((int)AutoJob.MouseEventFlag.LeftUp, 0, 0, 0, 0);
        //    AutoJob.mouse_event((int)AutoJob.MouseEventFlag.LeftDown, 0, 0, 0, 0);
        //    AutoJob.mouse_event((int)AutoJob.MouseEventFlag.LeftUp, 0, 0, 0, 0);
        //    //AutoJob.ClickKey(KeyCode.Mouse0);
        //    //AutoJob.ClickKey(KeyCode.Mouse0);
        //};
        //skillX.Run();

        //AutoJob loot = new AutoJob();
        //loot.RandomMin = 60f;
        //loot.RandomMax = 80f;
        //loot.Job = delegate ()
        //{
        //    for (int i = -400; i < 400; i += 20)
        //    {
        //        for (int j = -400; j < 400; j += 20)
        //        {
        //            AutoJob.SetCursorPos(1920 / 2 + i, 1080 / 2 + j);
        //            AutoJob.mouse_event((int)AutoJob.MouseEventFlag.RightDown, 0, 0, 0, 0);
        //            AutoJob.mouse_event((int)AutoJob.MouseEventFlag.RightUp, 0, 0, 0, 0);
        //        }
        //    }
        //};
        //loot.Run();

    }
}
