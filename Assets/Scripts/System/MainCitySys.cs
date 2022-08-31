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

    private PlayerController playerCtrl;
    private Transform charCamTrans;
    private AutoGuideCfg curtTaskData;
    private Transform[] npcPosTrans;
    private NavMeshAgent nav;

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
            
            MainCityMap mcm = map.GetComponent<MainCityMap>();
            npcPosTrans = mcm.NpcPosTrans;

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
  



}