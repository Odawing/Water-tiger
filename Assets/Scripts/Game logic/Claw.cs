using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    private bool isBuffed = false;

    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Collider2D coll;
    [SerializeField]
    private SpriteRenderer clawSprite;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private Material buffedParticleMat;

    public void Init(Vector2 forward, bool isBuff)
    {
        transform.up = forward;
        body.AddForce(forward);

        isBuffed = isBuff;

        if (isBuffed)
        {
            particle.GetComponent<Renderer>().material = buffedParticleMat;
        }

        Destroy(gameObject, 5F);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collidedShellfish = collision.collider.GetComponentInParent<ShellFish>();
        if (collidedShellfish != null)
        {
            Destroy(collision.gameObject);

            if (isBuffed) collidedShellfish.DestroyShellfish();
            else collidedShellfish.OnHitByClaw();
        }

        StopClaw();
    }

    private void StopClaw()
    {
        clawSprite.enabled = false;
        coll.enabled = false;
        body.isKinematic = true;
        particle.Stop();
    }
}