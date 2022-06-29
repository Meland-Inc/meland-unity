/*
 * @Author: xiang huan
 * @Date: 2022-06-27 16:56:03
 * @Description: 服务器场景数据
 * @FilePath: /meland-unity/Assets/Editor/ServerScene/ServerSceneWindow.cs
 * 
 */
using System;
using System.IO;
using System.Text;
using GameFramework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Meland.Editor.ServerScene
{
    public class ServerSceneWindow : EditorWindow
    {
        private const string SERVER_SCENE_FILE_PATH = "Assets/Res/ServerScene/WorldServer.unity";
        private const string SERVER_SCENE_PATH = "Assets/Res/ServerScene";
        private const string SERVER_SCENE_JSON_FILE_PATH = "Assets/Res/ServerScene/WorldServer.json";
        private const string SERVER_SCENE_ROOT_NAME = "ServerDataNodeRoot";
        [MenuItem("devtool/serverScene")]
        public static void Init()
        {
            GetWindow<ServerSceneWindow>().Show();
        }
        private void OnGUI()
        {
            if (GUILayout.Button("打开服务器场景"))
            {
                _ = EditorSceneManager.OpenScene(SERVER_SCENE_FILE_PATH, OpenSceneMode.Additive);
            }
            if (GUILayout.Button("关闭并保存服务器场景"))
            {
                UnityEngine.SceneManagement.Scene serverScene = EditorSceneManager.OpenScene(SERVER_SCENE_FILE_PATH, OpenSceneMode.Additive);
                _ = EditorSceneManager.SaveScene(serverScene);
                _ = EditorSceneManager.CloseScene(serverScene, true);
            }
            if (GUILayout.Button("导出服务器场景数据"))
            {
                UnityEngine.SceneManagement.Scene serverScene = UnityEditor.SceneManagement.EditorSceneManager.GetSceneByName(SERVER_SCENE_FILE_PATH);
                _ = UnityEditor.SceneManagement.EditorSceneManager.SaveScene(serverScene);
                GameObject rootObject = GameObject.Find(SERVER_SCENE_ROOT_NAME);
                if (rootObject == null)
                {
                    return;
                }
                if (rootObject.TryGetComponent(out IServerDataNodeCpt dataCpt))
                {
                    object data = dataCpt.GetServerData();
                    string dataJson = Unity.Plastic.Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    string outputFileName = Utility.Path.GetRegularPath(Path.Combine(SERVER_SCENE_JSON_FILE_PATH));

                    try
                    {
                        StringBuilder stringBuilder = new(dataJson);

                        using (FileStream fileStream = new(outputFileName, FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter stream = new(fileStream, Encoding.UTF8))
                            {
                                stream.Write(stringBuilder.ToString());
                            }
                        }
                        UnityGameFramework.Editor.OpenFolder.Execute(SERVER_SCENE_PATH);
                        AssetDatabase.Refresh();

                        Debug.Log(Utility.Text.Format("Generate Server Data file '{0}' success.", outputFileName));
                    }
                    catch (Exception exception)
                    {
                        Debug.LogError(Utility.Text.Format("Generate Server Data file '{0}' failure, exception is '{1}'.", outputFileName, exception));
                    }
                }
            }
        }
    }
}