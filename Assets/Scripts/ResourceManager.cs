using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager _Instance = null;

    int progressInt = 0;
    [Header("Player")]
    public GameObject PlayerPrefab;
    public GameObject[] PlayerBulletPrefabs;
    public GameObject PlayerDeadExplodeFX;

    [Header("Waves In Level1")]
    public GameObject[] EnemyWavesInLevel1;

    [Header("Sound")]
    public AudioClip[] BGMs;
    private void Awake()
    {
        _Instance = this;
        EnemyWavesInLevel1 = new GameObject[100];
        BGMs = new AudioClip[10];
    }

    // Use this for initialization
    void Start ()
    {
        LoadResources();
        NextScene();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadResources()
    {
        progressInt = 0;
        PlayerBulletPrefabs = Resources.LoadAll<GameObject>("Prefab/Bullet/MarisaBullets");
        progressInt += 1;
        PlayerDeadExplodeFX = Resources.Load<GameObject>("Prefab/FX/PlayerDeadExplodeFX");
        progressInt += 1;
        EnemyWavesInLevel1[1] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave1");
        progressInt += 1;
        EnemyWavesInLevel1[2] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave2");
        progressInt += 1;
        EnemyWavesInLevel1[3] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave3");
        progressInt += 1;
        EnemyWavesInLevel1[4] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave4");
        progressInt += 1;
        EnemyWavesInLevel1[5] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave5");
        progressInt += 1;
        EnemyWavesInLevel1[6] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave6");
        progressInt += 1;
        EnemyWavesInLevel1[7] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave7");
        progressInt += 1;

        BGMs[1] = Resources.Load<AudioClip>("Sound/BGM/Stage1/bgm1");
        progressInt += 1;
    }

    void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
