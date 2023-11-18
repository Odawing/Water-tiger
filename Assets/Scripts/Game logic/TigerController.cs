using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D body;

    public LayerMask touchInputlayer;

    private Vector2 firstPressPos, secondPressPos, currentSwipe;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void OnTouchDown()
    {
        firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public void OnTouchUp()
    {
        secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
        currentSwipe.Normalize();

        body.velocity = speed * Time.deltaTime * currentSwipe;
    }
}