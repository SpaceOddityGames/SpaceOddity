using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletAnim : MonoBehaviour
{
    public void apagar()
    {
        this.GetComponentInParent<TabletManager>().deactivateTablet();
    }
}
