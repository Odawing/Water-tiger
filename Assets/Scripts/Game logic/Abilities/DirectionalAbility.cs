using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalAbility : Ability
{
    public Joystick joystickController;
    public LineRenderer directionLine;
    protected Vector3 direction;

    private void Update()
    {
        joystickController.enabled = curCooldown == 0;

        if (joystickController.Direction.magnitude > 0.1F)
        {
            OnChooseDirection();
        }
    }

    public virtual void OnChooseDirection()
    {
        if (curCooldown != 0) return;
        directionLine.enabled = true;

        var originPos = joystickController.transform.GetChild(0).transform.position;
        directionLine.SetPosition(0, new Vector3(originPos.x, originPos.y, directionLine.GetPosition(0).z));

        var endPos = -joystickController.Direction.normalized * 10;
        directionLine.SetPosition(1, new Vector3(endPos.x, endPos.y, directionLine.GetPosition(1).z));
    }

    public override void OnAbilityUse()
    {
        if (curCooldown != 0) return;
        directionLine.enabled = false;

        direction = (Vector2)(directionLine.GetPosition(0) - directionLine.GetPosition(1)).normalized;
        curCooldown = abilityCooldown;
    }
}