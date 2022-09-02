using PEProtocol;
using UnityEngine;

public class BattleSys : SystemRoot
{

    public static BattleSys Instance = null;
    public PlayerCtrlWnd playerCtrlWnd;

    public BattleEndWnd battleEndWnd;
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

    public Vector2 GetDirInput()
    {
        return playerCtrlWnd.currentDir;
    }

  public void ReqReleaseSkill(int index) {
        battleMgr.ReqReleaseSkill(index);
    }
    

 public void EndBattle(bool isWin, int restHP) {
        playerCtrlWnd.SetWndState(false);
        GameRoot.Instance.dynamicWnd.RmvAllHpItemInfo();

        if (isWin) {
            double endTime = timerSvc.GetNowTime();
            //发送结算战斗请求
            //TODO
            GameMsg msg = new GameMsg {
                cmd = (int)CMD.ReqFBFightEnd,
                reqFBFightEnd = new ReqFBFightEnd {
                    win = isWin,
                    fbid = fbid,
                    resthp = restHP,
                    costtime = (int)(endTime - startTime)
                }
            };

            netSvc.SendMsg(msg);
        }
        else {
            SetBattleEndWndState(FBEndType.Lose);
        }
    }
    
    
    public void SetBattleEndWndState(FBEndType endType, bool isActive = true) {
        battleEndWnd.SetWndType(endType);
        battleEndWnd.SetWndState(isActive);
    }


}
