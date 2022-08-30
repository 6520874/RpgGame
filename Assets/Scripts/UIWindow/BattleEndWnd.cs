
using UnityEngine;
using UnityEngine.UI;
    public class BattleEndWnd: WindowRoot 
    {

   #region UI Define
    public Transform rewardTrans;
    public Button btnClose;
    public Button btnExit;
    public Button btnSure;
    public Text txtTime;
    public Text txtRestHP;
    public Text txtReward;
    public Animation ani;
    #endregion


  private FBEndType endType = FBEndType.None;


    protected override void InitWnd() {
        base.InitWnd();

        RefreshUI();
    }


    private void RefreshUI(){
      
      switch (endType) {
             case FBEndType.Pause:
                SetActive(rewardTrans, false);
                SetActive(btnExit.gameObject);
                SetActive(btnClose.gameObject);
                break;
        //    case FBEndType.Win:
        //           SetActive(rewardTrans, false);
        //         SetActive(btnExit.gameObject, false);
        //         SetActive(btnClose.gameObject, false);
        //             case FBEndType.Lose:
        //         SetActive(rewardTrans, false);
        //         SetActive(btnExit.gameObject);
        //         SetActive(btnClose.gameObject, false);
        //         audioSvc.PlayUIAudio(Constants.FBLose);
        //         break;


             }

    }

    public void ClickClose() {
        // audioSvc.PlayUIAudio(Constants.UIClickBtn);
        // BattleSys.Instance.battleMgr.isPauseGame = false;
        // SetWndState(false);
    }
    

    public void ClickExitBtn() {
        // audioSvc.PlayUIAudio(Constants.UIClickBtn);
        // //进入主城，销毁当前战斗
        // MainCitySys.Instance.EnterMainCity();
        // BattleSys.Instance.DestroyBattle();
    }


    public void ClickSureBtn() {
        // audioSvc.PlayUIAudio(Constants.UIClickBtn);
        // //进入主城，销毁当前战斗
        // MainCitySys.Instance.EnterMainCity();
        // BattleSys.Instance.DestroyBattle();
        // //打开副本界面
        // FubenSys.Instance.EnterFuben();
    }


    public void SetWndType(FBEndType endType) {
        this.endType = endType;
    }


 
     private int fbid;
    private int costtime;
    private int resthp;
    public void SetBattleEndData(int fbid, int costtime, int resthp) {
        this.fbid = fbid;
        this.costtime = costtime;
        this.resthp = resthp;
    }



    }

    public enum FBEndType {
    None,
    Pause,
    Win,
    Lose
}
