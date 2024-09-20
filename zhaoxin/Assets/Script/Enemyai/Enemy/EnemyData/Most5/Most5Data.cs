using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most5Data : LandMost
{
    public Most5PlayerCheck most1PlayerCheck;
    public ApproachCheck approachCheck;
    public bool isEscape;
    protected override void Awake()
    {
        base.Awake();
        most1PlayerCheck = transform.Find("PlayerCheck").gameObject.GetComponent<Most5PlayerCheck>();
        approachCheck = transform.Find("ApproachCheck").gameObject.GetComponent<ApproachCheck>();
    }
}
