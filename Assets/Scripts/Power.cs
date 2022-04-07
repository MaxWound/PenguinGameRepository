using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    private SpriteRenderer[] spriteRenderer;
    [SerializeField]
    float PowerMultiplier;
    public static Power _powerInstance;
    private float FixedMoveSpeed;
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
        spriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();
        HitPower = 0;
        moveVal = -1;
        _powerInstance = this;
        

}
    private void Start()
    {
        xPos = cursorTransform.transform.localPosition.x;
        HighPos = HighTransform.transform.localPosition.y;
        LowPos = LowTransform.transform.localPosition.y;
        FixedMoveSpeed = MoveSpeed;
    }
    private void Update()
    {

        float yPos = cursorTransform.transform.localPosition.y;
        HitPower = (yPos - LowPos) * PowerMultiplier;
        cursorTransform.transform.localPosition = new Vector3(xPos, yPos + (moveVal * MoveSpeed * Time.deltaTime), 0f);
        if (yPos <= LowPos)
        {
            moveVal = 1;
        }
        if (yPos >= HighPos)
        {
            moveVal = -1;
        }



    }
    public float StopPower()
    {
        MoveSpeed = 0;
        return HitPower;
    }
    public void SetNotVisible()
    {
       for(int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].enabled = false;
        }
    }
    public void SetVisible()
    {
        MoveSpeed = FixedMoveSpeed;
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].enabled = true;
        }
    }

}
