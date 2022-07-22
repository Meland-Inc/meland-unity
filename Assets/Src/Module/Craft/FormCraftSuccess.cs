using System.IO;
using System;
using FairyGUI;
using UnityEngine;
public class FormCraftSuccess : FGUIForm
{
    private const string SUCCESS_EFFECT_RES = "Assets/Res/Prefab/Effect/CraftSuccess.prefab";
    private Transition _transShow;
    private GGraph _ladSpineEffect;
    private bool _needPlayOnInited = false;
    private bool _initEffect = false;
    private GameObject _effectGo;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _transShow = GCom.GetTransition("show");
        _ladSpineEffect = GetChild("ladSpineEffect").asGraph;
        InitEffectAsync();
    }

    protected override void OnDispose()
    {
        BasicModule.Asset.UnloadAsset<GameObject>(SUCCESS_EFFECT_RES, GetHashCode());
        base.OnDispose();
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        PlayEffect();

        if (userData is CraftResultData result)
        {
            GetChild("tfCount").asTextField.SetVar("count", result.Count.ToString()).FlushVars();
            DRItem drItem = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(result.ItemID);
            GetChild("icon").icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{drItem.Icon}.png");
        }
    }

    // protected override void OnBtnCloseClick()
    // {
    //     _effectGo.GetComponent<IAnimationCpt>().PlayAnim("default");
    // }

    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
        _ladSpineEffect.visible = false;
        _effectGo.GetComponent<IAnimationCpt>().PlayAnim("default");
    }

    private async void InitEffectAsync()
    {
        try
        {
            GameObject prefab = await BasicModule.Asset.LoadAsset<GameObject>(SUCCESS_EFFECT_RES, GetHashCode());
            _effectGo = Instantiate(prefab);
            _effectGo.transform.localScale = new Vector3(GlobalDefine.POS_UNIT_TO_PIX, GlobalDefine.POS_UNIT_TO_PIX, GlobalDefine.POS_UNIT_TO_PIX);
            _ladSpineEffect.SetNativeObject(new GoWrapper(_effectGo));
            SpineAnimationCpt animCpt = _effectGo.GetComponent<SpineAnimationCpt>();
            animCpt.Init();
            animCpt.EventDelegate += OnAnimEvent;
            OnInitEffect();
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.craft, $"init craft success effect failed");
        }
    }

    private void OnInitEffect()
    {
        _initEffect = true;
        if (_needPlayOnInited)
        {
            _needPlayOnInited = false;
            PlayEffect();
        }
    }

    private void PlayEffect()
    {
        if (!_initEffect)
        {
            _needPlayOnInited = true;
            return;
        }

        _ladSpineEffect.visible = true;
        IAnimationCpt animCpt = _effectGo.GetComponent<IAnimationCpt>();
        animCpt.PlayAnimQueued("start");
        animCpt.PlayAnimQueued("idle", true);
        _transShow.Play();
    }

    private void OnAnimEvent(string animName, eAnimationEventType eventType, object userData)
    {
        // if (animName == "default" && eventType == eAnimationEventType.Complete)
        // {
        //     Close();
        // }
    }
}

public class CraftResultData
{
    public int ItemID;
    public int Count;
    public CraftResultData(int itemID, int count)
    {
        Count = count;
        ItemID = itemID;
    }
}