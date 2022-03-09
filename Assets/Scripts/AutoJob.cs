﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class AutoJob {
    public static string WindowName = "魔兽世界";
    public bool IfShow = false;
    public bool IfHide = false;
    public Action Job;
    public bool Active = true;
    public float RandomValue = 10;
    public KeyCode Key;
    public List<AutoJob> ChildJobs = new List<AutoJob>();
    private float timeInterval;
    public void Update() {
        if (!Active || this.RandomValue == 0) {
            return;
        }
        timeInterval -= Time.deltaTime;
        if (timeInterval <= 0) {
            timeInterval = UnityEngine.Random.Range(RandomValue * 0.7f, RandomValue * 1.3f);
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
        if (IfHide)
        {
            HideWindow();
        }
        foreach (var job in ChildJobs) {
            job.Invoke();
        }
    }

    public static void FindWindow() {
        IntPtr myIntPtr = FindWindow(null, "魔兽世界");
        SetWindowText((int)myIntPtr, WindowName);
    }

    void ActiveWindow()
    {
        IntPtr myIntPtr = FindWindow(null, WindowName);
        SetForegroundWindow(myIntPtr);
    }

    void HideWindow()
    {
        IntPtr myIntPtr = FindWindow(null, WindowName);
        ShowWindow(myIntPtr, 2);
    }

    public static void BringWindowToTop(string windowName)
    {
        IntPtr myIntPtr = FindWindow(null, windowName);
        BringWindowToTop(myIntPtr);
    }

    const int WM_KEYDOWN = 0x100;
    const int WM_KEYUP = 0x101;
    const int WM_RBUTTONDOWN = 0x0204;
    const int WM_RBUTTONUP = 0x0205;
    const int WM_MOUSEMOVE = 0x0200;
    public static void ClickKey(KeyCode code)
    {
        IntPtr myIntPtr = FindWindow(null, WindowName);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)code, 0);
        System.Threading.Thread.Sleep(100 + UnityEngine.Random.Range(20, 100));
        SendMessage(myIntPtr, WM_KEYUP, (uint)code, 0);
    }


    public static void SelectTarget()
    {
        IntPtr myIntPtr = FindWindow(null, WindowName);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.KeypadEnter, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.KeypadEnter, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)47, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)47, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.S, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.S, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.T, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.T, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.A, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.A, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.R, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.R, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.T, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.T, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.A, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.A, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.T, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.T, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.T, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.T, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.A, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.A, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.C, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.C, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.K, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.K, 0);
        SendMessage(myIntPtr, WM_KEYDOWN, (uint)KeyCode.KeypadEnter, 0);
        SendMessage(myIntPtr, WM_KEYUP, (uint)KeyCode.KeypadEnter, 0);
    }

    static int rand = 0;
    public static void Loot()
    {
        IntPtr myIntPtr = FindWindow(null, WindowName);
        
        RECT r = new RECT();
        GetWindowRect(myIntPtr, ref r);
        int x = (r.Left + r.Right) / 2;
        int y = (r.Top + r.Bottom) / 2;
        rand = rand % 50;
        rand ++;
        x += (rand % 9 * 30 - 120);
        y += (rand / 9 * 30 - 120);
        x += UnityEngine.Random.Range(-5, 5);
        y += UnityEngine.Random.Range(-5, 5);
        uint result = (uint)(x << 16 + y);
        SetCursorPos(x, y);
        System.Threading.Thread.Sleep(100 + UnityEngine.Random.Range(20, 100));
        SendMessage(myIntPtr, WM_RBUTTONDOWN, 0, 0);
        System.Threading.Thread.Sleep(100 + UnityEngine.Random.Range(20, 100));
        SendMessage(myIntPtr, WM_RBUTTONUP, 0, 0);
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
    //public static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
    public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr FindWindow(string strClass, string strWindow);

    [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
    public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void Keybd_event(byte bvk, byte bScan, int dwFlags, int dwExtraInfo);

    
    [DllImport("user32.dll")]
    private static extern bool BringWindowToTop(IntPtr hWnd);

    //[DllImport("User32.dll", EntryPoint = "SendMessage")]
    //private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);

    [DllImport("User32.dll", EntryPoint = "PostMessage")]
    private static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, string lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessageA")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

    [DllImport("user32.dll", EntryPoint = "SetWindowText", CharSet = CharSet.Ansi)]
    public static extern int SetWindowText(int hwnd, string lpString);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left; //最左坐标
        public int Top; //最上坐标
        public int Right; //最右坐标
        public int Bottom; //最下坐标
    }
}
