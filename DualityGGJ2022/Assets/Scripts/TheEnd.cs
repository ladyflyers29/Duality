using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public GameObject wire1;
    public GameObject wire2;
    public GameObject wire3;
    public GameObject wire4;

    public GameObject EndBlock;

    // Update is called once per frame
    void Update()
    {
        if (wire1.activeSelf == true && wire2.activeSelf == true && wire3.activeSelf == true && wire4.activeSelf == true)
        {
            EndBlock.SetActive(true);
        }
    }
}
