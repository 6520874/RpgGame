using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//逻辑实体基类
// A behaviour that is attached to a playable
public abstract class EntityBase
{
    public AniState currentAniState = AniState.None;

    public BattleMgr battleMgr = null;
    public StateMgr stateMgr = null;
    public SkillMgr skllMgr = null;
    protected Controller controller = null;

    public bool canControl = true;
    public bool canRlsSkill = true;
    private string name;
    public EntityType entityType = EntityType.None;
    public EntityState entityState = EntityState.None;
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
    private int hp;
    public int HP
    {
        get
        {
            return hp;
        }

        set
        {
            //通知UI层TODO
            PECommon.Log(Name + ": HPchange:" + hp + " to " + value);
            SetHPVal(hp, value);
            hp = value;
        }
    }

    public Queue<int> comboQue = new Queue<int>();
    public int nextSkillID = 0;

    public SkillCfg curtSkillCfg;


    public BattleProps Props
    {
        get
        {
            return props;
        }

        protected set
        {
            props = value;
        }
    }
    public virtual void SetHPVal(int oldval, int newval)
    {
        if (controller != null)
        {
            //GameRoot.Instance.dynamicWnd.SetHPVal(Name, oldval, newval);
        }
    }
    public virtual void SetBattleProps(BattleProps props)
    {
        HP = props.hp;
        Props = props;
    }


    public virtual void SetBlend(float blend)
    {
        if (controller != null)
        {
            controller.SetBlend(blend);
        }

    }

    private BattleProps props;

    public virtual void SetAction(int act)
    {
        if (controller != null)
        {
            controller.SetAction(act);
        }
    }
    public void ExitCurtSkill()
    {
        canControl = true;

        if (curtSkillCfg != null)
        {
            if (!curtSkillCfg.isBreak)
            {
                entityState = EntityState.None;
            }
            //连招数据更新
            if (curtSkillCfg.isCombo)
            {
                if (comboQue.Count > 0)
                {
                    nextSkillID = comboQue.Dequeue();
                }
                else
                {
                    nextSkillID = 0;
                }
            }
            curtSkillCfg = null;
        }
        SetAction(Constants.ActionDefault);
    }

    public void SetCtrl(Controller ctrl)
    {
        controller = ctrl;
    }

    public virtual Vector2 GetDirInput()
    {
        return Vector2.zero;
    }

    public void Born()
    {
        stateMgr.ChangeStatus(this, AniState.Born, null);
    }
    public void Move()
    {
        stateMgr.ChangeStatus(this, AniState.Move, null);
    }
    public void Idle()
    {
        stateMgr.ChangeStatus(this, AniState.Idle, null);
    }
    public void Attack(int skillID)
    {
        stateMgr.ChangeStatus(this, AniState.Attack, skillID);
    }
    public void Hit()
    {
        stateMgr.ChangeStatus(this, AniState.Hit, null);
    }
    public void Die()
    {
        stateMgr.ChangeStatus(this, AniState.Die, null);
    }

    public virtual void SetDir(Vector2 dir)
    {
        if (controller != null)
        {
            controller.Dir = dir;
        }
    }



}
