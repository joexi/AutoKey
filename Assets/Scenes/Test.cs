
using UnityEngine;
using System.Collections;
using System;


public class Test : MonoBehaviour
{
    private AutoJob loot;
    private AutoJob attack;
    private AutoJob attack2;
    private AutoJob attack3;
    private AutoJob attack4;
    private AutoJob selectTarget;
    private AutoJob jump;
    private float MouseMoveTime = 0;
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 30;
        jump = new AutoJob();
        jump.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Space);
        };
        jump.Run();

        loot = new AutoJob();
        loot.RandomValue = 5;
        loot.Job = delegate ()
        {
            if (MouseMoveTime <= 0) {
                AutoJob.Loot();
            }
        };
        loot.Run();

        attack = new AutoJob();
        attack.RandomValue = 60f;
        attack.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha5);
        };
        attack.Run();

        attack2 = new AutoJob();
        attack2.RandomValue = 2f;
        attack2.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha6);
        };
        attack2.Run();

        attack3 = new AutoJob();
        attack3.RandomValue = 60f;
        attack3.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha7);
        };
        attack3.Run();

        attack4 = new AutoJob();
        attack4.RandomValue = 60f;
        attack4.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha8);
        };
        attack4.Run();


        selectTarget = new AutoJob();
        selectTarget.RandomValue = 0f;
        selectTarget.Job = delegate ()
        {
            AutoJob.SelectTarget();
        };
        selectTarget.Run();

    }

    private void OnGUI()
    {
        if (AutoJobPool.Instance.Running)
        {
            if (GUILayout.Button("点击停止"))
            {
                AutoJobPool.Instance.Running = false;
            }
        }
        else
        {
            if (GUILayout.Button("点击开始"))
            {
                AutoJobPool.Instance.Running = true;
            }
        }

        loot.Active = GUILayout.Toggle(loot.Active, "拾取");
        ShowField("技能5:", attack);
        ShowField("技能6:", attack2);
        ShowField("技能7:", attack3);
        ShowField("技能8:", attack4);
        ShowField("跳跃间隔:", jump);
        ShowField("选目标间隔:", selectTarget);

       // if()
    }

    private void ShowField(string label, AutoJob job) {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label);
        string str = GUILayout.TextField(job.RandomValue.ToString());
        int time = 0;
        int.TryParse(str, out time);
        job.RandomValue = time;
        GUILayout.EndHorizontal();
    }

    private void Update()
    {

    }
}
