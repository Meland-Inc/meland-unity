using GameFramework.UI;
using UnityGameFramework.Runtime;
using UnityEngine;

public class FGUIFormHelper : UIFormHelperBase
{
    private ResourceComponent _resourceComponent = null;
    private void Start()
    {
        _resourceComponent = GameEntry.GetComponent<ResourceComponent>();
        if (_resourceComponent == null)
        {
            Log.Fatal("Resource component is invalid");
            return;
        }
    }
    public override IUIForm CreateUIForm(object uiFormInstance, IUIGroup uiGroup, object userData)
    {
        GameObject go = uiFormInstance as GameObject;
        if (go == null)
        {
            Log.Error("uiFormInstance isn't GameObject.");
            return null;
        }

        Transform transform = go.transform;
        transform.SetParent(((MonoBehaviour)uiGroup.Helper).transform);
        return go.GetOrAddComponent<UIForm>();
    }

    public override object InstantiateUIForm(object uiFormAsset)
    {
        return Instantiate((Object)uiFormAsset);
    }

    public override void ReleaseUIForm(object uiFormAsset, object uiFormInstance)
    {
        _resourceComponent.UnloadAsset(uiFormAsset);
        Destroy((Object)uiFormInstance);
    }
}