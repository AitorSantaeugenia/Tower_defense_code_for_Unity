using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerIncome : MonoBehaviour {

    public Text incomeText;
	
	// Update is called once per frame
	void Update () {
        incomeText.text = "$"+Jugador.gold.ToString();
	}
}
