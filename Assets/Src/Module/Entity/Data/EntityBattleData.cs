using MelandGame3;

/// <summary>
/// 客户端实体战斗数据
/// </summary>
public class EntityBattleData : EntityBattleDataCore
{
    public void Init(EntityProfile profile)
    {
        HP = profile.HpCurrent;
        HPMAX = profile.HpLimit;
        Level = profile.Lv;
        Att = profile.Att;
        Def = profile.Def;
        AttSpeed = profile.AttSpeed;
        CritRate = profile.CritRate;
        CritDmg = profile.CritDmg;
        HitRate = profile.HitRate;
        MissRate = profile.MissRate;

        GetComponent<SceneEntityEvent>().BattleDataInited?.Invoke(this);
    }

    public override void SetHP(int hp)
    {
        if (HP == hp)
        {
            return;
        }

        base.SetHP(hp);

        GetComponent<SceneEntityEvent>().HpUpated?.Invoke(hp);
    }

    public override void SetHPMAX(int hpMax)
    {
        if (HPMAX == hpMax)
        {
            return;
        }

        base.SetHPMAX(hpMax);

        GetComponent<SceneEntityEvent>().HpMaxUpdated?.Invoke(hpMax);
    }
}