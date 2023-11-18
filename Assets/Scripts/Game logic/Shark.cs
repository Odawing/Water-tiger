using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public float attackInterval;
    public float attackPrepareTime;
    public float sharkSpeed;

    private Vector3 startingPos;
    private Vector2 destinationPos;

    private float lastAttackTime;
    private bool canAttack = true;

    [SerializeField]
    private Rigidbody2D sharkBody;
    [SerializeField]
    private SpriteRenderer sharkSprite;
    [SerializeField]
    private ParticleSystem sharkEffect;
    [SerializeField]
    private LineRenderer attackPathLine;

    private void Start()
    {
        startingPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > lastAttackTime + attackInterval && canAttack)
        {
            canAttack = false;
            lastAttackTime = Time.timeSinceLevelLoad;
            StartCoroutine(AttackCour());
        }
    }

    private void Update()
    {
        if (!canAttack && Vector2.Distance((Vector2)transform.position, destinationPos) <= 0.5F)
        {
            destinationPos = Vector2.zero;
            EndAttack();
        }
    }

    private IEnumerator AttackCour()
    {
        Vector2 direction = (GameManagerScr.Instance.tigerPlayer.transform.position - transform.position).normalized;
        transform.right = -direction;

        attackPathLine.SetPosition(0, new Vector3(transform.position.x, transform.position.y, attackPathLine.GetPosition(0).z));
        var newPos = (Vector2)transform.position + direction * 15;
        attackPathLine.SetPosition(1, new Vector3(newPos.x, newPos.y, attackPathLine.GetPosition(1).z));
        attackPathLine.enabled = true;

        yield return new WaitForSeconds(attackPrepareTime);

        destinationPos = newPos;
        sharkBody.velocity = direction * sharkSpeed;
        sharkEffect.gameObject.SetActive(true);
    }

    private void EndAttack()
    {
        sharkBody.velocity = Vector2.zero;
        attackPathLine.enabled = false;
        sharkEffect.gameObject.SetActive(false);

        // Set shark on next starting pos
        if (Random.Range(0, 2) == 0)
        {
            transform.position = new Vector2(startingPos.x, Random.Range(-5, 5));
            sharkSprite.flipY = false;
        }
        else
        {
            transform.position = new Vector2(-5, Random.Range(-5, 5));
            sharkSprite.flipY = true;
        }

        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Tiger>(out var player))
        {
            player.OnSharkHit();
        }
    }
}