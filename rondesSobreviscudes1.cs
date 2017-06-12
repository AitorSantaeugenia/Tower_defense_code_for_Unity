using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rondesSobreviscudes1 : MonoBehaviour {

    public Text roundsSurvivedText;

    void OnEnable()
    {
        roundsSurvivedText.text = Jugador.RoundSurvived.ToString();

    }
}
