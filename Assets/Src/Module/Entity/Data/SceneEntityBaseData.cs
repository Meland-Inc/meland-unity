using UnityEngine;
using Bian;

/// <summary>
/// 场景实体基础数据
/// </summary>
public class SceneEntityBaseData : MonoBehaviour
{

    [SerializeField]
    private string _id;

    [SerializeField]
    private EntityType _type;



    public string ID => _id;
    public EntityType Type => _type;


    public void Init(string id, EntityType type)
    {
        _id = id;
        _type = type;
    }

    public void Reset()
    {
        _id = string.Empty;
        _type = EntityType.EntityTypeAll;
    }
}