/*
 * @Author: xiang huan
 * @Date: 2022-07-19 10:49:14
 * @Description: 客户端技能效果球工厂
 * @FilePath: /meland-unity/Assets/Src/Module/Battle/SkillEffect/ClientSkillEffectFactory.cs
 * 
 */
using System;
using System.Collections.Generic;
using GameFramework;
using UnityGameFramework.Runtime;


public class ClientSkillEffectFactory : SkillEffectFactory
{
    /// <summary>
    /// 初始化效果工厂Map
    /// </summary>
    public override void InitSkillEffectMap()
    {
        s_skillEffectMap = new(){
            {BattleDefine.eSkillEffectId.NormalDamageSE, typeof(NormalDamageSE)},
        };
    }
}