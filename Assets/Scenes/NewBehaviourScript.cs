
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


public class NewBehaviourScript : MonoBehaviour {

[DllImport("user32.dll")]
    private static extern int SetCursorPos(int x, int y);
    [DllImport("user32.dll")]
    static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);


//下面这个枚举也来自user32.dll
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



 [DllImport("user32.dll", EntryPoint = "keybd_event")]

    public static extern void Keybd_event(

        byte bvk,//虚拟键值 ESC键对应的是27

        byte bScan,//0

        int dwFlags,//0为按下，1按住，2释放

        int dwExtraInfo//0

        );



float time2 = 0;
	float time = 0;
	// Use this for initialization
	void Start () {
		UnityEngine.Application.targetFrameRate = 30;
	}
	bool doit= false;
	void Update()
    {
  
		time2 -= 0.0333f;
		if(time2 < 0) {
			time2 = UnityEngine.Random.Range(50,60);
			Keybd_event(90,0,0,0);
        		Keybd_event(90, 0, 1, 0);
        		Keybd_event(90, 0, 2, 0);
			    Keybd_event(32,0,0,0);
        		Keybd_event(32, 0, 1, 0);
        		Keybd_event(32, 0, 2, 0);
		}

		if (Input.GetKey(KeyCode.Space))
        	{
			doit = !doit;
		}
		
            	time -= 0.03333f;		

		if (time  < 0)
            
		{	
 
            		time = UnityEngine.Random.Range(2,3);
 			//SetCursorPos(20, 20);
                
			mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
			mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
               		}
	}
}
