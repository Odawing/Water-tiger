using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : NoTargetAbility
{
    public float buffDuration;

    public override void OnAbilityUse()
    {
        if (curCooldown != 0) return;
        base.OnAbilityUse();

        GameManagerScr.Instance.tigerPlayer.isUnderShield = true;

        StartCoroutine(BuffDuration());
    }

    private IEnumerator BuffDuration()
    {
        yield return new WaitForSeconds(buffDuration);

        GameManagerScr.Instance.tigerPlayer.isUnderShield = false;
    }
}
