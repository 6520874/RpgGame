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


    public Image imgRed;
    public Image imgYellow;

    public Transform transBossHPBar;


    protected override void InitWnd(){
        base.InitWnd();

        pointDis = Screen.height*1.0f/Constants.ScreenStandardHeight*Constants.ScreenOPDis;
        defaultPos = imgDirBg.transform.position;

        SetActive(imgDirPoint,false);

        
        HPSum = GameRoot.Instance.PlayerData.hp;
        SetText(txtSelfHP, HPSum + "/" + HPSum);
        imgSelfHP.fillAmount = 1;
         
        SetBossHPBarState(false);

        RegisterTouchEvts();

    }

    public void RegisterTouchEvts() {
        OnClickDown(imgTouch.gameObject, (PointerEventData evt) => {
            startPos = evt.position;
            SetActive(imgDirPoint);
            imgDirBg.transform.position = evt.position;
        });
        OnClickUp(imgTouch.gameObject, (PointerEventData evt) => {
            imgDirBg.transform.position = defaultPos;
            SetActive(imgDirPoint, false);
            imgDirPoint.transform.localPosition = Vector2.zero;
            currentDir = Vector2.zero;
            BattleSys.Instance.SetMoveDir(currentDir);
        });
        OnDrag(imgTouch.gameObject, (PointerEventData evt) => {
            Vector2 dir = evt.position - startPos;
            float len = dir.magnitude;
            if (len > pointDis) {
                Vector2 clampDir = Vector2.ClampMagnitude(dir, pointDis);
                imgDirPoint.transform.position = startPos + clampDir;
            }
            else {
                imgDirPoint.transform.position = evt.position;
            }
            currentDir = dir.normalized;
            BattleSys.Instance.SetMoveDir(currentDir);
        });
    }
    
    public void SetBossHPBarState(bool state,float prg = 1){
        SetActive(transBossHPBar, state);
        imgRed.fillAmount = prg;
        imgYellow.fillAmount = prg;
    }

    public void RefreshUI(){
         PlayerData pd = GameRoot.Instance.PlayerData;
         SetText(txtLevel, pd.lv);
        SetText(txtName, pd.name);
     

        #region Expprg
        int expPrgVal = (int)(pd.exp * 1.0f / PECommon.GetExpUpValByLv(pd.lv) * 100);
        SetText(txtExpPrg, expPrgVal + "%");
        int index = expPrgVal / 10;

    }




}