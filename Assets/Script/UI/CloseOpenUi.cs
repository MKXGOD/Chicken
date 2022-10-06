using UnityEngine;
using UnityEngine.UI;

public class CloseOpenUi : MonoBehaviour
{
    public GameObject UpPanel;



    public void OpenUpPanel()
    { 
        UpPanel.SetActive(true);
    }

    public void Close()
    { 
        UpPanel.SetActive(false);
    }
}
