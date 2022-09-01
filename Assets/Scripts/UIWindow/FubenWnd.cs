
using PEProtocol;
using UnityEngine;
using UnityEngine.UI;

public class FubenWnd : WindowRoot { 
	
	public Button[] fbBtnArr;
	public Transform pointerTrans;
	private PlayerData pd;

   protected override void InitWnd(){
	  base.InitWnd();
      pd = GameRoot.Instance.PlayerData;
	   
	}



	public void ClickTaskBtn(int fbid){

       // audioSvc.PlayUIAudio(Constants.UIClickBtn);

		netSvc.SendMsg(new GameMsg{
			cmd = (int)CMD.ReqFBFight,
			reqFBFight = new ReqFBFight{
				fbid = fbid
			}
		}
		
		);

	}


	public void ClickCloseBtn()
	{
		audioSvc.PlayUIAudio(Constants.UIClickBtn);
       SetWndState(false);
	}

}
