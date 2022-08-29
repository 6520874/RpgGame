using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour { 

    public Animator ani;

    public CharacterController ctrl;
    public Transform hpRoot;
    protected bool isMove = false;
    private Vector2 dir = Vector2.zero;

    public Vector2 Dir
    {
        get
        {
            return dir;
        }


        set {
            if (value == Vector2.zero)
            {
                isMove = false;
            }else
            {
                isMove = true;
            }

            dir = value;
        }
    }


    protected Transform camTrans;
    protected bool skillMove = false;
    protected float skillMoveSped = 0f;

    //protected TimeSvc timeSvc;

    public virtual void Init()
    {

    }
}
