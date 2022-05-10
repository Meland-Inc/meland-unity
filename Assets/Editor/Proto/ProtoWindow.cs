using UnityEditor;
using UnityEngine;

public class ProtoWindow : EditorWindow
{
    private string _protoPath;
    [MenuItem("devtool/proto")]
    public static void Init()
    {
        GetWindow<ProtoWindow>().Show();
    }

    private void OnGUI()
    {
        //水平布局
        GUILayout.BeginHorizontal();
        {
            GUILayout.Label("*.proto路径:", GUILayout.Width(80f));
            _protoPath = GUILayout.TextField(_protoPath);

            string preFolderPath = PlayerPrefs.GetString(Constant.ePlayerPrefsKey.PROTOS_FOLDER_PATH.ToString());
            if (!string.IsNullOrEmpty(preFolderPath))
            {
                _protoPath = preFolderPath;
            }

            if (GUILayout.Button("浏览", GUILayout.Width(50f)))
            {
                _protoPath = EditorUtility.OpenFolderPanel("select path", _protoPath, "");
                if (!string.IsNullOrEmpty(_protoPath))
                {
                    PlayerPrefs.SetString(Constant.ePlayerPrefsKey.PROTOS_FOLDER_PATH.ToString(), _protoPath);
                    PlayerPrefs.Save();
                }
            }
        }
        GUILayout.EndHorizontal();

        if (GUILayout.Button("开始转换"))
        {
            try
            {
                Debug.Log(".*proto文件: 开始转换");
                new ProtoHandler().Handle(_protoPath);
                Debug.Log(".*proto文件: 转换成功");
            }
            catch (System.Exception ex)
            {
                Debug.Log($".*proto文件: 失败 ${ex.Message}");
            }
        }
    }
}