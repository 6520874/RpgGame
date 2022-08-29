/****************************************************
    文件：TriggerData.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：2019/5/3 2:44:18
	功能：地图触发数据类
*****************************************************/

using UnityEngine;

public class TriggerData : MonoBehaviour {
    public int triggerWave;
    public MapMgr mapMgr;

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (mapMgr != null) {
                mapMgr.TriggerMonsterBorn(this, triggerWave);
            }
        }
    }
}