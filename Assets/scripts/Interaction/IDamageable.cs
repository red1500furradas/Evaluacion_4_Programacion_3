using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void RecibirDanio(float cantidad)
    {
        Debug.Log("recibi daño emocional");
    }
}
