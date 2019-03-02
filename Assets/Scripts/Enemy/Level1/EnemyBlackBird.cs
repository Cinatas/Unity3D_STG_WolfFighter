using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using WolfFighter.Player;

public class EnemyBlackBird : Enemy {

    public Direction dir;

    bool isEnable = true;
    public float moveSpeed = 1;
    Animator aniCon;
    public float DropTime;
    public GameObject dropBullet;
    
    protected override void Awake()
    {
        base.Awake();
        aniCon = this.GetComponent<Animator>();
    }

    protected override void Start()
    {
        base.Start();

        if(dir == Direction.Left)
        {
            aniCon.SetTrigger("Left");
        }else if(dir == Direction.Right)
        {
            aniCon.SetTrigger("Right");
        }
        StartDrop();
    }

    private void FixedUpdate()
    {
        if (!isEnable)
            return;
        int dirFix = (dir == Direction.Left) ? 1 : -1;
        this.transform.Translate(Vector2.left * dirFix * Time.deltaTime * moveSpeed);
    }


    public enum Direction
    {
        Left,
        Right
    }

    IEnumerator DropBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(DropTime);

            if (!isEnable)
                continue;

            GameObject bulletObj = Instantiate(dropBullet);
            bulletObj.transform.position = this.transform.position;

            EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet>();
            bullet.MoveSpeed = 5;            
            bullet.DelayLaunch(1,true);
            bullet.BulletDamage = 10;
        }
    }

    IEnumerator Shutdown(float time)
    {
        yield return new WaitForSeconds(time);
        isEnable = false;
    }

    public void StartDrop()
    {
        StartCoroutine(DropBullet());
        StartCoroutine(Shutdown(6));
        Destroy(this.gameObject, 7);
    }

}
