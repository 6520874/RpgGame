using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour {
    private BattleMgr battleMgr;
    public TriggerData[] triggerArr;

     private int waveIndex = 1;//默认生成第一波怪物

    public void Init(BattleMgr battle)
    {
        battleMgr = battle;
        battleMgr.LoadMonsterByWaveID(waveIndex);
        PECommon.Log("Init MapMgr Done.");

    }
    // Use this for initialization
    public void TriggerMonsterBorn(TriggerData trigger, int waveIndex)
    {
        if (battleMgr != null)
        {
            BoxCollider co = trigger.gameObject.GetComponent<BoxCollider>();
            co.isTrigger = false;

            battleMgr.LoadMonsterByWaveID(waveIndex);
            // battleMgr.ActiveCurrentBatchMonsters();
            // battleMgr.triggerCheck = true;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
