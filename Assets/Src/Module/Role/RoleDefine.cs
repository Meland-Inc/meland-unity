using System.Collections.Generic;
namespace RoleDefine
{
    public enum eRoleGender
    {
        male,
        female
    }

    public static class RoleID
    {
        public const int MALE = 1001;
        public const int FEMALE = 1002;
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
    }
}