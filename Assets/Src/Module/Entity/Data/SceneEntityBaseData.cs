using UnityEngine;

/// <summary>
/// 场景实体基础数据
/// </summary>
public class SceneEntityBaseData : MonoBehaviour
{

    [SerializeField]
    private string _id;

    [SerializeField]
    private eEntityType _type;


    public string ID => _id;
    public eEntityType Type => _type;

    public void Init(string id, eEntityType type)
    {
        _id = id;
        _type = type;
    }
}