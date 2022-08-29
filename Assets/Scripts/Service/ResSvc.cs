/****************************************************
    文件：ResSvc.cs
	作者：SIKI学院——Plane
    邮箱: 1785275942@qq.com
    日期：2018/12/3 5:31:29
	功能：资源加载服务
*****************************************************/

using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc : MonoBehaviour
{
    public static ResSvc Instance = null;

    public void InitSvc()
    {
        Instance = this;
        // InitRDNameCfg(PathDefine.RDNameCfg);
        // InitMonsterCfg(PathDefine.MonsterCfg);
        // InitMapCfg(PathDefine.MapCfg);
        // InitGuideCfg(PathDefine.GuideCfg);
        // InitStrongCfg(PathDefine.StrongCfg);
        // InitTaskRewardCfg(PathDefine.TaskRewardCfg);

        // InitSkillCfg(PathDefine.SkillCfg);
        // InitSkillMoveCfg(PathDefine.SkillMoveCfg);
        // InitSkillActionCfg(PathDefine.SkillActionCfg);

        // PECommon.Log("Init ResSvc...");
    }
    private Dictionary<string, GameObject> goDic = new Dictionary<string, GameObject>();

    public GameObject LoadPrefab(string path, bool cache = false)
    {
        GameObject prefab = null;
        if (!goDic.TryGetValue(path, out prefab))
        {
            prefab = Resources.Load<GameObject>(path);
            if (cache)
            {
                goDic.Add(path, prefab);
            }
        }

        GameObject go = null;
        if (prefab != null)
        {
            go = Instantiate(prefab);
        }
        return go;
    }

    private Dictionary<string, Sprite> spDic = new Dictionary<string, Sprite>();
    public Sprite LoadSprite(string path, bool cache = false)
    {
        Sprite sp = null;
        if (!spDic.TryGetValue(path, out sp))
        {
            sp = Resources.Load<Sprite>(path);
            if (cache)
            {
                spDic.Add(path, sp);
            }
        }
        return sp;
    }


    //     public void ResetSkillCfgs() {
    //         skillDic.Clear();
    //         InitSkillCfg(PathDefine.SkillCfg);
    //         skillMoveDic.Clear();
    //         InitSkillMoveCfg(PathDefine.SkillMoveCfg);
    //         PECommon.Log("Reset SkillCfgs...");
    //     }


    //  private Action prgCB = null;
    public void AsyncLoadScene(string sceneName, Action loaded)
    {
        // GameRoot.Instance.loadingWnd.SetWndState();

        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);
        // prgCB = () => {
        //     float val = sceneAsync.progress;
        //     GameRoot.Instance.loadingWnd.SetProgress(val);
        //     if (val == 1) {
        //         if (loaded != null) {
        //             loaded();
        //         }
        //         prgCB = null;
        //         sceneAsync = null;
        //         //GameRoot.Instance.loadingWnd.SetWndState(false);
        //     }
        // };
    }
}
//     private void Update() {
//         if (prgCB != null) {
//             prgCB();
//         }
//     }

//     private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();
//     public AudioClip LoadAudio(string path, bool cache = false) {
//         AudioClip au = null;
//         if (!adDic.TryGetValue(path, out au)) {
//             au = Resources.Load<AudioClip>(path);
//             if (cache) {
//                 adDic.Add(path, au);
//             }
//         }
//         return au;
//     }

//     private Dictionary<string, GameObject> goDic = new Dictionary<string, GameObject>();
//     public GameObject LoadPrefab(string path, bool cache = false) {
//         GameObject prefab = null;
//         if (!goDic.TryGetValue(path, out prefab)) {
//             prefab = Resources.Load<GameObject>(path);
//             if (cache) {
//                 goDic.Add(path, prefab);
//             }
//         }

//         GameObject go = null;
//         if (prefab != null) {
//             go = Instantiate(prefab);
//         }
//         return go;
//     }

//     private Dictionary<string, Sprite> spDic = new Dictionary<string, Sprite>();
//     public Sprite LoadSprite(string path, bool cache = false) {
//         Sprite sp = null;
//         if (!spDic.TryGetValue(path, out sp)) {
//             sp = Resources.Load<Sprite>(path);
//             if (cache) {
//                 spDic.Add(path, sp);
//             }
//         }
//         return sp;
//     }

//     #region InitCfgs
//     #region 随机名字
//     private List<string> surnameLst = new List<string>();
//     private List<string> manLst = new List<string>();
//     private List<string> womanLst = new List<string>();
//     private void InitRDNameCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 //int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     switch (e.Name) {
//                         case "surname":
//                             surnameLst.Add(e.InnerText);
//                             break;
//                         case "man":
//                             manLst.Add(e.InnerText);
//                             break;
//                         case "woman":
//                             womanLst.Add(e.InnerText);
//                             break;
//                     }
//                 }

//             }

//         }

//     }

//     public string GetRDNameData(bool man = true) {
//         string rdName = surnameLst[PETools.RDInt(0, surnameLst.Count - 1)];
//         if (man) {
//             rdName += manLst[PETools.RDInt(0, manLst.Count - 1)];
//         }
//         else {
//             rdName += womanLst[PETools.RDInt(0, womanLst.Count - 1)];
//         }

//         return rdName;
//     }
//     #endregion

//     #region 地图
//     private Dictionary<int, MapCfg> mapCfgDataDic = new Dictionary<int, MapCfg>();
//     private void InitMapCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 MapCfg mc = new MapCfg {
//                     ID = ID,
//                     monsterLst = new List<MonsterData>()
//                 };

//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     switch (e.Name) {
//                         case "mapName":
//                             mc.mapName = e.InnerText;
//                             break;
//                         case "sceneName":
//                             mc.sceneName = e.InnerText;
//                             break;
//                         case "power":
//                             mc.power = int.Parse(e.InnerText);
//                             break;
//                         case "mainCamPos": {
//                                 string[] valArr = e.InnerText.Split(',');
//                                 mc.mainCamPos = new Vector3(float.Parse(valArr[0]), float.Parse(valArr[1]), float.Parse(valArr[2]));
//                             }
//                             break;
//                         case "mainCamRote": {
//                                 string[] valArr = e.InnerText.Split(',');
//                                 mc.mainCamRote = new Vector3(float.Parse(valArr[0]), float.Parse(valArr[1]), float.Parse(valArr[2]));
//                             }
//                             break;
//                         case "playerBornPos": {
//                                 string[] valArr = e.InnerText.Split(',');
//                                 mc.playerBornPos = new Vector3(float.Parse(valArr[0]), float.Parse(valArr[1]), float.Parse(valArr[2]));
//                             }
//                             break;
//                         case "playerBornRote": {
//                                 string[] valArr = e.InnerText.Split(',');
//                                 mc.playerBornRote = new Vector3(float.Parse(valArr[0]), float.Parse(valArr[1]), float.Parse(valArr[2]));
//                             }
//                             break;
//                         case "monsterLst": {
//                                 string[] valArr = e.InnerText.Split('#');
//                                 for (int waveIndex = 0; waveIndex < valArr.Length; waveIndex++) {
//                                     if (waveIndex == 0) {
//                                         continue;
//                                     }
//                                     string[] tempArr = valArr[waveIndex].Split('|');
//                                     for (int j = 0; j < tempArr.Length; j++) {
//                                         if (j == 0) {
//                                             continue;
//                                         }
//                                         string[] arr = tempArr[j].Split(',');
//                                         MonsterData md = new MonsterData {
//                                             ID = int.Parse(arr[0]),
//                                             mWave = waveIndex,
//                                             mIndex = j,
//                                             mCfg = GetMonsterCfg(int.Parse(arr[0])),
//                                             mBornPos = new Vector3(float.Parse(arr[1]), float.Parse(arr[2]), float.Parse(arr[3])),
//                                             mBornRote = new Vector3(0, float.Parse(arr[4]), 0),
//                                             mLevel = int.Parse(arr[5])
//                                         };
//                                         mc.monsterLst.Add(md);
//                                     }
//                                 }
//                             }
//                             break;
//                     }
//                 }
//                 mapCfgDataDic.Add(ID, mc);
//             }
//         }
//     }
//     public MapCfg GetMapCfg(int id) {
//         MapCfg data;
//         if (mapCfgDataDic.TryGetValue(id, out data)) {
//             return data;
//         }
//         return null;
//     }
//     #endregion

//     #region 怪物
//     private Dictionary<int, MonsterCfg> monsterCfgDataDic = new Dictionary<int, MonsterCfg>();
//     private void InitMonsterCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 MonsterCfg mc = new MonsterCfg {
//                     ID = ID,
//                     bps = new BattleProps()
//                 };

//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     switch (e.Name) {
//                         case "mName":
//                             mc.mName = e.InnerText;
//                             break;
//                         case "resPath":
//                             mc.resPath = e.InnerText;
//                             break;
//                         case "hp":
//                             mc.bps.hp = int.Parse(e.InnerText);
//                             break;
//                         case "ad":
//                             mc.bps.ad = int.Parse(e.InnerText);
//                             break;
//                         case "ap":
//                             mc.bps.ap = int.Parse(e.InnerText);
//                             break;
//                         case "addef":
//                             mc.bps.addef = int.Parse(e.InnerText);
//                             break;
//                         case "apdef":
//                             mc.bps.apdef = int.Parse(e.InnerText);
//                             break;
//                         case "dodge":
//                             mc.bps.dodge = int.Parse(e.InnerText);
//                             break;
//                         case "pierce":
//                             mc.bps.pierce = int.Parse(e.InnerText);
//                             break;
//                         case "critical":
//                             mc.bps.critical = int.Parse(e.InnerText);
//                             break;
//                     }
//                 }
//                 monsterCfgDataDic.Add(ID, mc);
//             }
//         }
//     }
//     public MonsterCfg GetMonsterCfg(int id) {
//         MonsterCfg data;
//         if (monsterCfgDataDic.TryGetValue(id, out data)) {
//             return data;
//         }
//         return null;
//     }
//     #endregion

//     #region 自动引导配置
//     private Dictionary<int, AutoGuideCfg> guideTaskDic = new Dictionary<int, AutoGuideCfg>();
//     private void InitGuideCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 AutoGuideCfg mc = new AutoGuideCfg {
//                     ID = ID
//                 };

//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     switch (e.Name) {
//                         case "npcID":
//                             mc.npcID = int.Parse(e.InnerText);
//                             break;
//                         case "dilogArr":
//                             mc.dilogArr = e.InnerText;
//                             break;
//                         case "actID":
//                             mc.actID = int.Parse(e.InnerText);
//                             break;
//                         case "coin":
//                             mc.coin = int.Parse(e.InnerText);
//                             break;
//                         case "exp":
//                             mc.exp = int.Parse(e.InnerText);
//                             break;
//                     }
//                 }
//                 guideTaskDic.Add(ID, mc);
//             }
//         }
//     }
//     public AutoGuideCfg GetAutoGuideCfg(int id) {
//         AutoGuideCfg agc = null;
//         if (guideTaskDic.TryGetValue(id, out agc)) {
//             return agc;
//         }
//         return null;
//     }
//     #endregion

//     #region 强化升级配置
//     private Dictionary<int, Dictionary<int, StrongCfg>> strongDic = new Dictionary<int, Dictionary<int, StrongCfg>>();
//     private void InitStrongCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 StrongCfg sd = new StrongCfg {
//                     ID = ID
//                 };

//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     int val = int.Parse(e.InnerText);
//                     switch (e.Name) {
//                         case "pos":
//                             sd.pos = val;
//                             break;
//                         case "starlv":
//                             sd.startlv = val;
//                             break;
//                         case "addhp":
//                             sd.addhp = val;
//                             break;
//                         case "addhurt":
//                             sd.addhurt = val;
//                             break;
//                         case "adddef":
//                             sd.adddef = val;
//                             break;
//                         case "minlv":
//                             sd.minlv = val;
//                             break;
//                         case "coin":
//                             sd.coin = val;
//                             break;
//                         case "crystal":
//                             sd.crystal = val;
//                             break;
//                     }
//                 }

//                 Dictionary<int, StrongCfg> dic = null;
//                 if (strongDic.TryGetValue(sd.pos, out dic)) {
//                     dic.Add(sd.startlv, sd);
//                 }
//                 else {
//                     dic = new Dictionary<int, StrongCfg>();
//                     dic.Add(sd.startlv, sd);

//                     strongDic.Add(sd.pos, dic);
//                 }
//             }
//         }
//     }
//     public StrongCfg GetStrongCfg(int pos, int starlv) {
//         StrongCfg sd = null;
//         Dictionary<int, StrongCfg> dic = null;
//         if (strongDic.TryGetValue(pos, out dic)) {
//             if (dic.ContainsKey(starlv)) {
//                 sd = dic[starlv];
//             }
//         }
//         return sd;
//     }

//     public int GetPropAddValPreLv(int pos, int starlv, int type) {
//         Dictionary<int, StrongCfg> posDic = null;
//         int val = 0;
//         if (strongDic.TryGetValue(pos, out posDic)) {
//             for (int i = 0; i < starlv; i++) {
//                 StrongCfg sd;
//                 if (posDic.TryGetValue(i, out sd)) {
//                     switch (type) {
//                         case 1://hp
//                             val += sd.addhp;
//                             break;
//                         case 2://hurt
//                             val += sd.addhurt;
//                             break;
//                         case 3://def
//                             val += sd.adddef;
//                             break;
//                     }
//                 }
//             }
//         }
//         return val;
//     }
//     #endregion


//     #region 自动引导配置
//     private Dictionary<int, TaskRewardCfg> taskRewareDic = new Dictionary<int, TaskRewardCfg>();
//     private void InitTaskRewardCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 TaskRewardCfg trc = new TaskRewardCfg {
//                     ID = ID
//                 };

//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     switch (e.Name) {
//                         case "taskName":
//                             trc.taskName = e.InnerText;
//                             break;
//                         case "count":
//                             trc.count = int.Parse(e.InnerText);
//                             break;
//                         case "exp":
//                             trc.exp = int.Parse(e.InnerText);
//                             break;
//                         case "coin":
//                             trc.coin = int.Parse(e.InnerText);
//                             break;
//                     }
//                 }
//                 taskRewareDic.Add(ID, trc);
//             }
//         }
//     }
//     public TaskRewardCfg GetTaskRewardCfg(int id) {
//         TaskRewardCfg trc = null;
//         if (taskRewareDic.TryGetValue(id, out trc)) {
//             return trc;
//         }
//         return null;
//     }
//     #endregion

//     #region 技能配置
//     private Dictionary<int, SkillCfg> skillDic = new Dictionary<int, SkillCfg>();
//     private void InitSkillCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 SkillCfg sc = new SkillCfg {
//                     ID = ID,
//                     skillMoveLst = new List<int>(),
//                     skillActionLst = new List<int>(),
//                     skillDamageLst = new List<int>()
//                 };

//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     switch (e.Name) {
//                         case "skillName":
//                             sc.skillName = e.InnerText;
//                             break;
//                         case "skillTime":
//                             sc.skillTime = int.Parse(e.InnerText);
//                             break;
//                         case "aniAction":
//                             sc.aniAction = int.Parse(e.InnerText);
//                             break;
//                         case "fx":
//                             sc.fx = e.InnerText;
//                             break;
//                         case "dmgType":
//                             if (e.InnerText.Equals("1")) {
//                                 sc.dmgType = DamageType.AD;
//                             }
//                             else if (e.InnerText.Equals("2")) {
//                                 sc.dmgType = DamageType.AP;
//                             }
//                             else {
//                                 PECommon.Log("dmgType ERROR");
//                             }
//                             break;
//                         case "skillMoveLst":
//                             string[] skMoveArr = e.InnerText.Split('|');
//                             for (int j = 0; j < skMoveArr.Length; j++) {
//                                 if (skMoveArr[j] != "") {
//                                     sc.skillMoveLst.Add(int.Parse(skMoveArr[j]));
//                                 }
//                             }
//                             break;
//                         case "skillActionLst":
//                             string[] skActionArr = e.InnerText.Split('|');
//                             for (int j = 0; j < skActionArr.Length; j++) {
//                                 if (skActionArr[j] != "") {
//                                     sc.skillActionLst.Add(int.Parse(skActionArr[j]));
//                                 }
//                             }
//                             break;
//                         case "skillDamageLst":
//                             string[] skDamageArr = e.InnerText.Split('|');
//                             for (int j = 0; j < skDamageArr.Length; j++) {
//                                 if (skDamageArr[j] != "") {
//                                     sc.skillDamageLst.Add(int.Parse(skDamageArr[j]));
//                                 }
//                             }
//                             break;
//                     }
//                 }
//                 skillDic.Add(ID, sc);
//             }
//         }
//     }
//     public SkillCfg GetSkillCfg(int id) {
//         SkillCfg sc = null;
//         if (skillDic.TryGetValue(id, out sc)) {
//             return sc;
//         }
//         return null;
//     }
//     #endregion

//     #region 技能配置
//     private Dictionary<int, SkillActionCfg> skillActionDic = new Dictionary<int, SkillActionCfg>();
//     private void InitSkillActionCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 SkillActionCfg sac = new SkillActionCfg {
//                     ID = ID
//                 };

//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     switch (e.Name) {
//                         case "delayTime":
//                             sac.delayTime = int.Parse(e.InnerText);
//                             break;
//                         case "radius":
//                             sac.radius = float.Parse(e.InnerText);
//                             break;
//                         case "angle":
//                             sac.angle = int.Parse(e.InnerText);
//                             break;
//                     }
//                 }
//                 skillActionDic.Add(ID, sac);
//             }
//         }
//     }
//     public SkillActionCfg GetSkillActionCfg(int id) {
//         SkillActionCfg sac = null;
//         if (skillActionDic.TryGetValue(id, out sac)) {
//             return sac;
//         }
//         return null;
//     }
//     #endregion

//     #region 技能配置
//     private Dictionary<int, SkillMoveCfg> skillMoveDic = new Dictionary<int, SkillMoveCfg>();
//     private void InitSkillMoveCfg(string path) {
//         TextAsset xml = Resources.Load<TextAsset>(path);
//         if (!xml) {
//             PECommon.Log("xml file:" + path + " not exist", LogType.Error);
//         }
//         else {
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xml.text);

//             XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

//             for (int i = 0; i < nodLst.Count; i++) {
//                 XmlElement ele = nodLst[i] as XmlElement;

//                 if (ele.GetAttributeNode("ID") == null) {
//                     continue;
//                 }
//                 int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
//                 SkillMoveCfg smc = new SkillMoveCfg {
//                     ID = ID
//                 };

//                 foreach (XmlElement e in nodLst[i].ChildNodes) {
//                     switch (e.Name) {
//                         case "delayTime":
//                             smc.delayTime = int.Parse(e.InnerText);
//                             break;
//                         case "moveTime":
//                             smc.moveTime = int.Parse(e.InnerText);
//                             break;
//                         case "moveDis":
//                             smc.moveDis = float.Parse(e.InnerText);
//                             break;
//                     }
//                 }
//                 skillMoveDic.Add(ID, smc);
//             }
//         }
//     }
//     public SkillMoveCfg GetSkillMoveCfg(int id) {
//         SkillMoveCfg smc = null;
//         if (skillMoveDic.TryGetValue(id, out smc)) {
//             return smc;
//         }
//         return null;
//     }
//     #endregion
//     #endregion
// }