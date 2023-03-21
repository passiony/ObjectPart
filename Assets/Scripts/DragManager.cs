using System;
using UnityEngine;

/// <summary>
/// 物体部件拖回原位置的控制器
/// </summary>
public class DragManager : MonoBehaviour
{
    private ObjectManager objectMgr;
    
    private SceneObject dragObject;
    private SceneObject targetObject;

    public Material metalMat;
    public Material alphaMat;

    private void Start()
    {
        objectMgr = this.GetComponent<ObjectManager>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftAlt))
        {
            if (dragObject == null)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    dragObject = hit.collider.gameObject.GetComponent<SceneObject>();
                    if (dragObject != null)
                    {
                        var id = dragObject.name;
                        targetObject = objectMgr.GetOriginObj(id);
                        targetObject.gameObject.SetActive(true);
                        SetHilight(targetObject.gameObject, true);
                    }
                }
            }
            else
            {
                var word1 = dragObject.transform.position;
                var word2 = targetObject.transform.position;

                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                var center = (word1 + word2) / 2;
                var v1 = word2 - word1;
                var v2 = Camera.main.transform.position - center;
                var v3 = Vector3.Cross(v1, v2);
                var word3 = center + v3;

                //计算正对相机平面
                Plane plane = new Plane(word1, word2, word3);
                if (plane.Raycast(ray, out float num))
                {
                    var hitpos = ray.GetPoint(num);
                    dragObject.transform.position = hitpos;
                }
            }
        }

        //抬手后，直接设置坐标，隐藏高亮
        if (Input.GetMouseButtonUp(0))
        {
            if (targetObject != null)
            {
                dragObject.transform.position = targetObject.transform.position;
                dragObject.transform.rotation = targetObject.transform.rotation;
                targetObject.gameObject.SetActive(false);
            }

            dragObject = null;
            targetObject = null;
        }
    }

    //透明+高亮控制
    void SetHilight(GameObject obj, bool enable)
    {
        //透明
        var renders = obj.GetComponentsInChildren<Renderer>();
        foreach (var render in renders)
        {
            render.material = enable ? alphaMat : metalMat;
        }

        //高亮
        if (enable)
        {
            obj.AddComponent<FlashingController>();
        }
        else
        {
            Destroy(obj.GetComponent<FlashingController>());
        }
    }
}