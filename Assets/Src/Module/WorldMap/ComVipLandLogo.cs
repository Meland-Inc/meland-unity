using FairyGUI;
namespace WorldMap
{
    public class ComVipLandLogo : GButton
    {
        public bool IsGroup { get; private set; }
        public void SetIsGroup(bool isGroup)
        {
            IsGroup = isGroup;
        }

        public Bian.BigWorldLogoInfo LogoInfo { get; private set; }
        public void SetLogoInfo(Bian.BigWorldLogoInfo logoInfo)
        {
            LogoInfo = logoInfo;
        }
    }
}