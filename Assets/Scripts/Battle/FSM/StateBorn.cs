
//攻击的状态

public class StateBorn : IState
{
    public void Enter(EntityBase entity, params object[] args)
    {
        entity.currentAniState = AniState.Born;
        //entity.curSkillCfg = ResSvc.Instance.GetSkillCfg();

    }
    
    public void Exit(EntityBase entity, params object[] args)
    {
        // entity.ExitCurtSKill();
    }

    public void Process(EntityBase entity, params object[] args)
    {
        entity.SetAction(Constants.ActionBorn);
        TimerSvc.Instance.AddTimeTask((int tid) => {
            entity.SetAction(Constants.ActionDefault);
        }, 500);
    }
}