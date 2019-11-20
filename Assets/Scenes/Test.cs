
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
    private AutoJob attack5;
    private AutoJob attack6;
    private AutoJob jump;
    private float MouseMoveTime = 0;
    private string WindowName = "1";
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
        loot.RandomValue = 0f;
        loot.Job = delegate ()
        {
            if (MouseMoveTime <= 0) {
                AutoJob.Loot();
            }
        };
        loot.Run();

        attack = new AutoJob();
        attack.RandomValue = 0f;
        attack.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha5);
        };
        attack.Run();

        attack2 = new AutoJob();
        attack2.RandomValue = 0f;
        attack2.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha6);
        };
        attack2.Run();

        attack3 = new AutoJob();
        attack3.RandomValue = 0f;
        attack3.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha7);
        };
        attack3.Run();

        attack4 = new AutoJob();
        attack4.RandomValue = 0f;
        attack4.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha8);
        };
        attack4.Run();


        attack5 = new AutoJob();
        attack5.RandomValue = 0f;
        attack5.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha9);
        };
        attack5.Run();

        attack6 = new AutoJob();
        attack6.RandomValue = 0f;
        attack6.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha0);
        };
        attack6.Run();

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
        GUILayout.BeginHorizontal();
        WindowName = GUILayout.TextField(WindowName);
        if (GUILayout.Button("替换窗口名"))
        {
            AutoJob.WindowName = WindowName;
            AutoJob.FindWindow();
        }
        GUILayout.EndHorizontal();
        ShowField("拾取:", loot);
        ShowField("技能5:", attack);
        ShowField("技能6:", attack2);
        ShowField("技能7:", attack3);
        ShowField("技能8:", attack4);
        ShowField("技能9:", attack5);
        ShowField("技能10:", attack6);
        ShowField("跳跃间隔:", jump);
    }

    private void ShowField(string label, AutoJob job) {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label);
        string str = GUILayout.TextField(job.RandomValue.ToString());
        float time = 0;
        float.TryParse(str, out time);
        job.RandomValue = time;
        GUILayout.EndHorizontal();
    }

    private void Update()
    {

    }
}
