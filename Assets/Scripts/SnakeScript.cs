using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    [SerializeField]
    float snakePower;
    public void HitSnake()
    {
        PenguinScript.penguinScript.rotSet = false;
        PenguinScript.penguinScript.Grounded = false;
        PenguinScript.penguinScript.rb.velocity = new Vector2(PenguinScript.penguinScript.rb.velocity.x, 0f);
        PenguinScript.penguinScript.rb.AddForce(Vector2.up * snakePower, ForceMode2D.Impulse);
    }
}
