using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PEProtocol;

public class FubenSys : SystemRoot {


   public  static FubenSys Instance = null;

   public FubenWnd fubenWnd;
    
	public override void InitSys(){
		base.InitSys();
		Instance = this;
		PECommon.Log("Init FubenSys...");
	}
	void Start () {
		
	}


	public void EnterFuben(){
        SetFubenWndState();
	}

	public void SetFubenWndState(bool isActive = true) {
        fubenWnd.SetWndState(isActive);
    }
    public void RspFBFight(GameMsg msg) {
        GameRoot.Instance.SetPlayerDataByFBStart(msg.rspFBFight);
        MainCitySys.Instance.maincityWnd.SetWndState(false);
        SetFubenWndState(false);
        BattleSys.Instance.StartBattle(msg.rspFBFight.fbid);
    }
	
	// Update is called once per frame


		
	
}
