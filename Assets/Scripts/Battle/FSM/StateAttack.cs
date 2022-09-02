/****************************************************
	文件：StateAttack.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/20 8:30   	
	功能：攻击状态
*****************************************************/

public class StateAttack : IState {
    public void Enter(EntityBase entity, params object[] args) {
        entity.currentAniState = AniState.Attack;
        entity.curtSkillCfg = ResSvc.Instance.GetSkillCfg((int)args[0]);
        //PECommon.Log("Enter StateAttack.");
    }

    public void Exit(EntityBase entity, params object[] args) {
        entity.ExitCurtSkill();
        //PECommon.Log("Exit StateAttack.");
    }

    public void Process(EntityBase entity, params object[] args) {
        if (entity.entityType == EntityType.Player) {
            entity.canRlsSkill = false;
        }

        entity.SkillAttack((int)args[0]);
        //PECommon.Log("Process StateAttack.");
    }
}
