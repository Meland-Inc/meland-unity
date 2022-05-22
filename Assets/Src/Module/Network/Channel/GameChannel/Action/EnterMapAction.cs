using Bian;

/// <summary>
/// 进游戏场景
/// </summary>
public class EnterMapAction : GameChannelNetMsgRActionBase<EnterMapRequest, EnterMapResponse>
{
    public static void Req()
    {
        EnterMapRequest req = GenerateReq();
        SendAction<EnterMapAction>(req);
    }

    protected override string GetEnvelopeReqName()
    {
        return "EnterMapRequest";
    }

    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.EnterMap;
    }

    protected override bool Receive(int errorCode, string errorMsg, EnterMapResponse rsp, EnterMapRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        // DataManager.mapDataPool.setIsMapTemplate(rsp.map.isEdit);
        // DataManager.mapDataPool.setIdeEnable(rsp.map.isEditMap);
        // DataManager.mapDataPool.setRoomType(rsp.roomType);

        // LoginControl.instance.setLoginedStatus(true);//兼容服务器现在会把该协议在登陆之前下发 导致很多初始化请求
        // NetLoadingManager.instance.sendNextMsgAfterMap();
        // DataManager.minimapModel.setMapInfo(rsp.map);

        if (GFEntry.Procedure.CurrentProcedure.GetType() == typeof(GameProcedure))
        {
            comeBackToMap(rsp);
        }
        else
        {
            enterNewMap(rsp);
        }

        return true;
    }

    private void comeBackToMap(EnterMapResponse rsp)
    {
        InitPlayerDataAndRole(rsp);
    }

    /**进入新地图*/
    private void enterNewMap(EnterMapResponse rsp)
    {

        // MapTileConfigManager.instance.initSvrChunkInfo(rsp.map);

        InitPlayerDataAndRole(rsp);
    }

    /**初始化玩家数据和角色 */
    private void InitPlayerDataAndRole(EnterMapResponse rsp)
    {
        Player playerData = rsp.Me;
        DataManager.MainPlayer.InitRoleData(playerData.Id);
        SceneEntity sceneRole = SceneModule.EntityMgr.AddMainPlayerRole(playerData.Id);
        sceneRole.Root.GetComponent<NetInputMove>().ForcePosition(rsp.Location, playerData.Dir);
    }
}