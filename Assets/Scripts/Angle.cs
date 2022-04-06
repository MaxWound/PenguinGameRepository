using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : MonoBehaviour
{
    
    [SerializeField]
   public float RotSpeed;
   public Transform arrowTransform;
    public float power;
    public float zRot;
    public float rotVal;
    public static Angle angleInstance = null;
    public string hello = "hello";
    
    private void Awake()
    {
        
        angleInstance = this;
        rotVal = -1f;
        arrowTransform = gameObject.transform;
    }
    private void Update()
    {
        
        zRot = arrowTransform.rotation.eulerAngles.z;
        if (zRot >= 90f)
        { rotVal = -1f; }
        else if (zRot <= 1)
        { rotVal = 1f; }
        arrowTransform.Rotate(new Vector3(0f, 0f, RotSpeed) * rotVal * Time.deltaTime);
        
        
    }

}
