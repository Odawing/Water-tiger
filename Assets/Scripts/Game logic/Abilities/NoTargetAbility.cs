using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoTargetAbility : Ability
{
    [SerializeField]
    private Image abilityIcon;

    public override void OnAbilityUse()
    {
        curCooldown = abilityCooldown;
    }

    private void Update()
    {
        abilityIcon.fillAmount = 1 - (1 * curCooldown / abilityCooldown);

        if (abilityIcon.fillAmount <= 0)
        {
            abilityIcon.fillAmount = 0;
        }
    }
}