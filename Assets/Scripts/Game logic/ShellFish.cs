using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFish : MonoBehaviour
{
    private int health;

    public float radius;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject pointToDestroyPref;

    private void Start()
    {
        int rand = Random.Range(1, 4);
        for (int i = 0; i < rand; i++)
        {
            var point = Instantiate(pointToDestroyPref, (Vector2)transform.position + Random.insideUnitCircle * radius, Quaternion.identity);
            point.transform.SetParent(transform);
            health++;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(-transform.up * Time.deltaTime * 0.5F);
    }

    public void OnHitByClaw()
    {
        health--;
        animator.Play("Hit");
        if (health == 0)
        {
            DestroyShellfish();
        }
    }

    public void DestroyShellfish()
    {
        GameManagerScr.Instance.CollectShellFish();

        animator.Play("Destroy");

        Destroy(gameObject, 1F);
    }
}