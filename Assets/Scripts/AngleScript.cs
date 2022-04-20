using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleScript : MonoBehaviour
{
    public static AngleScript angleInstance;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float RotSpeed;

    public bool ToRotate;
    public Transform arrowTransform;
    public float power;
    public float zRot;
    public float rotVal;

    public string hello = "hello";

    private void Awake()
    {
        ToRotate = true;
        spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();

        rotVal = -1f;
        arrowTransform = gameObject.transform;
    }
    private void Start()
    {
        angleInstance = this;
        
    }
    private void FixedUpdate()
    {
        if (ToRotate != false)
        {
            zRot = arrowTransform.rotation.eulerAngles.z;
            if (zRot >= 90f)
            { rotVal = -1f; }
            else if (zRot <= 1)
            { rotVal = 1f; }
            arrowTransform.Rotate(new Vector3(0f, 0f, RotSpeed) * rotVal * Time.deltaTime);
        }

    }
    public void StopRot()
    {
        print("stop");
        ToRotate = false;
    }
    public void SetNotVisible()
    {
        spriteRenderer.enabled = false;
        ToRotate = false;

    }
    public void SetVisible()
    {

        spriteRenderer.enabled = true;
        ToRotate = true;

    }
}
