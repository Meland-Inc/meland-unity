using UnityEditor;
using UnityEngine;
namespace Meland.Editor.DataTableTools
{
    public class DataTableGeneratorWindow : EditorWindow
    {
        private string _configPath;
        [MenuItem("devtool/csv")]
        public static void Init()
        {
            GetWindow<DataTableGeneratorWindow>().Show();
        }

        private void OnGUI()
        {
            //水平布局
            GUILayout.BeginHorizontal();
            {
                GUILayout.Label("*.svn表配置路径:", GUILayout.Width(80f));
                _configPath = GUILayout.TextField(_configPath);

                string preFolderPath = PlayerPrefs.GetString(Constant.ePlayerPrefsKey.SVN_CONFING_FOLDER_PATH.ToString());
                if (!string.IsNullOrEmpty(preFolderPath))
                {
                    _configPath = preFolderPath;
                }
                DataTableGeneratorUtil.SetPath(_configPath);
                if (GUILayout.Button("浏览", GUILayout.Width(50f)))
                {
                    _configPath = EditorUtility.OpenFolderPanel("select path", _configPath, "");
                    if (!string.IsNullOrEmpty(_configPath))
                    {
                        PlayerPrefs.SetString(Constant.ePlayerPrefsKey.SVN_CONFING_FOLDER_PATH.ToString(), _configPath);
                        PlayerPrefs.Save();
                    }
                    DataTableGeneratorUtil.SetPath(_configPath);
                }

            }
            GUILayout.EndHorizontal();
            if (GUILayout.Button("生成配置"))
            {
                DataTableGeneratorUtil.UpdateCsv();
                DataTableGeneratorUtil.GenerateDataTables();
                AssetDatabase.Refresh();
            }
        }
    }
}