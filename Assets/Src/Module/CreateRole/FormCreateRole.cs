using System.IO;
/*
 * @Author: mangit
 * @LastEditTime: 2022-06-14 17:37:32
 * @LastEditors: mangit
 * @Description: 创角界面
 * @Date: 2022-06-06 19:54:10
 * @FilePath: /Assets/Src/Module/CreateRole/FormCreateRole.cs
 */
using FairyGUI;
using RoleDefine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using UnityEngine;

public class FormCreateRole : FGUIForm
{
    public const string CREATE_ROLE_ASSET_UID = "CREATE_ROLE_ASSET_UID";
    private GLoader _ladLoading;
    private GLoader _lock;
    private GTextField _tfRoleName;
    private GTextField _tfError;
    private GButton _btnDice;
    private GButton _btnStartGame;
    private GList _lstSexy;
    private int _roleId;
    private eRoleGender _sex;
    private GComponent _comAvatar;
    // private _avatar;//TODO
    // private _model;//TODO

    private GList _lstBodySubclass;
    private GList _lstRightSubclass;

    private GButton _btnRandomAvatar;
    private GButton _btnEditName;

    private Dictionary<eRoleFeaturePart, string> _avatarArmatureDict = new();
    private Dictionary<eRoleFeaturePart, int> _idDic = new();
    private Dictionary<eRoleFeaturePart, List<DRAvatar>> _cfgAvatarDict;//avatar 配置数据
    private Dictionary<eRoleGender, string[]> _randomNameLibMap;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _lock = GCom.GetChild("lock").asLoader;
        _ladLoading = GCom.GetChild("ladLoading").asLoader;
        _tfRoleName = GCom.GetChild("tfRoleName").asTextField;
        _tfError = GCom.GetChild("tfError").asTextField;
        _btnDice = GCom.GetChild("btnDice").asButton;
        _btnEditName = GCom.GetChild("btnEditName").asButton;
        _btnStartGame = GCom.GetChild("btnStartGame").asButton;
        _lstSexy = GCom.GetChild("lstSexy").asList;
        _btnRandomAvatar = GCom.GetChild("btnRandomAvatar").asButton;
        _lstBodySubclass = GCom.GetChild("lstBodySubclass").asList;
        _lstRightSubclass = GCom.GetChild("lstRightSubclass").asList;
        _lstBodySubclass.selectedIndex = 0;

        _lstSexy.selectedIndex = 0;//0为男，1为女
        _sex = eRoleGender.male;
        _roleId = RoleID.MALE;

        ShowAvatar();
        RandomName();
        InitDefaultAvatarData();
        ChangeRightSubclass();
        RandomAvatar();
        InitRandomNameLib();

        AddUIListener();
        AddMessage();
    }

    protected override void OnRecycle()
    {
        RemoveUIListener();
        RemoveMessage();
        base.OnRecycle();
    }



    private void AddUIListener()
    {
        _lstSexy.onClickItem.Add(OnClickSexy);
        _btnDice.onClick.Add(OnRandomNameClick);
        _tfRoleName.onClick.Add(OnRoleNameClick);
        _btnStartGame.onClick.Add(OnClickStartGame);
        _btnRandomAvatar.onClick.Add(OnRandomAvatarClick);
        _btnEditName.onClick.Add(OnEditNameClick);

        _lstBodySubclass.onClickItem.Add(OnClickBodySubclass);
        _lstRightSubclass.onClickItem.Add(OnClickRightSubclass);
    }

    private void RemoveUIListener()
    {
        _lstSexy.onClickItem.Remove(OnClickSexy);
        _btnDice.onClick.Remove(OnRandomNameClick);
        _tfRoleName.onClick.Remove(OnRoleNameClick);
        _btnStartGame.onClick.Remove(OnClickStartGame);
        _btnRandomAvatar.onClick.Remove(OnRandomAvatarClick);
        _btnEditName.onClick.Remove(OnEditNameClick);

        _lstBodySubclass.onClickItem.Remove(OnClickBodySubclass);
        _lstRightSubclass.onClickItem.Remove(OnClickRightSubclass);
    }

    private void AddMessage()
    {
        BasicModule.Login.OnCreatePlayerSuccess += OnCreatePlayerSuccess;
        BasicModule.Login.OnCreatePlayerFailed += OnCreatePlayerFailed;
        //todo:断线重连处理
        //todo:转菊花处理
    }

    private void RemoveMessage()
    {
        BasicModule.Login.OnCreatePlayerSuccess -= OnCreatePlayerSuccess;
        BasicModule.Login.OnCreatePlayerFailed -= OnCreatePlayerFailed;
        //todo:断线重连处理
        //todo:转菊花处理
    }

    /// <summary>
    /// 展示模型
    /// </summary>
    private void ShowAvatar()
    {
        //todo:
    }

    private void InitDefaultAvatarData()
    {
        if (_cfgAvatarDict == null)
        {
            _cfgAvatarDict = new();
        }
        _cfgAvatarDict.Clear();
        int[] avatarsID = GFEntry.DataTable.GetDataTable<DRRole>().GetDataRow(_roleId).RoleDefaultAvatar;
        List<DRAvatar> avatars = new();
        foreach (int id in avatarsID)
        {
            DRAvatar drAvatar = GFEntry.DataTable.GetDataTable<DRAvatar>().GetDataRow(id);
            if (drAvatar != null)
            {
                avatars.Add(drAvatar);
            }
            else
            {
                MLog.Error(eLogTag.createRole, $"can't find avatar id:{id}");
            }
        }
        avatars.Sort((DRAvatar a, DRAvatar b) =>
        {
            return a.AvatarType - b.AvatarType;
        });
        foreach (DRAvatar drAvatar in avatars)
        {
            eRoleFeaturePart part = (eRoleFeaturePart)Enum.ToObject(typeof(eRoleFeaturePart), drAvatar.AvatarType);
            if (!_cfgAvatarDict.ContainsKey(part))
            {
                _cfgAvatarDict.Add(part, new List<DRAvatar>());
            }
            List<DRAvatar> avatarDataList = _cfgAvatarDict[part];
            avatarDataList.Add(drAvatar);
        }
    }

    /// <summary>
    /// 随机样貌
    /// </summary>
    private void RandomAvatar()
    {
        foreach (KeyValuePair<eRoleFeaturePart, List<DRAvatar>> kvp in _cfgAvatarDict)
        {
            SetAvatarData(kvp.Key);
        }
    }

    private void SetAvatarData(eRoleFeaturePart part)
    {
        List<DRAvatar> dataList = _cfgAvatarDict[part];
        int randomIndex = UnityEngine.Random.Range(0, dataList.Count);
        GObject listItem = _lstBodySubclass.GetChild(part.ToString());
        listItem.data = randomIndex;
        _avatarArmatureDict[part] = _roleId == RoleID.MALE ? dataList[randomIndex].ResouceBoy : dataList[randomIndex].ResouceGirl;
        _idDic[part] = dataList[randomIndex].Id;
    }

    private void RandomName()
    {
        if (_randomNameLibMap == null)
        {
            return;//还没有初始化
        }

        if (!_randomNameLibMap.ContainsKey(_sex))
        {
            return;//没有该性别
        }

        string[] sexLib = _randomNameLibMap[_sex];
        if (sexLib.Length == 0)
        {
            MLog.Error(eLogTag.createRole, $"get name lib error, sex={_sex}");
            return;
        }

        CleanErrorText();
        int randomIndex = UnityEngine.Random.Range(0, sexLib.Length);
        _tfRoleName.text = sexLib[randomIndex];
    }

    private async void InitRandomNameLib()
    {
        eRoleGender[] sexList = { eRoleGender.male, eRoleGender.female };
        MLog.Info(eLogTag.createRole, $"start init random name,lib={sexList}");
        Dictionary<eRoleGender, string[]> res = new();
        foreach (eRoleGender sex in sexList)
        {
            try
            {
                string fileName = Path.Combine(AssetDefine.PATH_ROLE_NAME, $"randomName_{sex}.txt");
                TextAsset textAsset = await GFEntry.Resource.AwaitLoadAsset<TextAsset>(fileName);
                string fileText = textAsset.text;
                string[] libList = fileText.Split('\n');
                res[sex] = libList;
            }
            catch (Exception e)
            {
                MLog.Error(eLogTag.createRole, e.Message);
            }
        }

        _randomNameLibMap = res;
        MLog.Info(eLogTag.createRole, $"end init random name lib");
        //准备好之后，随机一个名字
        if (!Recycled)
        {
            RandomName();
        }
    }

    private void CleanErrorText()
    {
        _tfError.visible = false;
    }

    private void OnCreatePlayerSuccess()
    {
        _ladLoading.visible = false;
        _lock.visible = false;
        Close();
    }

    private void OnCreatePlayerFailed(string errorText)
    {
        _ladLoading.visible = false;
        _lock.visible = false;
        _tfError.text = $"【{errorText}】";
        _tfError.visible = true;
        _btnStartGame.touchable = true;
        if (errorText == "error")
        {
            //todo: show error toast
        }
    }

    private bool CheckName(string name)
    {
        if (name.Length == 0)
        {
            _tfError.text = "名字不能为空";
            _tfError.visible = true;
            return false;
        }

        //非法、不可见字符检测。
        if (!Regex.IsMatch(name, @"^[A-Za-z0-9_\-\u4e00-\u9fa5]+$"))
        {
            _tfError.text = "名字不能包含非法字符";
            _tfError.visible = true;
            return false;
        }

        if (GetNameLength(name) > 14)
        {
            _tfError.text = "名字长度不能超过14个字符";
            _tfError.visible = true;
            return false;
        }

        return true;
    }

    private int GetNameLength(string name)
    {
        return name.Replace(@"[\u0391-\uFFE5]", "aa").Length;
    }

    private void OnClickSexy()
    {
        _sex = _lstSexy.selectedIndex > 0 ? eRoleGender.female : eRoleGender.male;
        _roleId = _lstSexy.selectedIndex > 0 ? RoleID.FEMALE : RoleID.MALE;
        InitDefaultAvatarData();
        ChangeRightSubclass();
        RandomAvatar();
    }

    private void ChangeRightSubclass()
    {
        _lstRightSubclass.RemoveChildrenToPool();
        eRoleFeaturePart part = GetCurFeaturePart();
        List<DRAvatar> avatarList = _cfgAvatarDict[part];
        foreach (DRAvatar drAvatar in avatarList)
        {
            GButton item = _lstRightSubclass.AddItemFromPool().asButton;
            item.data = drAvatar;
            string iconRes = _sex == eRoleGender.male ? drAvatar.ResouceBoyIcon : drAvatar.ResouceGirlIcon;
            item.icon = Path.Combine(AssetDefine.PATH_AVATAR_ICON, $"{iconRes}.png");
        }
    }

    private void OnRandomNameClick()
    {
        RandomName();
    }

    private void OnRoleNameClick()
    {
        CleanErrorText();
    }

    private void OnClickStartGame()
    {
        _tfRoleName.text = _tfRoleName.text.Trim();//去掉首尾不可见字符
        string name = _tfRoleName.text;
        string icon = "head_icon_png";//todo:
        if (CheckName(name))
        {
            // _ladLoading.visible = true;
            // _lock.touchable = true;
            CreateRoleAction.Req(_roleId, name, icon, _sex.ToString(), _idDic);
        }
    }

    private void OnRandomAvatarClick()
    {
        RandomAvatar();
    }

    private void OnEditNameClick()
    {
        _tfRoleName.touchable = true;
        _tfRoleName.RequestFocus();
    }

    private void OnClickBodySubclass()
    {
        ChangeRightSubclass();
    }

    private void OnClickRightSubclass()
    {
        UpdateModel();
    }

    private void UpdateModel()
    {
        GObject clickItem = _lstRightSubclass.GetChildAt(_lstRightSubclass.selectedIndex);
        if (clickItem.data is not DRAvatar itemData)
        {
            return;
        }

        eRoleFeaturePart part = GetCurFeaturePart();
        _avatarArmatureDict[part] = _roleId == RoleID.MALE ? itemData.ResouceBoy : itemData.ResouceGirl;
        _idDic[part] = itemData.Id;
        OnMainPlayerAvatarChanged();
    }

    private void OnMainPlayerAvatarChanged()
    {
        //todo:
    }

    private eRoleFeaturePart GetCurFeaturePart()
    {
        GObject selectedTab = _lstBodySubclass.GetChildAt(_lstBodySubclass.selectedIndex);
        return RoleConfig.RoleFeaturePartDict[selectedTab.name];
    }
}