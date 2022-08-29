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
            //PECommon.Log(Name + ": HPchange:" + hp + " to " + value);
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
         //   controller.SetBlend(blend);
        }

    }

    private BattleProps props;

     public virtual void SetAction(int act) {
        if (controller != null) {
            //controller.SetAction(act);
        }
    }
    public void ExitCurtSkill() {
        canControl = true;

        if (curtSkillCfg != null) {
            if (!curtSkillCfg.isBreak) {
                entityState = EntityState.None;
            }
            //连招数据更新
            if (curtSkillCfg.isCombo) {
                if (comboQue.Count > 0) {
                    nextSkillID = comboQue.Dequeue();
                }
                else {
                    nextSkillID = 0;
                }
            }
            curtSkillCfg = null;
        }
        SetAction(Constants.ActionDefault);
    }



}
