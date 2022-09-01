using PEProtocol;
using UnityEngine;

    public class BattleSys: SystemRoot {
     
    public static BattleSys Instance = null;

    public PlayerCtrlWnd playerCtrlWnd;


    private int fbid;
    private double startTime;

    public override void InitSys() {
        base.InitSys();
        Instance = this;
        PECommon.Log("Init BattleSys...");
    }

    public void StartBattle(int mapid) {
        fbid = mapid;
        // GameObject go = new GameObject {
        //     name = "BattleRoot"
        // };

        // go.transform.SetParent(GameRoot.Instance.transform);
        // battleMgr = go.AddComponent<BattleMgr>();

        // battleMgr.Init(mapid, () => {
        //     startTime = timerSvc.GetNowTime();
        // });
       playerCtrlWnd.SetWndState(true);
    }



    public void DestroyBattle() {
        SetPlayerCtrlWndState(false);
       // SetBattleEndWndState(FBEndType.None, false);
       // GameRoot.Instance.dynamicWnd.RmvAllHpItemInfo();
       // Destroy(battleMgr.gameObject);
    }

    public void SetPlayerCtrlWndState(bool isActive = true) {
       playerCtrlWnd.SetWndState(isActive);
    }


    }
   
     
