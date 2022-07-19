using System.Collections.Generic;
using MelandGame3;

namespace RoleDefine
{
    public enum eRoleGender
    {
        male,
        female
    }

    public static class RoleID
    {
        public const int MALE = 10001;
        public const int FEMALE = 10002;
    }

    public enum eRoleFeaturePart
    {
        hair = 1,
        clothes = 2,//上衣
        glove = 3,
        pants = 4,
        face = 5,
        eye = 6,
        mouth = 7,
        eyebrow = 8,
        /*9～13被机器人占去了*/
        shoes = 14,
    }

    public static class RoleConfig
    {
        public static readonly Dictionary<string, eRoleFeaturePart> RoleFeaturePartDict = new()
        {
            {"hair",eRoleFeaturePart.hair},
            {"clothes",eRoleFeaturePart.clothes},
            {"glove",eRoleFeaturePart.glove},
            {"pants",eRoleFeaturePart.pants},
            {"face",eRoleFeaturePart.face},
            {"eye",eRoleFeaturePart.eye},
            {"mouth",eRoleFeaturePart.mouth},
            {"eyebrow",eRoleFeaturePart.eyebrow},
            {"shoes",eRoleFeaturePart.shoes},
        };

        public static readonly Dictionary<EntityProfileField, string> RoleProfileFieldDict = new()
        {
            {EntityProfileField.EntityProfileFieldLv, "Lv"},
            {EntityProfileField.EntityProfileFieldExp, "Exp"},
            {EntityProfileField.EntityProfileFieldAtt, "Att"},
            {EntityProfileField.EntityProfileFieldAttSpeed, "AttSpeed"},
            {EntityProfileField.EntityProfileFieldDef, "Def"},
            {EntityProfileField.EntityProfileFieldHpLimit, "HpLimit"},
            {EntityProfileField.EntityProfileFieldCritRate, "CritRate"},
            {EntityProfileField.EntityProfileFieldCritDamage, "CritDmg"},
            {EntityProfileField.EntityProfileFieldMissRate, "MissRate"},
            {EntityProfileField.EntityProfileFieldMoveSpeed, "MoveSpeed"},
            {EntityProfileField.EntityProfileFieldPushDmg, "PushDmg"},
            {EntityProfileField.EntityProfileFieldPushDist, "PushDist"},
            {EntityProfileField.EntityProfileFieldHpCurrent, "HpCurrent"},
            {EntityProfileField.EntityProfileFieldHpRecovery, "HpRecovery"},
        };
    }
}