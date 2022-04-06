using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    [SerializeField]
    float PowerMultiplier;
    public static Power _powerInstance;
    [SerializeField]
    float MoveSpeed;
    [SerializeField]
    GameObject cursorTransform;
    [SerializeField]
    GameObject HighTransform;
    [SerializeField]
    GameObject LowTransform;
    float HighPos;
    float LowPos;
    public float HitPower;
    float xPos;
    float moveVal;
    private void Awake()
    {
        HitPower = 0;
        moveVal = -1;
        _powerInstance = this;

    }
    private void Start()
    {
        xPos = cursorTransform.transform.position.x;
        HighPos = HighTransform.transform.position.y;
        LowPos = LowTransform.transform.position.y;
    }
    private void Update()
    {
        
        float yPos = cursorTransform.transform.position.y;
        cursorTransform.transform.position = new Vector3(xPos, yPos + (moveVal * MoveSpeed * Time.deltaTime), 0f);
        if (yPos <= LowPos)
        {
            moveVal = 1;
        }
        if (yPos >= HighPos)
        {
            moveVal = -1;
        }
        HitPower = Vector2.Distance(new Vector2(0f, LowPos), new Vector2(0f, yPos)) * PowerMultiplier;
        
       
    }

}
