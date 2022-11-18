using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private float frameRate;
    private float actualTime;
    // Update is called once per frame
    private void Start()
    {
        frameRate = 0;
        actualTime = 0;
    }
    void Update()
    {
        frameRate = Time.deltaTime * 1;
        actualTime += frameRate;
        this.transform.rotation = Quaternion.Euler(0,0,actualTime*200);
    }
}
