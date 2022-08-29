
//攻击的状态

class StateBorn : IState
{
    public void Enter(EntityBase entity, params object[] args)
    {
        entity.currentAniState = AniState.Born;
        //entity.curSkillCfg = ResSvc.Instance.GetSkillCfg();

    }
    
    public void Exit(EntityBase entity, params object[] args)
    {
        entity.ExitCurtSKill();
    }

    public void Process(EntityBase entity, params object[] args)
    {
        if(entity.entityType == EntityType.Player)  {
            entity.canRlsSKill = false;


        }
    }
}