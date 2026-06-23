using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class Luchador : PlayerBase
    {
        public override void AtaqueEspecial()
        {
            Debug.Log("Golpe poderoso");
        }
    }
}