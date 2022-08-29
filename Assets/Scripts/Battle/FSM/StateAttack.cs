class StateAttack : IState
{
    public void Enter(EntityBase entity, params object[] args)
    {
        entity.currentAniState = AniState.Attack;
        //entity.curSkillCfg = ResSvc.Instance.GetSkillCfg();

    }

    public void Exit(EntityBase entity, params object[] args)
    {
        throw new System.NotImplementedException();
    }

    public void Process(EntityBase entity, params object[] args)
    {
        throw new System.NotImplementedException();
    }
}