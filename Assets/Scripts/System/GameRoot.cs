
using UnityEngine;

public class GameRoot : MonoBehaviour {

    public static GameRoot Instance = null;
    public LoadingWnd loadingWnd;
    // public DynamicWnd dynamicWnd;

    private void Start(){
        Instance = this;
    }

    private void ClearUIRoot(){



    }
    
}