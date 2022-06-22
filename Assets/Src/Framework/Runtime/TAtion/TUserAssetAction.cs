/*
 * @Author: xiang huan
 * @Date: 2022-05-30 15:34:35
 * @Description: 通知界面显示和隐藏
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/TAtion/TUserAssetAction.cs
 * 
 */

namespace Runtime
{
    public class TUserAssetAction : RuntimeMsgTActionBase<TUserAssetResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.TUserAsset;
        }
        protected override bool Receive(int errorCode, string errorMsg, TUserAssetResponse rsp)
        {
            if (errorCode != RuntimeDefine.SUCCESS_CODE)
            {
                return false;
            }
            Message.RuntimeUserAssetUpdate?.Invoke(rsp);
            return true;
        }
    }
    public class TUserAssetResponse : RuntimeMessage
    {
        public int EnergyNum { get; private set; }     //能量数
        public int LandNum { get; private set; }  //地块数
        public int LandMaxNum { get; private set; } //max地块数
        public int GoldNum { get; private set; } //金币数
        public int TicketLandNum { get; private set; }
        public int VipLandNum { get; private set; }
        public int ActivityNum { get; private set; }
        public int OccupiedLandLimit { get; private set; }
        public string StakeVipName { get; private set; }
        public int GoldnumMaybePerHour { get; private set; }
        public int DitaminChallengePercent { get; private set; }
        public int GoldnumMaybePer24Hours { get; private set; }
        public int DitaminLand24Hours { get; private set; }
        public string WalletAddress { get; private set; } //钱包地址
    }
}