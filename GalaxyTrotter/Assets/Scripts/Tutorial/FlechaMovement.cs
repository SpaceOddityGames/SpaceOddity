using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMovement : MonoBehaviour
{
    private bool yas = false;
    void Update()
    {
        print(transform.localPosition);
        Vector3 newpos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y -10 , this.transform.localPosition.z);
        transform.localPosition = Vector3.Lerp(transform.localPosition, newpos, 1);
        newpos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y +10, this.transform.localPosition.z);
        transform.localPosition = Vector3.Lerp(transform.localPosition, newpos, 1);
    }
}
