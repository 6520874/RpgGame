/****************************************************
    文件：PlayerCtrlWnd.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：2019/3/19 5:39:47
	功能：玩家控制界面
*****************************************************/

using PEProtocol;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class PlayerCtrlWnd : WindowRoot {
    public Image imgTouch;
    public Image imgDirBg;
    public Image imgDirPoint;
    public Text txtLevel;
    public Text txtName;
    public Text txtExpPrg;
    public Transform expPrgTrans;

    private float pointDis;
    private Vector2 startPos = Vector2.zero;
    private Vector2 defaultPos = Vector2.zero;

    public Vector2 currentDir;

    #region Skill
    #region SK1
    public Image imgSk1CD;
    public Text txtSk1CD;
    private bool isSk1CD = false;
    private float sk1CDTime;
    private int sk1Num;
    private float sk1FillCount = 0;
    private float sk1NumCount = 0;
    #endregion

    #region SK2
    public Image imgSk2CD;
    public Text txtSk2CD;
    private bool isSk2CD = false;
    private float sk2CDTime;
    private int sk2Num;
    private float sk2FillCount = 0;
    private float sk2NumCount = 0;
    #endregion

    #region SK3
    public Image imgSk3CD;
    public Text txtSk3CD;
    private bool isSk3CD = false;
    private float sk3CDTime;
    private int sk3Num;
    private float sk3FillCount = 0;
    private float sk3NumCount = 0;
    #endregion
    #endregion

    public Text txtSelfHP;
    public Image imgSelfHP;

    private int HPSum;



    protected override void InitWnd(){
        base.InitWnd();
    }

    
}
