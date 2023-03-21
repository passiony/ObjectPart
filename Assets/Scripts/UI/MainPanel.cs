using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    private Button cxBtn;

    private Button zzBtn;
    
    void Start()
    {
        cxBtn = transform.Find("CXBtn").GetComponent<Button>();
        cxBtn.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene1"); });
        
        zzBtn = transform.Find("ZZBtn").GetComponent<Button>();
        zzBtn.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene2"); });
    }

}
