using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJobPool : MonoBehaviour {

    private static AutoJobPool instance = null;
    public static AutoJobPool Instance 
    {
        get {
            if (instance == null) {
                GameObject go = new GameObject("AutoJobPool");
                instance = go.AddComponent<AutoJobPool>();
            }
            return instance;
        }
    }
    public List<AutoJob> JobList = new List<AutoJob>();
    public bool Running = false;
    public bool AFK = false;
    public void AddJob(AutoJob job) {
        if (!JobList.Contains(job)) {
            JobList.Add(job);
        }
    }

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Running) {
            for (int i = 0; i < JobList.Count; i++)
            {
                JobList[i].Update();
            }
        }
    }
}
