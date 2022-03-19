using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class UI_Setting_ChatList : MonoBehaviour
{
    [SerializeField] private Text Username;
    [SerializeField] private Button btn_bak, btn_new_chat, btn_Cansel, btn_Ok, openGithubPage;
    [SerializeField] private InputField UsenameInput;
    [SerializeField] private GameObject Panel_new_Chat;

    private string url = "http://zakarea.mygamesonline.org/Unity_chat/sendmessage.php";
    void Start()
    {
        Username.text = webApi.MyUsername;
        openGithubPage.onClick.AddListener(delegate
        {
            //Application.OpenURL("https://github.com/Zakarea79");
        });
        btn_new_chat.onClick.AddListener(ActiveNewCahat);
        btn_Cansel.onClick.AddListener(ActiveNewCahat);
        btn_bak.onClick.AddListener(Application.Quit);
        btn_Ok.onClick.AddListener(async delegate
        {
            if (UsenameInput.text != "")
            {
                string result = await webApi.sendData(url, new Dictionary<string, string>
                {
                    { "e1", webApi.MyUsername },
                    { "e2", UsenameInput.text },
                    { "txt", "" } }
                );
                if (result == "true")
                {
                    ActiveNewCahat();
                }
            }
        });
    }
    private void ActiveNewCahat()
    {
        Panel_new_Chat.SetActive(!Panel_new_Chat.activeSelf);
        btn_new_chat.GetComponent<Transform>().gameObject.SetActive(!Panel_new_Chat.activeSelf);
    }
}
