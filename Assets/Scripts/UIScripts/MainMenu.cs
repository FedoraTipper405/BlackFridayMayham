using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Title;
    public GameObject MainMenuButtons;
    public GameObject Controls;
    public GameObject BackButton;
    private void Start()
    {
        Controls.SetActive(false);
        BackButton.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ControlsDisplay()
    {
        Title.SetActive(false);
        MainMenuButtons.SetActive(false);
        Controls.SetActive(true);
        BackButton.SetActive(true);
    }
    public void BackToMainMenu()
    {
        Title.SetActive(true);
        MainMenuButtons.SetActive(true);
        Controls.SetActive(false);
        BackButton.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
