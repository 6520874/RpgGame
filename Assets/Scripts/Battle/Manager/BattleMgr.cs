using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour {
    private ResSvc resSvc;
    //private AudioSvc audioSvc;
    //private StateMgr stateMgr;

    private stateMgr statreMgr;

    public EntityPlayer ebtitySelfPlayer;
    private MapMgr mapMgr;
    private Dictionary<string, EntityMonster> monsterDic = new Dictionary<string, EntityMonster>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
