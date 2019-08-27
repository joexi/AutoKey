
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


public class Test : MonoBehaviour
{

    [DllImport("user32.dll")]
    private static extern int SetCursorPos(int x, int y);

    [DllImport("user32.dll")]
    static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern IntPtr FindWindow(string strClass, string strWindow);

    [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
    public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void Keybd_event(byte bvk, byte bScan, int dwFlags, int dwExtraInfo);

    private float time = 0;
    private bool running = false;
    private string windowName = "魔兽世界";

    [Flags]
    enum MouseEventFlag : uint
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
    
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 30;
    }

    void ClickKey(KeyCode code)
    {
        Keybd_event((byte)code, 0, 0, 0);
        Keybd_event((byte)code, 0, 2, 0);
    }
   
    void ShowWindow() {

        IntPtr myIntPtr = FindWindow(null, windowName);
        SetForegroundWindow(myIntPtr);
    }

    void HideWindow()
    {
        IntPtr myIntPtr = FindWindow(null, windowName);
        ShowWindow(myIntPtr, 2);
    }

    void Update()
    {

        time -= Time.deltaTime;
        if (time < 0)
        {
            time = UnityEngine.Random.Range(3, 5);
            ShowWindow();
            ClickKey(KeyCode.Space);
            HideWindow();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            running = !running;
        }
    }
}
