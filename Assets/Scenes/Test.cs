
using UnityEngine;
using System.Collections;
using System;


public class Test : MonoBehaviour
{
    private AutoJob loot;
    private AutoJob attack;
    private AutoJob jump;
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 30;
        jump = new AutoJob();
        jump.Job = delegate ()
        {
            AutoJob.SetCursorPos(1920 / 2, 1080 / 2);
        };
        jump.Run();

        loot = new AutoJob();
        loot.RandomMin = 2;
        loot.RandomMax = 3;
        loot.Job = delegate ()
        {
            AutoJob.ClickMouse();
        };
        loot.Run();

        attack = new AutoJob();
        attack.RandomMin = 0.5f;
        attack.RandomMax = 1f;
        attack.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha6);
        };
        attack.Run();
    }

    private void OnGUI()
    {
        if (AutoJobPool.Instance.Running)
        {
            GUILayout.Label("按F12停止");
        }
        else {
            GUILayout.Label("按F12开启");
        }
        loot.Active = GUILayout.Toggle(loot.Active, "拾取");
        attack.Active = GUILayout.Toggle(attack.Active, "自动战斗");
        jump.Active = GUILayout.Toggle(jump.Active, "防暂离");
        

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F12))
        {
            AutoJobPool.Instance.Running = !AutoJobPool.Instance.Running;
        }
    }
}
