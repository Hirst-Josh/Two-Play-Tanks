using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoad : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject settingsmenu;
    public GameObject deathmatch;
    public GameObject capturetheflag;
    public GameObject selectgamemode;
    public GameObject controls;
    public Toggle Map1Toggle;
    public Toggle Map2Toggle;
    public Toggle Powerups;
    private int Intpowerups;
    public Toggle quickfire;
    private int Intquickfire;
    public Toggle rico;
    private int intrico;
    public Toggle missle;
    private int intmissle;
    public Toggle heathpacks;
    private int Intheath;
    public int deathmacth;
    public int capture;
    public int m4;
    public int t34;
    public int t72;
    public int missletank;
    public int smk;
    public Toggle Tm4;
    public Toggle Tt34;
    public Toggle Tt72;
    public Toggle Tmissletank;
    public Toggle Tsmk;
    public Toggle player1;
    public Toggle player2;
    public Toggle player1settings;
    public Toggle player2settings;
    public int playerint;
    public Image targetimage;
    public Sprite deimage;
    public Sprite captureimage;
    private void Start()
    {
        mainmenu.SetActive(true);
        playerint = 1;

    }

    public void LoadSelectMode()
    {
        selectgamemode.SetActive(true);
    }
    public void LoadSettings()
    {
        settingsmenu.SetActive(true);
    }
    public void LoadeathmatchMenu()
    {
        targetimage.sprite = deimage;
        deathmatch.SetActive(true);
    }
    public void Loadflagmenu()
    {
        targetimage.sprite = captureimage;
        capturetheflag.SetActive(true);
    }
    public void LoadMainmenu()
    {
        mainmenu.SetActive(true);
    }

    public void Loadcontrolmenu()
    {
        controls.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UNLoadSelectMode()
    {
        selectgamemode.SetActive(false);
    }

    public void unLoadcontrolmenu()
    {
        controls.SetActive(false);
    }
    public void UNLoadSettings()
    {
        settingsmenu.SetActive(false);
    }
    public void UNLoadeathmatchMenu()
    {
        deathmatch.SetActive(false);
    }
    public void UNLoadflagmenu()
    {
        capturetheflag.SetActive(false);
    }
    public void UNLoadMainmenu()
    {
        mainmenu.SetActive(false);
    }

    public void Togglelevel1()
    {
        if(Map1Toggle.isOn == true)
        {
            Map2Toggle.isOn = false;
        }
        else
        {
            Map2Toggle.isOn = true;
        }
    }

    public void Togglelevel2()
    {
        if (Map2Toggle.isOn == true)
        {
            Map1Toggle.isOn = false;
        }
        else
        {
            Map1Toggle.isOn = true;
        }
    }

    public void play()
    {
        // bool to int
        if(Powerups.isOn == true)
        {
            Intpowerups = 1;
        }
        else
        {
            Intpowerups = 0;
        }

        if (quickfire.isOn == true)
        {
            Intquickfire = 1;
        }
        else
        {
            Intquickfire = 0;
        }

        if (rico.isOn == true)
        {
            intrico = 1;
        }
        else
        {
            intrico = 0;
        }

        if (missle.isOn == true)
        {
            intmissle = 1;
        }
        else
        {
            intmissle = 0;
        }

        if (heathpacks.isOn == true)
        {
            Intheath = 1;
        }
        else
        {
            Intheath = 0;
        }

        if (Tm4.isOn == true) { m4 = 1;} else { m4 = 0; }
        if (Tt34.isOn == true) { t34 = 1; } else { t34 = 0; }
        if (Tt72.isOn == true) { t72 = 1; } else { t72 = 0; }
        if (Tmissletank.isOn == true) { missletank = 1; } else { missletank = 0; }
        if (Tsmk.isOn == true) { smk = 1; } else { smk = 0; }
        if (Tm4.isOn == false && Tt34.isOn == false && Tt72.isOn == false && Tmissletank.isOn == false && Tsmk.isOn == false)
        {
            m4 = 1;
        }
            // save data

        PlayerPrefs.SetInt("Powerups", Intpowerups);
        PlayerPrefs.SetInt("QuickFire", Intquickfire);
        PlayerPrefs.SetInt("Rico", intrico);
        PlayerPrefs.SetInt("Heath", Intheath);
        PlayerPrefs.SetInt("T34", t34);
        PlayerPrefs.SetInt("missle", intmissle);
        PlayerPrefs.SetInt("M4", m4);
        PlayerPrefs.SetInt("T72", t72);
        PlayerPrefs.SetInt("SMK", smk);
        PlayerPrefs.SetInt("Missle", missletank);
        PlayerPrefs.SetInt("deathmacth", deathmacth);
        PlayerPrefs.SetInt("capture", capture);
        PlayerPrefs.SetInt("player", playerint);
        PlayerPrefs.Save();

        if(Map1Toggle.isOn == true)
        {
            SceneManager.LoadScene("tankdemo");
        }
        else
        {
            SceneManager.LoadScene("level_2");
        }
    }

    public void deathmatchtrigger()
    {
        deathmacth = 1;
    }
    public void capturetheflagtrigger()
    {
        capture = 1;
    }
    public void modereset()
    {
        capture = 0;
        deathmacth = 0;
    }

    public void Toggleplayer()
    {
        if (player1.isOn == true)
        {
            player2.isOn = false;         
            playerint = 1;
        }
        else
        {
            player2.isOn = true;
            playerint = 2;
        }
    }

    public void Toggleplaye2()
    {
        if (player2.isOn == true)
        { 
            playerint = 2;
            player1.isOn = false;           
        }
        else
        {
            playerint = 1;
            player1.isOn = true;           
        }
    }







}
