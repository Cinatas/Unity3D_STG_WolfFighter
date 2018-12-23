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

    public Dictionary<string, Texture2D> textureResources;

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
        LoadResources();
        NextScene();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadResources()
    {
        #region 载入预制体
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
        #endregion
        #region 载入音频资源
        BGMs[1] = Resources.Load<AudioClip>("Sound/BGM/Stage1/bgm1");
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
        #endregion
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
