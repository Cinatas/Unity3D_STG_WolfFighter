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
    public GameObject ClearEnemyAndBulletFX;

    [Header("Waves In Level1")]
    public GameObject[] EnemyWavesInLevel1;

    public GameObject medeaStageInFX;


    [Header("Boss In Level1")]
    public GameObject Boss1;

    [Header("Sound")]
    public AudioClip[] BGMs;
    public AudioClip BossBgm1;
    public AudioClip gameoverSFX;
    public AudioClip gamecompleteSFX;

    public Dictionary<string, Texture2D> textureResources;

    public float processRatio = 0;

    int maxProcessInt = 33;

    private void Awake()
    {
        _Instance = this;
        EnemyWavesInLevel1 = new GameObject[100];
        BGMs = new AudioClip[10];
        textureResources = new Dictionary<string, Texture2D>();
        
    }

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(LoadResources());
    }
	
	// Update is called once per frame
	void Update () {
        processRatio = (float)progressInt / (float)maxProcessInt;
	}

    IEnumerator LoadResources()
    {
        #region 载入预制体
        progressInt = 0;
        PlayerBulletPrefabs = Resources.LoadAll<GameObject>("Prefab/Bullet/MarisaBullets");
        yield return new WaitUntil(() => PlayerBulletPrefabs != null);
        progressInt += 1;        

        PlayerDeadExplodeFX = Resources.Load<GameObject>("Prefab/FX/PlayerDeadExplodeFX");
        yield return new WaitUntil(() => PlayerDeadExplodeFX != null);
        progressInt += 1;

        PlayerPrefab = Resources.Load<GameObject>("Prefab/Player/Marisa");
        yield return new WaitUntil(() => PlayerPrefab != null);
        progressInt += 1;

        EnemyWavesInLevel1[1] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave1");
        yield return new WaitUntil(() => EnemyWavesInLevel1[1] != null);
        progressInt += 1;

        EnemyWavesInLevel1[2] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave2");
        yield return new WaitUntil(() => EnemyWavesInLevel1[2] != null);
        progressInt += 1;

        EnemyWavesInLevel1[3] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave3");
        yield return new WaitUntil(() => EnemyWavesInLevel1[3] != null);
        progressInt += 1;

        EnemyWavesInLevel1[4] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave4");
        yield return new WaitUntil(() => EnemyWavesInLevel1[4] != null);
        progressInt += 1;

        EnemyWavesInLevel1[5] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave5");
        yield return new WaitUntil(() => EnemyWavesInLevel1[5] != null);
        progressInt += 1;

        EnemyWavesInLevel1[6] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave6");
        yield return new WaitUntil(() => EnemyWavesInLevel1[6] != null);
        progressInt += 1;

        EnemyWavesInLevel1[7] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave7");
        yield return new WaitUntil(() => EnemyWavesInLevel1[7] != null);
        progressInt += 1;

        EnemyWavesInLevel1[8] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave8");
        yield return new WaitUntil(() => EnemyWavesInLevel1[8] != null);
        progressInt += 1;

        EnemyWavesInLevel1[9] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave9");
        yield return new WaitUntil(() => EnemyWavesInLevel1[9] != null);
        progressInt += 1;

        EnemyWavesInLevel1[10] = Resources.Load<GameObject>("Prefab/Enemy/Level1/Wave10");
        yield return new WaitUntil(() => EnemyWavesInLevel1[10] != null);
        progressInt += 1;

        Boss1 = Resources.Load<GameObject>("Prefab/Enemy/Level1/Medea");
        yield return new WaitUntil(() => Boss1 != null);
        progressInt += 1;

        ClearEnemyAndBulletFX = Resources.Load<GameObject>("Prefab/FX/WaveFX");
        yield return new WaitUntil(() => ClearEnemyAndBulletFX != null);
        progressInt += 1;

        medeaStageInFX = Resources.Load<GameObject>("Prefab/FX/MedeaStageInFX");
        yield return new WaitUntil(() => medeaStageInFX != null);
        progressInt += 1;

        #endregion
        #region 载入音频资源
        BGMs[1] = Resources.Load<AudioClip>("Sound/BGM/Stage1/bgm1");
        yield return new WaitUntil(() => BGMs[1] != null);
        progressInt += 1;

        BossBgm1 = Resources.Load<AudioClip>("Sound/BGM/Stage1/MedeaBgm");
        yield return new WaitUntil(() => BossBgm1 != null);
        progressInt += 1;

        gameoverSFX = Resources.Load<AudioClip>("Sound/SFX/GameoverSFX");
        yield return new WaitUntil(() => gameoverSFX != null);
        progressInt += 1;

        gamecompleteSFX = Resources.Load<AudioClip>("Sound/SFX/GamecompleteSFX");
        yield return new WaitUntil(() => gamecompleteSFX != null);
        progressInt += 1;

        #endregion
        #region 载入图片资源        
        textureResources.Add("c001", LoadNpcTexture("Medea/Caster01a(中)"));
        progressInt++;
        textureResources.Add("c002", LoadNpcTexture("Medea/Caster01a(遠)"));
        progressInt++;
        textureResources.Add("c003", LoadNpcTexture("Medea/Caster01c(中)"));
        progressInt++;
        textureResources.Add("c004", LoadNpcTexture("Medea/Caster01c(遠)"));
        progressInt++;
        textureResources.Add("c005", LoadNpcTexture("Medea/Caster01d(中)"));
        progressInt++;
        textureResources.Add("c006", LoadNpcTexture("Medea/Caster01d(遠)"));
        progressInt++;
        textureResources.Add("c007", LoadNpcTexture("Medea/Caster01f(遠)"));
        progressInt++;
        textureResources.Add("c008", LoadNpcTexture("Medea/Caster02a(遠)"));
        progressInt++;
        textureResources.Add("c009", LoadNpcTexture("Medea/Caster03a(中)"));
        progressInt++;
        textureResources.Add("c010", LoadNpcTexture("Medea/Caster03a(遠)"));
        progressInt++;
        textureResources.Add("c011", LoadNpcTexture("Medea/Caster03b(中)"));
        progressInt++;
        textureResources.Add("c012", LoadNpcTexture("Medea/Caster03b(遠)"));
        progressInt++;
        textureResources.Add("c013", LoadNpcTexture("Medea/Caster05a(近)"));
        progressInt++;
        #endregion
        yield return new WaitForSeconds(1);
        NextScene();
    }

    void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    Texture2D LoadNpcTexture(string path)
    {
        return Resources.Load<Texture2D>("Texture/Npc/" + path);
    }
}
