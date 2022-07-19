/*
 * @Author: xiang huan
 * @Date: 2022-07-19 16:19:58
 * @Description: 普通伤害效果
 * @FilePath: /meland-unity/Assets/Src/Module/Battle/SkillEffect/NormalDamageSE.cs
 * 
 */

public class NormalDamageSE : SkillEffectBase
{
    protected int _curHp;//剩余当前血量
    protected int _deltaHp;//血量差值
    protected MelandGame3.DamageState _result; //伤害结果
    public override bool IsRepeat => true; //效果球能否重复添加 
    public override void SetCustomData(System.Object data)
    {
        MelandGame3.DamageData damageData = data as MelandGame3.DamageData;
        this._curHp = damageData.CurrentInt;
        this._deltaHp = damageData.DeltaInt;
        this._result = damageData.DmgState;
    }

    public override void Clear()
    {
        _curHp = 0;
        _deltaHp = 0;
        _result = MelandGame3.DamageState.DamageStateNormal;
        base.Clear();
    }

    public override void Start()
    {

    }

}