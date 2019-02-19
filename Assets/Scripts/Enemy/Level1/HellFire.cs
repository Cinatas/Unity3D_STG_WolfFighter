using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using WolfFighter.Player;

public class HellFire : EnemyBullet {

    float save = 0;
    
    protected override void Hit(LivingObject lo)
    {
        lo.Hurt(this.BulletDamage);
        //还需要生成hit特效
        if (hitFX != null)
            Instantiate(hitFX).transform.position = this.transform.position;
        lo.SetSpeed(0.05f, 3);
        //并销毁自身
        Destroy(this.gameObject);
    }    

}
