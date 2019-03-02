using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WolfFighter.Player;
using WolfFighter.UI;

public class GameManager : MonoBehaviour {
    public static GameManager _Instance = null;

    public int PlayerIndex;
    public int PlayerWeaponLevel;
    public float HurtCoolDownTime;


    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        HurtCoolDownTime = 1;
    }

    public void RespwanPlayer()
    {
        if(Player._Instance == null)
        {
            GameObject objPrefab = ResourceManager._Instance.PlayerPrefab;
            Instantiate(objPrefab);
        }
    }

    public void GameOver()
    {
        StartCoroutine(GameoverProcess());
    }

    IEnumerator GameoverProcess()
    {
        yield return new WaitForSeconds(3);
        SoundManager._Instance.PlayBGM(ResourceManager._Instance.gameoverSFX);
        UIManager._Instance.compPanel.ShowGameoverImage();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    public void GameComplete()
    {
        StartCoroutine(GameCompleteProcess());
    }


    IEnumerator GameCompleteProcess()
    {
        UIManager._Instance.compPanel.ShowCompleteImage();
        SoundManager._Instance.PlayBGM(ResourceManager._Instance.gamecompleteSFX);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        SoundManager._Instance.BGMpause();
    }

    public void GameContinue()
    {
        Time.timeScale = 1;
        SoundManager._Instance.BGMcontinue();
    }

    public void BossTimerStart()
    {
        UIManager._Instance.bossPanel.StartBossTimer();
    }
}
