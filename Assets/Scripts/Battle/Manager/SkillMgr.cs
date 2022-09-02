using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMgr : MonoBehaviour
{
    private ResSvc resSvc;
    private TimerSvc timeSvc;


    public void Init()
    {
        resSvc = ResSvc.Instance;
        timeSvc = TimerSvc.Instance;
        PECommon.Log("Init SkillMgr Done.");
    }

    // public void SkillAttack(EntityBase entity, int skillID) {
    //     entity.skMoveCBLst.Clear();
    //     entity.skActionCBLst.Clear();

    //     AttackDamage(entity, skillID);
    //     AttackEffect(entity, skillID);
    // }



}
