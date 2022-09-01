using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSys : SystemRoot
{

    public static BattleSys Instance = null;
    public PlayerCtrlWnd playerCtrlWnd;

    public BattleMgr battleMgr;

    private int fbid;
    private double startTime;

    public override void InitSys()
    {
        base.InitSys();
        Instance = this;
        PECommon.Log("BattleSys TestSys...");

    }


    public void StartBattle(int mapid)
    {
        fbid = mapid;
        GameObject go = new GameObject
        {
            name = "BattleRoot"
        };

        go.transform.SetParent(GameRoot.Instance.transform);
        battleMgr = go.AddComponent<BattleMgr>();

        battleMgr.Init(mapid, () =>
        {
            startTime = timerSvc.GetNowTime();
        });
        SetPlayerCtrlWndState();
    }


    public void SetPlayerCtrlWndState(bool isActive = true)
    {
        playerCtrlWnd.SetWndState(isActive);
    }

    public void SetMoveDir(Vector2 dir)
    {
        battleMgr.SetSelfPlayerMoveDir(dir);
    }

}
