using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    [SerializeField]
    AudioSource SnakeSound;
    [SerializeField]
    AudioClip SnakeFirstClip;
    [SerializeField]
    AudioClip SnakeSecondClip;
   
    AudioClip[] SnakeClips;
    [SerializeField]
    float snakePower;
    private void Start()
    {
        SnakeClips = new AudioClip[] { SnakeFirstClip, SnakeSecondClip };
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            PlayRandomSnakeSound();
        }
    }
    public void HitSnake()
    {
        PenguinScript.penguinScript.rotSet = false;
        PenguinScript.penguinScript.Grounded = false;
        PenguinScript.penguinScript.rb.velocity = new Vector2(PenguinScript.penguinScript.rb.velocity.x, 0f);
        PenguinScript.penguinScript.rb.AddForce(Vector2.up * snakePower, ForceMode2D.Impulse);
        PlayRandomSnakeSound();
    }
    private void PlayRandomSnakeSound()
    {
        SnakeSound.clip = SnakeClips[(Random.Range(0, SnakeClips.Length))];
        SnakeSound.Play();
      
    }
}
