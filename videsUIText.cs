using UnityEngine;
using UnityEngine.UI;

public class videsUIText : MonoBehaviour {

    public Text liveText;
	
	// Update is called once per frame
	void Update () {
        liveText.text = Jugador.lives.ToString();
		
	}
}
