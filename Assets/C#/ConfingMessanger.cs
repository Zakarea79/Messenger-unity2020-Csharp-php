using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//-------------------
public class ConfingMessanger : MonoBehaviour
{
    [SerializeField] private Button SubMit;
    [SerializeField] private InputField myUserName;
    [SerializeField] private Text ErrorText;

    private void Start()
    {
        SubMit.onClick.AddListener(delegate
        {
            if (myUserName.text != "")
            {
                webApi.MyUsername = myUserName.text;
                SceneManager.LoadScene("ListChat");
            }
            else
            {
                ErrorText.text = "inputFild Empty";
            }
        });
    }
}
