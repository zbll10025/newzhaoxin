using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStar : MonoBehaviour
{
    private void Awake()
    {
        BaseUIManager.MainInstance.OpenPanel(UIConst.MainMenuPanel);
    }
}
