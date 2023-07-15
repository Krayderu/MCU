using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject badgeUI;

    public GameObject broomUI;

    public bool isBroom = false;

    public bool isBadge = false;

    public bool isTexting = false;

    [SerializeField] private FocusMode focusMode;

    // Update is called once per frame
    void Update()
    {
        if (!isTexting)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    return;
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        focusMode.DisableFocusMode();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        focusMode.EnableFocusMode();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    void TextOn()
    {
        isTexting = true;
    }

    void TextOff()
    {
        isTexting = false;
    }

    void CallBadge()
    {
        if (isBadge)
        {
            badgeUI.SetActive(false);
            isBadge = false;
        }
        else
        {
            badgeUI.SetActive(true);
            isBadge = true;
        }

    }

    void CallBroom()
    {
        if (isBroom)
        {
            broomUI.SetActive(false);
            isBroom = false;
        }
        else
        {
            broomUI.SetActive(true);
            isBroom = true;
        }

    }

}
