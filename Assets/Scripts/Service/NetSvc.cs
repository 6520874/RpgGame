using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PEProtocol;

public class NetSvc : MonoBehaviour {

	// Use this for initialization      public static NetSvc Instance = null;


    public static NetSvc Instance = null;
    
    private static readonly string obj = "lock";
    // PESocket<ClientSession, GameMsg> client = null;
    private Queue<GameMsg> msgQue = new Queue<GameMsg>();

    public void AddNetPkg(GameMsg msg) {
        lock (obj) {
            msgQue.Enqueue(msg);
        }
    }

}
