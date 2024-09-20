using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TalkPanel : BasePanel {

   //

   //ϸ�����
    public RectTransform diaEndPoisition;
    public float scaleStart = 0.8f;
    public float speed;
    public int txtTime;
    public bool isOpenDia;
    //��ť��
    public GameObject a;
    public GameObject b;
    public GameObject c;
    //�Ի�
    public TextMeshProUGUI content;
    public TextMeshProUGUI _name;

    public string talkStr;
    //����ťλ�ô���Talkmanger
    public event Action<ButtonObject> OnGetButtonObject;
    public  ButtonObject buttonobject = new ButtonObject ();

    public GameObject dialogue;
    public bool isTextOver;
    private void Awake()
    {
        GameEventManager.MainInstance.AddEventListening("OnGetButtonObject", OnGetButtonObject);
        buttonobject.a = a;
        buttonobject.b = b;   
        buttonobject.c = c;
        buttonobject.father = this.gameObject;
    }


    public void Show(BaseNode node,int idex)
    {

        switch (node.nodeType){
        
           case NodeType.DialogueNode:
                //��ֹ�ظ���
                if(!isOpenDia)
                OpenDialouge();
                    DialogueNode dialogueNode = node as DialogueNode;
                //_name.text = dialogueNode._name;
                talkStr = dialogueNode._name+"��"+dialogueNode.content[idex];
                SlowShowText();
                return;
            case NodeType.EndTaskDiscribe:
                if(!isOpenDia)
                OpenDialouge();
                EndTaskDiscribeNode endNode = node as EndTaskDiscribeNode;
                //_name.text = endNode._name;
                talkStr = endNode._name+"��"+ endNode.content[idex];
                SlowShowText();
                return;
            case NodeType.Select:

                GameEventManager.MainInstance.CallEvent("OnGetButtonObject", buttonobject);
               //dialogue.SetActive(false);
                return;
                
                
            }


    }

    public void ShowText()
    {
        content.text = talkStr;
        isTextOver = true;
    }
    public async void SlowShowText()
    {
        isTextOver =  false;
        string temp = "";
        foreach(char str in talkStr)
        {
            if (isTextOver)
            {
                break;
            }
            temp += str;
            content.text = temp;
            await UniTask.Delay(txtTime);
            if (isTextOver)
            {
                break;
            }
            Debug.Log("�ȴ�����");
        }
        isTextOver = true;
    }
    public void OpenDialouge()
    { 
        
        dialogue.SetActive(true);
        RectTransform dai = dialogue.GetComponent<RectTransform>();
        dai.localScale = new Vector3 (scaleStart, scaleStart, 1);
        //dai.DOMoveY(diaEndPoisition.position.y, speed);
        dai.DOScale(1, speed);
        isOpenDia = true;

    }
 
    public void CloseDialouge()
    {
        
    }
}
public class ButtonObject {
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject father;
}
