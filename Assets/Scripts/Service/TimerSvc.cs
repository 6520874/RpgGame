/****************************************************
	文件：TimerSvc.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/02/24 5:56   	
	功能：计时服务
*****************************************************/

using System;

public class TimerSvc : SystemRoot {
    public static TimerSvc Instance = null;

    private PETimer pt = null;

    public void InitSvc() {
        Instance = this;
        pt = new PETimer();

        //设置日志输出
        pt.SetLog((string info) => {
            PECommon.Log(info);
        });

        PECommon.Log("Init TimerSvc...");
    }

    public void Update() {
        if (pt!=null ){
        pt.Update();
        }
      
    }

    public int AddTimeTask(Action<int> callback, double delay, PETimeUnit timeUnit = PETimeUnit.Millisecond, int count = 1) {
        return pt.AddTimeTask(callback, delay, timeUnit, count);
    }

    public double GetNowTime() {
        return pt.GetMillisecondsTime();
    }

    public void DelTask(int tid) {
        pt.DeleteTimeTask(tid);
    }

}