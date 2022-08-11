
using UnityEngine;

public class GameRoot : MonoBehaviour
{

    public static GameRoot Instance = null;
    public LoadingWnd loadingWnd;
    // public DynamicWnd dynamicWnd;


    private void Start()
    {
        Debug.Log("11111...");
        Instance = this;
        DontDestroyOnLoad(this);
        Debug.Log("Game Start...");
        ClearUIRoot();

        Init();
    }



    private void ClearUIRoot()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }

        //dynamicWnd.SetWndState();
    }

    private void Init()
    {
        //服务模块初始化
        // NetSvc net = GetComponent<NetSvc>();
        // net.InitSvc();
        ResSvc res = GetComponent<ResSvc>();
        res.InitSvc();
        // AudioSvc audio = GetComponent<AudioSvc>();
        // audio.InitSvc();
        // TimerSvc timer = GetComponent<TimerSvc>();
        // timer.InitSvc();

        Debug.Log("33...");
        // //业务系统初始化
        LoginSys login = GetComponent<LoginSys>();
        login.InitSys();
        // MainCitySys maincity = GetComponent<MainCitySys>();
        // maincity.InitSys();
        // FubenSys fuben = GetComponent<FubenSys>();
        // fuben.InitSys();
        // BattleSys battle = GetComponent<BattleSys>();
        // battle.InitSys();

        //进入登录场景并加载相应UI
        login.EnterLogin();
    }


}