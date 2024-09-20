using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostTentacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rycle()
    {
        this.gameObject.SetActive(false);
        PoolManger.Instance.Recycle("Rem7Tent",this.gameObject);
    }
}
