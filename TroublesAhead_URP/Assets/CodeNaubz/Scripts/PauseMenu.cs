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

    public GameObject stoolUI;

    public GameObject creditUI;

    private Animator animator;

    public bool isBroom = false;

    public bool isBadge = false;

    public bool isStool = false;

    public bool isTexting = false;

    [SerializeField] private FocusMode focusMode;

    private void Start()
    {
        animator = creditUI.GetComponent<Animator>();
    }



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

    public void TextOn()
    {
        isTexting = true;
    }

    public void TextOff()
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

    void CallStool()
    {
        if (isStool)
        {
            stoolUI.SetActive(false);
            isStool = false;
        }
        else
        {
            stoolUI.SetActive(true);
            isStool = true;
        }

    }

    void CallCredit()
    {
        creditUI.SetActive(true);
        animator.enabled = true;
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

}

