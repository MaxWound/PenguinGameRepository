using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    float VerticalSpeed;
    bool isLow;
    bool toUp;
    float posToMoveY;
    [SerializeField]
    Transform posToMoveTransform; 
    [SerializeField]
    float throwAngle;
    [SerializeField]
    float throwPower;
    [SerializeField]
    Transform HolderTransform;
    [SerializeField]
    float Speed;
    [SerializeField]
    float HoldTime;
    Rigidbody2D rb;
    Rigidbody2D pengRb;
    private void Start()
    {
        toUp = false;
        isLow = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        pengRb = PenguinScript.penguinScript.rb;
        posToMoveY = posToMoveTransform.position.y;
        HoldAndThrow();
        
    }
    private void Update()
    {
        rb.position += new Vector2(-1f, 0f) * Speed * Time.deltaTime;
        if (isLow == false)
        
        {
            if (rb.position.y >= posToMoveY)
            {
                print($"{posToMoveY} and  {rb.position.y}");
                rb.position += new Vector2(0f, -1f) * VerticalSpeed * Time.deltaTime;
            }
            else
            { 
                isLow = true; 
            
            }
        }
        else if(isLow == true && toUp == true)
        {
            rb.position += new Vector2(0f, 1f) * VerticalSpeed * Time.deltaTime;
        }
    }
    public void HoldAndThrow()
    {
        StartCoroutine(IHoldAndThrow());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sky" && toUp == true)
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator IHoldAndThrow()
    {
        PenguinScript.penguinScript.inSimulation = true;
        
        PenguinScript.penguinScript.transform.position = HolderTransform.position;
        
        PenguinScript.penguinScript.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        PenguinScript.penguinScript.transform.parent = HolderTransform;
        pengRb.velocity = new Vector2(0f, 0f);
        pengRb.isKinematic = true;
        yield return new WaitForSeconds(HoldTime);
        PenguinScript.penguinScript.transform.parent = null;
        toUp = true;
        pengRb.isKinematic = false;
        PenguinScript.penguinScript.hitPenguin(throwAngle, throwPower,false);
        PenguinScript.penguinScript.inSimulation = false;

    }
}
