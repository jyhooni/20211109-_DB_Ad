
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Bg_dark;
    public GameObject Pauseset;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickpause()
    {
       
       Bg_dark.SetActive(true);
       Pauseset.SetActive(true);
       
       Time.timeScale = 0;
    }


    public void clickplay()
    {

        Bg_dark.SetActive(false);
        Pauseset.SetActive(false);

        Time.timeScale = 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");

    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }


}
