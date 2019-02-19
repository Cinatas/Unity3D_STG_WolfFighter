using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using WolfFighter.UI;
using WolfFighter.UI.Boss;
using WolfFighter.Utility;
using WolfFighter.Player;
using WolfFighter.level1;

namespace WolfFighter.Level1
{
    /// <summary>
    /// 美狄亚Boss类
    /// </summary>
    public class BossMedea : MonoBehaviour
    {
       
        SpriteRenderer sp;
        Animator aniCon;
        MedeaState state;

        new Collider2D collider;

        public MedeaState State
        {
            get
            {
                return state;
            }

            set
            {
                if (state != value)
                {
                    state = value;
                    ChangeState(value);
                }                
            }
        }
        public static BossMedea _Instance = null;

        public int Hp;
        public float castProgress;

        public GameObject poses;

        public MedeaPos PosManager;
        public GameObject dcObj;

        int stage = 0;
        private void Awake()
        {
            _Instance = this;
            sp = this.GetComponent<SpriteRenderer>();
            aniCon = this.GetComponent<Animator>();
            collider = this.GetComponent<Collider2D>();
        }

        // Use this for initialization
        void Start()
        {
            Hide();
            if (ResourceManager._Instance.medeaStageInFX != null) 
                Instantiate(ResourceManager._Instance.medeaStageInFX).transform.position = this.transform.position;
            Instantiate(poses);

            
            BossPanel._Instance.hpMax = Hp;
            BossPanel._Instance.ChangeBossPanelState(true);

            StartCoroutine(Fighting());

            SoundManager._Instance.PlayBGM(ResourceManager._Instance.BossBgm1);
        }

        // Update is called once per frame
        void Update()
        {
            ResetSelfFace();
            BossPanel._Instance.BossHp = Hp;
            BossPanel._Instance.ChangeSkillProgress(castProgress);
        }

        /// <summary>
        /// 校正Medea的面部朝向
        /// </summary>
        void ResetSelfFace()
        {
            float selfX = this.transform.position.x;
            if (selfX > 0 && !sp.flipX)
                sp.flipX = true;
            else if(selfX<=0 && sp.flipX)
            {
                sp.flipX = false;
            }
        }

        void ChangeState(MedeaState nextState)
        {
            if (this.State == nextState)
                return;
            this.state = nextState;
            switch (nextState)
            {
                case MedeaState.Idle:
                    aniCon.SetTrigger("Idle");
                    break;
                case MedeaState.Angry:
                    aniCon.SetTrigger("Angry");
                    break;
                case MedeaState.Embarrassed:
                    aniCon.SetTrigger("Embarrassed");
                    break;
                case MedeaState.Fly:
                    aniCon.SetTrigger("Fly");
                    break;
                case MedeaState.Laugh:
                    aniCon.SetTrigger("Laugh");
                    break;
                case MedeaState.Roar:
                    aniCon.SetTrigger("Roar");
                    break;
                default:
                    break;
            }
        }

        public void Show()
        {
            sp.enabled = true;
            collider.enabled = true;
            BossPanel._Instance.ChangeBossPanelState(true);
        }

        public void Hide()
        {
            sp.enabled = false;
            collider.enabled = false;
            BossPanel._Instance.ChangeBossPanelState(false);
        }

        public void LoadSkill(BossSkill skill)
        {
            
        }

        IEnumerator Fighting()
        {
            yield return new WaitForSeconds(5f);
            MoveTo(PosManager.GetTopMiddlePosition(), 1f);
            
            int count = 5;
            int tempCount = 1;
            while (count-- > 0)
            {
                ExplodeBullets expBullet = ExplodeBulletsManager._Instance.GenerateExplodeBullet(1);
                expBullet.selfExtendSpeed = 2;
                expBullet.transform.position = PosManager.GetCurrentPosition();
                expBullet.transform.localEulerAngles = new Vector3(0, 0, tempCount++ * 5);
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(1f);
            //开始读条第一技能，3s
            ChangeState(MedeaState.Laugh);
            UIManager._Instance.bossPanel.ChangeSkillName("Magic Hole");
            UIManager._Instance.bossPanel.SkillProgressFillInTime(2.5f);

            yield return new WaitForSeconds(2.5f);
            ChangeState(MedeaState.Idle);
            BlackBallManager._Instance.GenerateBlackBall(PosManager.GetCurrentPosition()).MoveToMiddlePosition();

            yield return new WaitForSeconds(2);
            ChangeState(MedeaState.Fly);
            MoveTo(PosManager.GetLeftTopPos(),3);
            //拖延3秒
            float tempCountF = 0;
            while (tempCountF < 3f)
            {
                tempCountF += 0.25f;
                IceArrowManager._Instance.GenerateIce(1, 0.25f);
                yield return new WaitForSeconds(0.25f);
            }
            ChangeState(MedeaState.Fly);
            MoveTo(PosManager.GetRightTopPos(), 4);
            //拖延4秒
            tempCountF = 0;
            while (tempCountF < 4f)
            {
                tempCountF += 0.3f;
                TriBulletsManager._Instance.LaunchTriBullet(PosManager.GetCurrentPosition(), 10);
                yield return new WaitForSeconds(0.3f);
            }

            ChangeState(MedeaState.Fly);
            MoveTo(PosManager.GetLeftTopPos(), 5);
            //拖延4秒
            tempCountF = 0;
            while (tempCountF < 5f)
            {
                tempCountF += 0.25f;
                TriBulletsManager._Instance.LaunchTriBullet(PosManager.GetCurrentPosition(), 10);
                yield return new WaitForSeconds(0.25f);
            }

            ChangeState(MedeaState.Fly);
            MoveTo(PosManager.GetRightTopPos(), 3);
            //拖延4秒
            tempCountF = 0;
            while (tempCountF < 3f)
            {
                tempCountF += 0.2f;
                TriBulletsManager._Instance.LaunchTriBullet(PosManager.GetCurrentPosition(), 15);
                yield return new WaitForSeconds(0.2f);
            }

            UIManager._Instance.bossPanel.ChangeSkillName("Magic Arrow");
            UIManager._Instance.bossPanel.SkillProgressFillInTime(1f);
            yield return new WaitForSeconds(1f);

            ChangeState(MedeaState.Laugh);
            //拖延4秒,直接射击
            tempCountF = 0;
            while (tempCountF < 7f)
            {
                tempCountF += 0.2f;
                BulletLauncher._Instance.LaunchBullet(PosManager.GetCurrentPosition()).DelayLaunch(0,true);
                yield return new WaitForSeconds(0.2f);
            }

            MoveTo(PosManager.GetLeftTopPos(), 2);
            yield return new WaitForSeconds(2f);

            tempCountF = 0;
            while (tempCountF < 8f)
            {
                tempCountF += 0.05f;
                BulletLauncher._Instance.LaunchBullet(PosManager.GetCurrentPosition()).SetTarget(Player.Player._Instance.transform.position
                    + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), -1));

                yield return new WaitForSeconds(0.05f);
            }

            MoveTo(PosManager.GetTopCenterPos(), 1);
            yield return new WaitForSeconds(1f);

            tempCountF = 0;
            while (tempCountF < 7f)
            {
                tempCountF += 0.1f;
                int randomIndex = Random.Range(0, DelayBulletManager._Instance.bulletPrefabs.Length);
                GameObject tempObj = Instantiate(DelayBulletManager._Instance.bulletPrefabs[randomIndex]);
                tempObj.transform.position = PosManager.GetCurrentPosition();
                Vector3 aroundPos = PosManager.GetAroundPosition(1);
                tempObj.transform.DOMove(aroundPos, 0.05f);
                yield return new WaitForSeconds(0.05f);

                EnemyBullet tempBullet = tempObj.GetComponent<EnemyBullet>();
                if (Player.Player._Instance != null)
                {
                    tempBullet.SetTarget(Player.Player._Instance.transform.position + new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), 0));
                }
                else
                {
                    tempBullet.SetTarget(Vector3.down);
                }
                
                tempBullet.DelayLaunch(1);

                yield return new WaitForSeconds(0.05f);
            }

            ChangeState(MedeaState.Laugh);
            tempCount = 0;
            while (tempCount < 9)
            {
                yield return new WaitForSeconds(1);
                tempCount += 1;

                Vector3 tempPos = PosManager.GetCenterArea(2);
                MagicCircleManager._Instance.GenerateMagicCircle(tempPos, () => 
                {
                    int randomIndex = Random.Range(1, 4);
                    ExplodeBullets bullet = ExplodeBulletsManager._Instance.GenerateExplodeBullet(randomIndex);
                    bullet.transform.position = tempPos;
                    bullet.selfExtendSpeed = Mathf.Abs(Mathf.Sin(Time.time) + 1.5f);
                    bullet.selfRotateSpeed = 10 * Mathf.Sin(Time.time);
                });
            }
            ChangeState(MedeaState.Idle);

            yield return new WaitForSeconds(3);

            //开新对话，持续10秒
            ChangeState(MedeaState.Angry);

            UIManager._Instance.dialogPanel.ShowDialog(DialogType.LeftDialog, "c010", "Not bad ,but you need to try harder.");
            yield return new WaitForSeconds(7);
            UIManager._Instance.dialogPanel.HideDialog(DialogType.LeftDialog);
            ChangeState(MedeaState.Roar);
            UIManager._Instance.bossPanel.ChangeSkillName("Summon Angel");
            UIManager._Instance.bossPanel.SkillProgressFillInTime(9f);

            //拖延8秒
            tempCountF = 0;
            while (tempCountF < 8f)
            {
                tempCountF += 0.25f;
                IceArrowManager._Instance.GenerateIce(2, 0.25f);
                yield return new WaitForSeconds(0.25f);
            }

            yield return new WaitForSeconds(1);

            ChangeState(MedeaState.Embarrassed);
            AngelManager._Instance.GenerateLeftAngel();
            AngelManager._Instance.GenerateRightAngel();
            dcObj.SetActive(true);

        }
        public void MoveTo(Vector2 pos,float duration)
        {
            ChangeState(MedeaState.Fly);
            this.transform.DOMove(pos, duration).OnComplete(()=>ChangeState(MedeaState.Idle)).SetEase(Ease.Linear);
        }        
    }


    public enum MedeaState
    {
        Idle,
        Angry,
        Embarrassed,
        Fly,
        Laugh,
        Roar
    }
}
