using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Base
{
    public interface IAttack
    {
        BulletBase BulletType { get; set; }

        void Fire();
        void Ability();
       
    }

}
