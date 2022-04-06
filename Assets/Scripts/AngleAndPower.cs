using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAndPower : MonoBehaviour
{
    public static AngleAndPower angleAndPowerInstance;
    private void Awake()
    {
        angleAndPowerInstance = this;
    }
    private bool AnglePicked;
    private bool PowerPicked;
    private float AngleValue;
    private float PowerValue;
    private void Start()
    {
        AngleValue = 0;
        PowerValue = 0;
    }
    private void Update()
    {
        if(AnglePicked == true && PowerPicked == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            PenguinScript.penguinScript.hitPenguin(AngleValue, PowerValue);
        }
        if(AnglePicked != true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            AngleValue = Angle.angleInstance.zRot;
            Angle.angleInstance.RotSpeed = 0;
            AnglePicked = true;
        }
        if(AnglePicked == true && PowerPicked != true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            PowerValue = Power._powerInstance.HitPower;
            PowerPicked = true;
        }
    }
}
