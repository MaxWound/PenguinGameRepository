using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeScript : MonoBehaviour
{
    [SerializeField]
    float throwPower;
    [SerializeField]
    float throwAngle;
    [SerializeField]
    float waitSec;
    [SerializeField]
    Transform spawner;
    Vector2 spawnerPos;
    private void Start()
    {
        spawnerPos = spawner.position;
    }
    public void SpawnAndThrow()
    {
        print("hi");
        PenguinScript.penguinScript.rb.position = spawnerPos;
        StartCoroutine(WaitAndThrow());
        
    }
    IEnumerator WaitAndThrow()
    {
        PenguinScript.penguinScript.inSimulation = true;
        PenguinScript.penguinScript.rb.velocity = new Vector2(0f, 0f);
        PenguinScript.penguinScript.rb.isKinematic = true;
        PenguinScript.penguinScript.SetVisible(false);
        yield return new WaitForSeconds(waitSec);
        PenguinScript.penguinScript.SetVisible(true);
        PenguinScript.penguinScript.rb.isKinematic = false;
        PenguinScript.penguinScript.hitPenguin(throwAngle,throwPower);
        PenguinScript.penguinScript.inSimulation = false;
    }
}
