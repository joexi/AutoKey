
using UnityEngine;
using System.Collections;
using System;


public class Test : MonoBehaviour
{
    private AutoJob loot;
    private AutoJob attack;
    private AutoJob jump;
    private AutoJob attack2;
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

        attack2 = new AutoJob();
        attack2.RandomMin = 30f;
        attack2.RandomMax = 50f;
        attack2.Job = delegate ()
        {
            AutoJob.ClickKey(KeyCode.Alpha5);
        };
        attack2.Run();
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
        attack2.Active = attack.Active;
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
