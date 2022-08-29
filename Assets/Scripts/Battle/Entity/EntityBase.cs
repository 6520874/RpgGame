using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//逻辑实体基类
// A behaviour that is attached to a playable
public abstract class EntityBase{
    public AniState currentAniState = AniState.None;

    public BattleMgr battleMgr = null;
    public StateMgr stateMgr = null;
    public SkillMgr skllMgr = null;
    protected Controller controller =null;
		
	
}
