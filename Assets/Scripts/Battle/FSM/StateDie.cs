﻿
//攻击的状态

class StateDie: IState
{
    public void Enter(EntityBase entity, params object[] args)
    {
        entity.currentAniState = AniState.Die;
        //entity.curSkillCfg = ResSvc.Instance.GetSkillCfg();

    }

    public void Exit(EntityBase entity, params object[] args)
    {
        entity.ExitCurtSKill();
    }

    public void Process(EntityBase entity, params object[] args)
    {
        if(entity.entityType == EntityType.Player)  {
            entity.canRlsSKill = flase;
        }
    }
}