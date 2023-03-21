using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景物体管理器
/// </summary>
public class ObjectManager : MonoBehaviour
{
    //原始物品对象根节点
    public Transform originGo;
    
    //散落部件物品对象根节点
    public Transform onlandGo;

    //存储物体的子节点part部件
    public Dictionary<string, SceneObject> originObject = new Dictionary<string, SceneObject>();
    public Dictionary<string, SceneObject> onlandObject = new Dictionary<string, SceneObject>();

    void Start()
    {
        var objs1 = originGo.GetComponentsInChildren<SceneObject>(true);
        foreach (var obj in objs1)
        {
            originObject.Add(obj.name, obj);
        }

        var objs2 = onlandGo.GetComponentsInChildren<SceneObject>(true);
        foreach (var obj in objs2)
        {
            onlandObject.Add(obj.name, obj);
        }
    }

    public SceneObject GetOriginObj(string id)
    {
        return originObject[id];
    }
}