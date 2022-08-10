
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour {



    protected virtual void InitWnd() {
        // resSvc = ResSvc.Instance;
        // audioSvc = AudioSvc.Instance;
        // netSvc = NetSvc.Instance;
        // timerSvc = TimerSvc.Instance;
    }


    protected void SetText(Text txt, string context = "") {
        txt.text = context;
    }
    protected void SetText(Transform trans, int num = 0) {
        SetText(trans.GetComponent<Text>(), num);
    }
    protected void SetText(Transform trans, string context = "") {
        SetText(trans.GetComponent<Text>(), context);
    }
    protected void SetText(Text txt, int num = 0) {
        SetText(txt, num.ToString());
    }
    
}