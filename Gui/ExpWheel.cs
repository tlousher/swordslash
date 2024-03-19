using System.Collections;
using Misc;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class ExpWheel : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI level;
    public Image[] dots;
    [Header("Assets")]
    public Material materialGlow;
    public AudioClip dotClip;
    public AudioClip lvlClip;

    private AudioSource audioSource;

    private const float TimeBetweenDots = 0.1f;
    
    public void AddExp(int exp)
    {
        PlayerPrefs2.AddExperience(exp);
        StartCoroutine(DotsAnimation());
    }

    public void UpdateWheel()
    {
        UpdateDots();
        level.text = PlayerPrefs2.PlayerLevel.ToString();
    }

    void Start()
    {
        //UpdateWheel();
        audioSource = GetComponent<AudioSource>();
    }

    public void AddExperience()
    {
        PlayerPrefs2.AddExperience(GameManager.instance.score);
        StartCoroutine(DotsAnimation());
    }

    private void UpdateDots()
    {
        for (int i = 0; i < DotsCount; i++)
        {
            DotOn(i);
        }
        for (int i = DotsCount; i < dots.Length; i++)
        {
            DotOff(i);
        }
    }

    public IEnumerator DotsAnimation()
    {
        int lvl = int.Parse(level.text);

        while (lvl < PlayerPrefs2.PlayerLevel)
        {
            yield return StartCoroutine(PlayFullRow());
            lvl++;

            //Resets all the dots on the wheel
            for (int i = 0; i < dots.Length; i++)
            {
                DotOff(i);
            }
            level.text = lvl.ToString();
            audioSource.PlayOneShot(lvlClip);
            yield return new WaitForSeconds(TimeBetweenDots);
        }

        for (int i = 0; i < DotsCount; i++)
        {
            DotOn(i);
            audioSource.PlayOneShot(dotClip);
            yield return new WaitForSeconds(TimeBetweenDots);
        }
    }

    private IEnumerator PlayFullRow()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            if (dots[i].material != materialGlow)
            {
                DotOn(i);
                audioSource.PlayOneShot(dotClip);
                yield return new WaitForSeconds(TimeBetweenDots);
            }
        }
    }

    private void DotOn(int i)
    {
        dots[i].material = materialGlow;
        dots[i].GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>(true).enabled = true;
    }

    private void DotOff(int i)
    {
        dots[i].material = null;
        dots[i].GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>(true).enabled = false;
    }

    public int DotsCount
    {
        get
        {
            float exp = PlayerPrefs2.PlayerExperience - PlayerPrefs2.LevelStart;
            float expTop = PlayerPrefs2.LevelEnd - PlayerPrefs2.LevelStart;

            return Mathf.FloorToInt(dots.Length * (exp / expTop));
        }
    }
}
