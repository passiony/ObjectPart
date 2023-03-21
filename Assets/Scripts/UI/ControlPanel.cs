using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    private Button quitBtn;
    
    void Start()
    {
        quitBtn = transform.Find("QuitBtn").GetComponent<Button>();
        
        quitBtn.onClick.AddListener(() => { SceneManager.LoadScene("MainScene"); });
    }

}
