using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour {
    private ResSvc resSvc;

    //private AudioSvc audioSvc;
    //private StateMgr stateMgr;

    private StateMgr stateMgr;
    private MapCfg mapCfg;

    public EntityPlayer ebtitySelfPlayer;
    private MapMgr mapMgr;
    private Dictionary<string, EntityMonster> monsterDic = new Dictionary<string, EntityMonster>();


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

    }

}
