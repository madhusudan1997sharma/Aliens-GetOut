using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas LevelChoosingCanvas;
    public Canvas GameplayCanvas;
    public Canvas LevelCompleteCanvas;
    public Slider ForceBar;
    public Text LiveScore;
    public Text FinalScore;
    public Sprite Pause;
    public Sprite Play;
    public Button PauseButton;
    public Text GamePaused;
    public Text Tutorial1Text;
    public Text Tutorial2Text;
    public Text Tutorial3Text;
    public Image Tutorial1Image;
    public Image Tutorial2Image;
    public Image Tutorial3Image;


    public GameObject[] Level;
    public Button[] LevelButton;

    float score = 500;

    void Start()
    {
        if (PlayerPrefs.HasKey("FirstTime"))
        {
            Destroy(Tutorial1Text);
            Destroy(Tutorial2Text);
            Destroy(Tutorial3Text);
            Destroy(Tutorial1Image);
            Destroy(Tutorial2Image);
            Destroy(Tutorial3Image);
        }
        else
        {
            PlayerPrefs.SetInt("FirstTime", 1);
        }

        //PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        for (int i = 1; i < LevelButton.Length; i++)
        {
            if (PlayerPrefs.GetInt("LevelCleared") >= i)
            {
                LevelButton[i].GetComponent<Button>().interactable = true;
            }
        }


        if (GameplayCanvas.GetComponent<Canvas>().enabled == true && Time.time > 3)
        {
            if (GameObject.FindGameObjectsWithTag("Alien").Length == 0)
            {
                for (int j = 1; j <= LevelButton.Length; j++)
                {
                    if (GameObject.Find("Level " + j + "(Clone)"))
                    {
                        if (PlayerPrefs.GetInt("LevelCleared") < j)
                            PlayerPrefs.SetInt("LevelCleared", j);
                    }
                }



                GameplayCanvas.GetComponent<Canvas>().enabled = false;
                LevelCompleteCanvas.GetComponent<Canvas>().enabled = true;
                FinalScore.text = "Score: " + PlayerPrefs.GetInt("Score");
                score = 500;
            }
        }

        if (GameplayCanvas.GetComponent<Canvas>().enabled == true)
        {
            score -= Time.deltaTime * 1.3f;
            int localscore = (int)score;
            LiveScore.text = "Score: " + localscore;
            PlayerPrefs.SetInt("Score", localscore);
        }
    }

    public void ShootClick()
    {
        if (Time.timeScale == 1)
        {
            PlayerPrefs.SetFloat("Force", ForceBar.GetComponent<Slider>().value);
            PlayerPrefs.SetInt("Shoot", 1);
        }
    }

    public void PlayClick()
    {
        MainMenuCanvas.GetComponent<Canvas>().enabled = false;
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void NextClick()
    {
        Destroy(Tutorial1Text);
        Destroy(Tutorial2Text);
        Destroy(Tutorial3Text);
        Destroy(Tutorial1Image);
        Destroy(Tutorial2Image);
        Destroy(Tutorial3Image);

        LevelCompleteCanvas.GetComponent<Canvas>().enabled = false;
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = true;
        Destroy(GameObject.FindGameObjectWithTag("Level"));
        Destroy(GameObject.FindGameObjectWithTag("BackImage"));
    }

    public void BackClick()
    {
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        MainMenuCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void PauseClick()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PauseButton.GetComponent<Image>().sprite = Play;
            GamePaused.GetComponent<Text>().enabled = true;
            PauseButton.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
            PauseButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
            PauseButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -280, 0);
            PauseButton.GetComponent<RectTransform>().localScale = new Vector2(2.5f, 2.5f);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PauseButton.GetComponent<Image>().sprite = Pause;
            GamePaused.GetComponent<Text>().enabled = false;
            PauseButton.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            PauseButton.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
            PauseButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(30, 30, 0);
            PauseButton.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        }
    }


    ///////////////////////////////////......LEVELS.....////////////////////////////////////////////
    public void oneClick()
    {
        Instantiate(Level[0], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void twoClick()
    {
        Instantiate(Level[1], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void ThreeClick()
    {
        Instantiate(Level[2], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void FourClick()
    {
        Instantiate(Level[3], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void FiveClick()
    {
        Instantiate(Level[4], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void SixClick()
    {
        Instantiate(Level[5], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void SevenClick()
    {
        Instantiate(Level[6], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void EightClick()
    {
        Instantiate(Level[7], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void NineClick()
    {
        Instantiate(Level[8], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TenClick()
    {
        Instantiate(Level[9], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void ElevenClick()
    {
        Instantiate(Level[10], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwelveClick()
    {
        Instantiate(Level[11], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void ThirteenClick()
    {
        Instantiate(Level[12], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void FourteenClick()
    {
        Instantiate(Level[13], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void FifteenClick()
    {
        Instantiate(Level[14], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void SixteenClick()
    {
        Instantiate(Level[15], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void SeventeenClick()
    {
        Instantiate(Level[16], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void EighteenClick()
    {
        Instantiate(Level[17], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void NinteenClick()
    {
        Instantiate(Level[18], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentyClick()
    {
        Instantiate(Level[19], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentyoneClick()
    {
        Instantiate(Level[20], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentytwoClick()
    {
        Instantiate(Level[21], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentythreeClick()
    {
        Instantiate(Level[22], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentyfourClick()
    {
        Instantiate(Level[23], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentyfiveClick()
    {
        Instantiate(Level[24], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentysixClick()
    {
        Instantiate(Level[25], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentysevenClick()
    {
        Instantiate(Level[26], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentyeightClick()
    {
        Instantiate(Level[27], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void TwentynineClick()
    {
        Instantiate(Level[28], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void ThirtyClick()
    {
        Instantiate(Level[29], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void ThirtyoneClick()
    {
        Instantiate(Level[30], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void ThirtytwoClick()
    {
        Instantiate(Level[31], new Vector3(0, 0, 0), Quaternion.identity);
        LevelChoosingCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
    }
}