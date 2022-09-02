﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMonster : EntityBase
{

    public EntityMonster()
    {
        entityType = EntityType.Monster;
    }

    public MonsterData md;
    private float checkTime = 2;
    private float checkCountTime = 0;

    private float atkTime = 2;
    private float atkCountTime = 0;

    bool runAI = true;

    public override void TickAILogic()
    {

        if (!runAI)
        {
            return;
        }
        if (currentAniState == AniState.Idle || currentAniState == AniState.Move)
        {
            if (battleMgr.isPauseGame)
            {
                Idle();
                return;
            }

            float delta = Time.deltaTime;
            checkCountTime += delta;
            if (checkCountTime < checkTime)
            {
                return;
            }
            else
            {
                Vector2 dir = CalcTargetDir();
                if (!InAtkRange())
                {
                    SetDir(dir);
                    Move();
                }
                else
                {
                    SetDir(Vector2.zero);
                    atkCountTime += checkCountTime;
                    if (atkCountTime > atkTime)
                    {
                        SetAtkRotation(dir);
                        Attack(md.mCfg.skillID);
                        atkCountTime = 0;
                    }
                    else
                    {
                        Idle();
                    }
                }
                checkCountTime = 0;
                checkTime = PETools.RDInt(1, 5) * 1.0f / 10;
            }
        }

    }

    private bool InAtkRange()
    {
        EntityPlayer entityPlayer = battleMgr.entitySelfPlayer;
        if (entityPlayer == null || entityPlayer.currentAniState == AniState.Die)
        {
            runAI = false;
            return false;
        }
        else
        {
            Vector3 target = entityPlayer.GetPos();
            Vector3 self = GetPos();
            target.y = 0;
            self.y = 0;
            float dis = Vector3.Distance(target, self);
            if (dis <= md.mCfg.atkDis)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public override void SetBattleProps(BattleProps props)
    {
        int level = md.mLevel;

        BattleProps p = new BattleProps
        {
            hp = props.hp * level,
            ad = props.ad * level,
            ap = props.ap * level,
            addef = props.addef * level,
            apdef = props.apdef * level,
            dodge = props.dodge * level,
            pierce = props.pierce * level,
            critical = props.critical * level
        };

        Props = p;
        HP = p.hp;
    }

}
