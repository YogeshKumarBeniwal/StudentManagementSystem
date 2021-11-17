using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text[] Options;
    [SerializeField] private RectTransform[] menu;
    public Image[] icons;

    [SerializeField] private RectTransform exitWindow;
    //public Image exitWindowImage;

    public Image[] arrow;

    public Color textcolouronselect;

    public Color textcolour;
    public Color iconColour;

    public static string eventurl;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitWindow.gameObject.SetActive(true);
        }
    }

    public void onYesPressed()
    {
        Application.Quit();
    }

    public void onNoPressed()
    {
        exitWindow.gameObject.SetActive(false);
    }

    public void onProfile()
    {
        for(int i = 0; i<Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[0].gameObject.SetActive(true);
        Options[0].color = textcolouronselect;
        arrow[0].gameObject.SetActive(true);
        icons[0].color = Color.white;
    }

    public void onAttandence()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[1].gameObject.SetActive(true);
        Options[1].color = textcolouronselect;
        arrow[1].gameObject.SetActive(true);
        icons[1].color = Color.white;
    }

    public void onReport()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[2].gameObject.SetActive(true);
        Options[2].color = textcolouronselect;
        arrow[2].gameObject.SetActive(true);
        icons[2].color = Color.white;
    }

    public void onFeedback()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[3].gameObject.SetActive(true);
        Options[3].color = textcolouronselect;
        arrow[3].gameObject.SetActive(true);
        icons[3].color = Color.white;
    }

    public void onEvents()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[4].gameObject.SetActive(true);
        Options[4].color = textcolouronselect;
        arrow[4].gameObject.SetActive(true);
        icons[4].color = Color.white;
    }

    public void onNotice()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[5].gameObject.SetActive(true);
        Options[5].color = textcolouronselect;
        arrow[5].gameObject.SetActive(true);
        icons[5].color = Color.white;
    }

    public void onAboutApp()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[6].gameObject.SetActive(true);
        Options[6].color = textcolouronselect;
        arrow[6].gameObject.SetActive(true);
        icons[6].color = Color.white;
    }

    public void onAddStudent()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[7].gameObject.SetActive(true);
        Options[7].color = textcolouronselect;
        arrow[7].gameObject.SetActive(true);
        icons[7].color = Color.white;
    }

    public void onAddAdmin()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = textcolour;
            arrow[i].gameObject.SetActive(false);
            menu[i].gameObject.SetActive(false);
            icons[i].color = iconColour;
        }
        menu[8].gameObject.SetActive(true);
        Options[8].color = textcolouronselect;
        arrow[8].gameObject.SetActive(true);
        icons[8].color = Color.white;
    }
    public void KnowMore()
    {
        Application.OpenURL(eventurl);
    }

    public void FaceBook()
    {
        Application.OpenURL("https://www.facebook.com/");
    }

    public void tweetr()
    {
        Application.OpenURL(eventurl);
    }

}
