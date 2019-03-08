using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableTextAfterSeconds : MonoBehaviour
{
public Text Text1;
public int timer;
   void Start () 
   {
      Invoke("DisableText", timer);
   }
   void DisableText()
   { 
      Text1.enabled = false; 
   }    
}
