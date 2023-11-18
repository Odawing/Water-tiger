using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float abilityCooldown;
    protected float curCooldown;

    public abstract void OnAbilityUse();

    private void FixedUpdate()
    {
        if (curCooldown > 0)
        {
            curCooldown -= Time.deltaTime;
        }
        else
        {
            curCooldown = 0;
        }
    }
}