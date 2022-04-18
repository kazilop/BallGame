using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    public GameObject bestPanel;
    public GameObject mainMenu;

    public Menusystem menusystem;

    private void Update()
    {
        CheckEsc();
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void ShowBest()
    {
        mainMenu.SetActive(false);
        bestPanel.SetActive(true);
    }


    private void CheckEsc()
    {
        if (bestPanel.activeInHierarchy)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                mainMenu.SetActive(true);
                bestPanel.SetActive(false);

                menusystem.Start();
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
