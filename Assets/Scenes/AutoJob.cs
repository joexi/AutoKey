﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class AutoJob {
    public string WindowName = "魔兽世界";
    public bool IfShow = true;
    public bool IfHide = true;
    public Action Job;
    public float RandomMax = 10;
    public float RandomMin = 18;

    private float timeInterval;
    public void Update() {
        timeInterval -= Time.deltaTime;
        if (timeInterval <= 0) {
            timeInterval = UnityEngine.Random.Range(RandomMin, RandomMax);
            this.Invoke();
        }
    }

    public void Run() {
        AutoJobPool.Instance.AddJob(this);
    }

    public void Invoke() {
        if (IfShow)
        {
            ActiveWindow();
        }
        if (Job != null)
        {
            Job();
        }
        //if (IfHide)
        //{
        //    HideWindow();
        //}
    }

    void ActiveWindow()
    {
        IntPtr myIntPtr = FindWindow(null, this.WindowName);
        Debug.LogError(myIntPtr + " " + this.WindowName);
        SetForegroundWindow(myIntPtr);
    }

    void HideWindow()
    {
        IntPtr myIntPtr = FindWindow(null, this.WindowName);
        ShowWindow(myIntPtr, 2);
    }

    public static void ClickKey(KeyCode code)
    {
        Keybd_event((byte)code, 0, 0, 0);
        Keybd_event((byte)code, 0, 2, 0);
    }

    [Flags]
    public enum MouseEventFlag : uint
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        XDown = 0x0080,
        XUp = 0x0100,
        Wheel = 0x0800,
        VirtualDesk = 0x4000,
        Absolute = 0x8000
    }

    [DllImport("user32.dll")]
    public static extern int SetCursorPos(int x, int y);

    [DllImport("user32.dll")]
    public static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr FindWindow(string strClass, string strWindow);

    [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
    public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void Keybd_event(byte bvk, byte bScan, int dwFlags, int dwExtraInfo);
}