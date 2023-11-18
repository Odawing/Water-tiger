using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerClawAbility : DirectionalAbility
{
    public float pushForce;

    public GameObject tigerClawPref;

    public override void OnAbilityUse()
    {
        if (curCooldown != 0) return;
        base.OnAbilityUse();

        var clawObj = Instantiate(tigerClawPref, (Vector2)joystickController.transform.position, Quaternion.identity);
        var claw = clawObj.GetComponent<Claw>();
        claw.Init(-direction * pushForce, GameManagerScr.Instance.tigerPlayer.isBuffedClaw);
    }
}