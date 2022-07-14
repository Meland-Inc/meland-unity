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
using UnityEngine.SceneManagement;

namespace Meland.Editor.ServerScene
{
    public class ServerSceneWindow : EditorWindow
    {
        private const string SERVER_SCENE_FILE_PATH = "Assets/RawResource/ServerScene/ServerWorldConfigScene.unity";
        private const string SERVER_SCENE_CONFIG_PATH = "Assets/Plugins/SharedCore/Res/Config/";
        private const string SERVER_SCENE_JSON_FILE_PATH = "Assets/Plugins/SharedCore/Res/Config/ServerWorldConfig.json";
        private const string SERVER_SCENE_ROOT_NAME = "ServerDataNodeRoot";
        private const string SERVER_WORLD_SCENE_FILE_PATH = "Assets/Plugins/SharedCore/Res/Scene/ServerWorldScene.unity";
        private const string SERVER_WORLD_SCENE_NAV_MESH_FILE_PATH = "Assets/Plugins/SharedCore/Res/Scene/ServerWorldScene/NavMesh.asset";

        [MenuItem("devtool/serverScene")]
        public static void Init()
        {
            GetWindow<ServerSceneWindow>().Show();
        }
        private void OnGUI()
        {
            if (GUILayout.Button("打开配置场景"))
            {
                _ = EditorSceneManager.OpenScene(SERVER_SCENE_FILE_PATH, OpenSceneMode.Additive);
            }
            if (GUILayout.Button("关闭并保存配置场景"))
            {
                UnityEngine.SceneManagement.Scene serverScene = EditorSceneManager.OpenScene(SERVER_SCENE_FILE_PATH, OpenSceneMode.Additive);
                _ = EditorSceneManager.SaveScene(serverScene);
                _ = EditorSceneManager.CloseScene(serverScene, true);
            }
            if (GUILayout.Button("导出配置场景"))
            {
                Scene serverScene = EditorSceneManager.OpenScene(SERVER_SCENE_FILE_PATH, OpenSceneMode.Additive);
                _ = EditorSceneManager.SaveScene(serverScene);
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
                        UnityGameFramework.Editor.OpenFolder.Execute(SERVER_SCENE_CONFIG_PATH);
                        AssetDatabase.Refresh();

                        Debug.Log(Utility.Text.Format("Generate Server Data file '{0}' success.", outputFileName));
                    }
                    catch (Exception exception)
                    {
                        Debug.LogError(Utility.Text.Format("Generate Server Data file '{0}' failure, exception is '{1}'.", outputFileName, exception));
                    }
                }
                _ = EditorSceneManager.CloseScene(serverScene, true);
            }

            if (GUILayout.Button("导出当前场景碰撞数据"))
            {
                try
                {
                    Scene serverWorldScene = EditorSceneManager.OpenScene(SERVER_WORLD_SCENE_FILE_PATH, OpenSceneMode.Additive);
                    GameObject[] serverObjectArray = serverWorldScene.GetRootGameObjects();
                    for (int i = 0; i < serverObjectArray.Length; i++)
                    {
                        DestroyImmediate(serverObjectArray[i]);
                    }
                    Scene scene = SceneManager.GetActiveScene();
                    GameObject[] gameObjectArray = scene.GetRootGameObjects();
                    for (int i = 0; i < gameObjectArray.Length; i++)
                    {
                        GameObject gameObject = gameObjectArray[i];
                        GameObject newObject = Instantiate(gameObject);
                        newObject.name = gameObject.name;
                        SceneManager.MoveGameObjectToScene(newObject, serverWorldScene);
                        ServerSceneUtil.DestroyObjectComponent(newObject);
                    }
                    _ = EditorSceneManager.SaveScene(serverWorldScene);
                    _ = EditorSceneManager.CloseScene(serverWorldScene, true);
                    EditorUtility.DisplayDialog("Info", "导出场景碰撞数据成功", "OK");
                }
                catch (System.Exception)
                {
                    EditorUtility.DisplayDialog("Error", "导出场景碰撞数据错误", "OK");
                    throw;
                }
            }

            if (GUILayout.Button("导出当前场景网格数据"))
            {
                try
                {
                    Scene scene = SceneManager.GetActiveScene();
                    string navMesh = Path.Combine(scene.path.Substring(0, scene.path.LastIndexOf('.')), "NavMesh.asset");
                    File.Copy(navMesh, SERVER_WORLD_SCENE_NAV_MESH_FILE_PATH, true);
                    EditorUtility.DisplayDialog("Info", "导出网格数据成功", "OK");
                }
                catch (System.Exception)
                {
                    EditorUtility.DisplayDialog("Error", "导出网格数据错误", "OK");
                    throw;
                }
            }
        }
    }
}