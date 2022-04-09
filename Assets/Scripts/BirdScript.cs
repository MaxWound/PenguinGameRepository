using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
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
        rb = gameObject.GetComponent<Rigidbody2D>();
        pengRb = PenguinScript.penguinScript.rb;
        
    }
    private void Update()
    {
        rb.position += new Vector2(-1f, 0f) * Speed * Time.deltaTime;
    }
    public void HoldAndThrow()
    {
        StartCoroutine(IHoldAndThrow());
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
        pengRb.isKinematic = false;
        PenguinScript.penguinScript.hitPenguin(throwAngle, throwPower);
        PenguinScript.penguinScript.inSimulation = false;

    }
}
