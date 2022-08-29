using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMgr : MonoBehaviour {
    private Dictionary<AnimationState, IState> fsm = new Dictionary<AnimationState, IState>();


    public void Init(BattleMgr battle)
    {
         

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
