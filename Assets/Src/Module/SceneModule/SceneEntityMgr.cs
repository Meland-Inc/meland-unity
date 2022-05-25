using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景实体管理 管理着和服务器同步的所有实体
/// </summary>
public class SceneEntityMgr : MonoBehaviour
{
    private readonly Dictionary<string, SceneEntity> _entityMap = new();
}