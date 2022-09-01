using System.ComponentModel.Design;
/****************************************************
    文件：MainCitySys.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：2018/12/12 6:49:4
	功能：主城业务系统
*****************************************************/

using PEProtocol;
using UnityEngine;
using UnityEngine.AI;

public class MainCitySys : SystemRoot {
    public static MainCitySys Instance = null;

    public MainCityWnd maincityWnd;
    public InfoWnd infoWnd;

    public BuyWnd buyWnd;
    public PlayerWnd ssss;

    private PlayerController playerCtrl;
    private Transform charCamTrans;
    private AutoGuideCfg curtTaskData;
    private Transform[] npcPosTrans;
    private NavMeshAgent nav;
    private bool isNavGuide = false;
    public override void InitSys() {
        base.InitSys();

        Instance = this;
        PECommon.Log("Init MainCitySys...");
    }
  

    public void RunTask(AutoGuideCfg agc) {


    }

    
    public void OpenStrongWnd() {
 
    }

    public void RspStrong(GameMsg msg) {
         

    }

        public void RspBuy(GameMsg msg) {
        RspBuy rspBuy = msg.rspBuy;
        GameRoot.Instance.SetPlayerDataByBuy(rspBuy);
        GameRoot.AddTips("购买成功");

        maincityWnd.RefreshUI();
        buyWnd.SetWndState(false);

        if (msg.pshTaskPrgs != null) {
            GameRoot.Instance.SetPlayerDataByTaskPsh(msg.pshTaskPrgs);
            // if (taskWnd.GetWndState()) {
            //     taskWnd.RefreshUI();
            // }
        }

    }

    public void PshPower(GameMsg msg) {
        PshPower data = msg.pshPower;
        GameRoot.Instance.SetPlayerDataByPower(data);
        // if (maincityWnd.GetWndState()) {
        //     maincityWnd.RefreshUI();
        // }
    }


     public void EnterFuben() {
        StopNavTask();
        FubenSys.Instance.EnterFuben();
    }


   public void SetMoveDir(Vector2 dir) {
        StopNavTask();

        if (dir == Vector2.zero) {
            playerCtrl.SetBlend(Constants.BlendIdle);
        }
        else {
            playerCtrl.SetBlend(Constants.BlendMove);
        }
        playerCtrl.Dir = dir;
    }

   
     private void StopNavTask() {
        if (isNavGuide) {
            isNavGuide = false;

            nav.isStopped = true;
            nav.enabled = false;
           playerCtrl.SetBlend(Constants.BlendIdle);
        }
    }

    public void EnterMainCity(){

    PECommon.Log(" EnterMainCity(...");
     MapCfg  mapData =  resSvc.GetMapCfg(Constants.MainCityMapID);

         resSvc.AsyncLoadScene(mapData.sceneName, () => {
            PECommon.Log("Enter MainCity...");

            // 加载游戏主角
            LoadPlayer(mapData);

            //打开主城场景UI
            maincityWnd.SetWndState();

            GameRoot.Instance.GetComponent<AudioListener>().enabled = false;
            //播放主城背景音乐
            audioSvc.PlayBGMusic(Constants.BGMainCity);

            GameObject map = GameObject.FindGameObjectWithTag("MapRoot");
            
            // MainCityMap mcm = map.GetComponent<MainCityMap>();
            // npcPosTrans = mcm.NpcPosTrans;

            //设置人物展示相机
            if (charCamTrans != null) {
                charCamTrans.gameObject.SetActive(false);
            }
        });

    }


        private void LoadPlayer(MapCfg mapData) {
        GameObject player = resSvc.LoadPrefab(PathDefine.AssissnCityPlayerPrefab, true);
        player.transform.position = mapData.playerBornPos;
        player.transform.localEulerAngles = mapData.playerBornRote;
        player.transform.localScale = new Vector3(1.5F, 1.5F, 1.5F);

        //相机初始化
        Camera.main.transform.position = mapData.mainCamPos;
        Camera.main.transform.localEulerAngles = mapData.mainCamRote;

        playerCtrl = player.GetComponent<PlayerController>();
        playerCtrl.Init();
        nav = player.GetComponent<NavMeshAgent>();
    }
  
    public void OpenInfoWnd() {
        StopNavTask();

        if (charCamTrans == null) {
            charCamTrans = GameObject.FindGameObjectWithTag("CharShowCam").transform;
        }

        //设置人物展示相机相对位置
        charCamTrans.localPosition = playerCtrl.transform.position + playerCtrl.transform.forward * 3.8f + new Vector3(0, 1.2f, 0);
        charCamTrans.localEulerAngles = new Vector3(0, 180 + playerCtrl.transform.localEulerAngles.y, 0);
        charCamTrans.localScale = Vector3.one;
        charCamTrans.gameObject.SetActive(true);
        infoWnd.SetWndState();
    }


    public void OpenBuyWnd(int type) {
        StopNavTask();
        buyWnd.SetBuyType(type);
        buyWnd.SetWndState();
    }

}