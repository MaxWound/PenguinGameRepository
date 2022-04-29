using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAndPower : MonoBehaviour
{
    [SerializeField]
    AudioSource ReadySound;
    [SerializeField]
    AudioSource WhistleSound;

    
    public static AngleAndPower angleAndPowerInstance;
    private void Awake()
    {
        
    }
    private bool AnglePicked;
    private bool PowerPicked;
    private float AngleValue;
    private float PowerValue;
    private bool isClickable;
    private void Start()
    {
        angleAndPowerInstance = this;
        isClickable = true;
        AngleValue = 0;
        PowerValue = 0;
        SetAngleAndPowerVisible();
    }
    private void Update()
    {

        if (AnglePicked != true && Input.GetKeyDown(KeyCode.Mouse0) && isClickable == true)
        {
            
            AngleValue = AngleScript.angleInstance.zRot;
            AnglePicked = true;
            SetNotRot();
            
        }
       
        else
        if (AnglePicked == true && PowerPicked != true && Input.GetKeyDown(KeyCode.Mouse0) && isClickable == true && GameManager.gameManager.TriesCount != 0)
        {
            PowerValue = Power._powerInstance.StopPower();
            
            PenguinScript.penguinScript.hitPenguin(AngleValue, PowerValue, true);
            GameManager.gameManager.MinusTry();
            AngleValue = 0;
            PowerValue = 0;
            PowerPicked = false;
            AnglePicked = false;
            SetAngleAndPowerNotVisible();
            
        }
        else if(GameManager.gameManager.TriesCount == 0)
        {
            print("GAME OVER");
        }

        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            SetNotRot();
        }
       

    }
    public void SetNotRot()
    {
        AngleScript.angleInstance.StopRot();
    }
   public void SetAngleAndPowerNotVisible()
    {
        Power._powerInstance.SetNotVisible();
        AngleScript.angleInstance.SetNotVisible();
        isClickable = false;
        PenguinScript.penguinScript.AaPVisible = false;
    }
    public void SetAngleAndPowerVisible()
    {
        //WhistleSound.Play();
        ReadySound.Play();
        Power._powerInstance.SetVisible();
        AngleScript.angleInstance.SetVisible();
        isClickable = true;
    }
    
}
