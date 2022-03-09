
using UnityEngine;
using System.Collections;
using System;


public class Test : MonoBehaviour
{
    private bool isRecording;
    private KeyCode recordingKeyCode;
    private AutoJob recordingJob;

    private AutoJob loot;
    private AutoJob jump;
    private AutoJob recordJob1;
    private AutoJob recordJob2;
    private AutoJob recordJob3;
    private AutoJob recordJob4;

    private AutoJob attack;
    private AutoJob attack2;
    private AutoJob attack3;
    private AutoJob attack4;
    private AutoJob attack5;
    private AutoJob attack6;
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

        var afk = new AutoJob();
        afk.RandomValue = 500;
        afk.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha8);
        };
        afk.Run();

        var afk2 = new AutoJob();
        afk2.RandomValue = 120f;
        afk2.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Return);
            AutoJob.ClickKey(KeyCode.Return);
        };
        afk2.Run();

        recordJob1 = new AutoJob();
        recordJob1.RandomValue = 0f;
        recordJob1.Run();

        recordJob2 = new AutoJob();
        recordJob2.RandomValue = 0f;
        recordJob2.Run();

        recordJob3 = new AutoJob();
        recordJob3.RandomValue = 0f;
        recordJob3.Run();

        recordJob4 = new AutoJob();
        recordJob4.RandomValue = 0f;
        recordJob4.Run();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Test"))
        {
            AutoJob.ClickKey(KeyCode.Return);
        }

        AutoJobPool.Instance.Running = GUILayout.Toggle(AutoJobPool.Instance.Running, "运行");
        AutoJobPool.Instance.AFK = GUILayout.Toggle(AutoJobPool.Instance.AFK, "防暂离");

        GUILayout.BeginHorizontal();
        WindowName = GUILayout.TextField(WindowName);
        if (GUILayout.Button("捕获窗口名"))
        {
            AutoJob.WindowName = WindowName;
            AutoJob.FindWindow();
        }
        GUILayout.EndHorizontal();

        ShowRecordField("录入按键:", recordJob1);
        ShowRecordField("录入按键:", recordJob2);
        ShowRecordField("录入按键:", recordJob3);
        ShowRecordField("录入按键:", recordJob4);

        ShowField("技能5:", attack);
        ShowField("技能6:", attack2);
        ShowField("技能7:", attack3);
        ShowField("技能8:", attack4);
        ShowField("技能9:", attack5);
        ShowField("技能10:", attack6);

        
        if (Event.current != null)
        {
            if (Event.current.type == EventType.KeyUp) {
                if (recordingJob != null)
                {
                    var code = Event.current.keyCode;
                    recordingJob.Key = code;
                    recordingJob.Job = () =>
                    {
                        AutoJob.ClickKey(code);
                    };
                    recordingJob = null;
                }
            }
        }
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

    private void ShowRecordField(string label, AutoJob job)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label);
        string str = GUILayout.TextField(job.RandomValue.ToString(), GUILayout.Width(100));
        float time = 0;
        float.TryParse(str, out time);
        job.RandomValue = time;
        if (GUILayout.Button("录入")) {
            recordingJob = job;
        }
        GUILayout.Label(job.Key.ToString());
        GUILayout.EndHorizontal();
    }
}
