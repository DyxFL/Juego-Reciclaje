using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class timer : MonoBehaviour
{
    public event EventHandler MuerteJugador;
   public float WaitSec;
   private int WaitSecInt;
   public Text text;
   private void FixedUpdate() {
    if(WaitSec>0){
        WaitSec-=Time.fixedDeltaTime;
        WaitSecInt=(int)WaitSec;
        text.text=WaitSecInt.ToString();
    }else{
        MuerteJugador?.Invoke(this,EventArgs.Empty);
    }

   }
}
