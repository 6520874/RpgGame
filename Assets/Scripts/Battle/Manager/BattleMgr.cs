using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PEProtocol;
public class BattleMgr : MonoBehaviour {
    private ResSvc resSvc;

    private AudioSvc audioSvc;
    private StateMgr stateMgr;

    private StateMgr stateMgr;
    private MapCfg mapCfg;
      
    private MapMgr mapMgr;
    private Dictionary<string, EntityMonster> monsterDic = new Dictionary<string, EntityMonster>();
    public EntityPlayer entitySelfPlayer;


 public void Init(int mapid, Action cb = null) {
        resSvc = ResSvc.Instance;
        audioSvc = AudioSvc.Instance;

        //初始化各管理器
        stateMgr = gameObject.AddComponent<StateMgr>();
        stateMgr.Init();
        skillMgr = gameObject.AddComponent<SkillMgr>();
        skillMgr.Init();

        //加载战场地图
        mapCfg = resSvc.GetMapCfg(mapid);
        resSvc.AsyncLoadScene(mapCfg.sceneName, () => {
            //初始化地图数据
            GameObject map = GameObject.FindGameObjectWithTag("MapRoot");
            mapMgr = map.GetComponent<MapMgr>();
            mapMgr.Init(this);

            map.transform.localPosition = Vector3.zero;
            map.transform.localScale = Vector3.one;

            Camera.main.transform.position = mapCfg.mainCamPos;
            Camera.main.transform.localEulerAngles = mapCfg.mainCamRote;

            LoadPlayer(mapCfg);
            entitySelfPlayer.Idle();

            //激活第一批次怪物
            ActiveCurrentBatchMonsters();

            audioSvc.PlayBGMusic(Constants.BGHuangYe);
            if (cb != null) {
                cb();
            }
        });
    }

    public void LoadMonsterByWaveID(int wave)
    {
        //for (int i = 0; i < mapCfg.monsterLst.Count; i++)
        //{
        //    MonsterData md = mapCfg.monsterLst[i];
        //    if (md.mWave == wave)
        //    {
        //        GameObject m = resSvc.LoadPrefab(md.mCfg.resPath, true);
        //        m.transform.localPosition = md.mBornPos;
        //        m.transform.localEulerAngles = md.mBornRote;
        //        m.transform.localScale = Vector3.one;

        //        m.name = "m" + md.mWave + "_" + md.mIndex;

        //        EntityMonster em = new EntityMonster
        //        {
        //            battleMgr = this,
        //            stateMgr = stateMgr,
        //            skillMgr = skillMgr
        //        };
        //        //设置初始属性
        //        em.md = md;
        //        em.SetBattleProps(md.mCfg.bps);
        //        em.Name = m.name;

        //        MonsterController mc = m.GetComponent<MonsterController>();
        //        mc.Init();
        //        em.SetCtrl(mc);

        //        m.SetActive(false);
        //        monsterDic.Add(m.name, em);
        //        if (md.mCfg.mType == MonsterType.Normal)
        //        {
        //            GameRoot.Instance.dynamicWnd.AddHpItemInfo(m.name, mc.hpRoot, em.HP);
        //        }
        //        else if (md.mCfg.mType == MonsterType.Boss)
        //        {
        //            BattleSys.Instance.playerCtrlWnd.SetBossHPBarState(true);
        //        }
        //    }
        //}
    }
    // Update is called once per frame

 
     private void LoadPlayer(MapCfg mapData)
    {
        GameObject player = resSvc.LoadPrefab(PathDefine.AssissnBattlePlayerPrefab);

        player.transform.position = mapData.playerBornPos;
        player.transform.localEulerAngles = mapData.playerBornRote;
        player.transform.localScale = Vector3.one;

        PlayerData pd = GameRoot.Instance.PlayerData;
        BattleProps props = new BattleProps
        {
            hp = pd.hp,
            ad = pd.ad,
            ap = pd.ap,
            addef = pd.addef,
            apdef = pd.apdef,
            dodge = pd.dodge,
            pierce = pd.pierce,
            critical = pd.critical

        };

           entitySelfPlayer = new EntityPlayer {
            battleMgr = this,
            stateMgr = stateMgr,
            // skillMgr = skillMgr
        };
        entitySelfPlayer.Name = "AssassinBattle";
        entitySelfPlayer.SetBattleProps(props);

        PlayerController playerCtrl = player.GetComponent<PlayerController>();
        playerCtrl.Init();
        //entitySelfPlayer.SetCtrl(playerCtrl);


    }

}
