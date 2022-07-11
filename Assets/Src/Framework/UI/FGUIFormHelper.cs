using GameFramework.UI;
using UnityGameFramework.Runtime;
using UnityEngine;

public class FGUIFormHelper : DefaultUIFormHelper
{
    public override IUIForm CreateUIForm(object uiFormInstance, IUIGroup uiGroup, object userData)
    {
        GameObject go = uiFormInstance as GameObject;
        if (go == null)
        {
            Log.Error("uiFormInstance isn't GameObject.");
            return null;
        }

        go.layer = LayerMask.NameToLayer("UI");
        Transform transform = go.transform;
        transform.SetParent(((MonoBehaviour)uiGroup.Helper).transform);
        return go.GetOrAddComponent<UIForm>();
    }
}