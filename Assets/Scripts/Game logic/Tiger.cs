using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : MonoBehaviour
{
    public bool isBuffedClaw;
    public bool isUnderShield;

    [SerializeField]
    private SpriteRenderer shieldSprite;

    private void Update()
    {
        shieldSprite.enabled = isUnderShield;
    }

    public void OnSharkHit()
    {
        if (!isUnderShield)
        {
            GameManagerScr.Instance.LoseGame();
        }
    }
}