using UnityEngine;
using UnityEngine.EventSystems;
/* 
## 1- Dona falla si clicam un node sense torre, te que tenir que veure amb el pass de la construcció de la torre de nodo.cs a ScriptConstruirTorres.cs


*/


/* ON ANIRAN LES TORRES, AMB UN OBJECTIU PER SER COL·LOCATS*/

public class nodo : MonoBehaviour {

    public Color hoverColor;

    private Renderer renderPerC;
    public Vector3 positionOffset;

    /* HOVER COLORS segons el or del jugador*/
    //Verd si te gold
    private Color colorInicial;
    //Vermell si no te gold
    public Color notGold;

    [Header("Torre - Carga default")]
    //No hi ha torre?
    public GameObject torre;

    //Cridada funcions ScriptConstruirTorres
    ScriptConstruirTorres construirTorres;

    void Start(){
        renderPerC = GetComponent<Renderer>();
        colorInicial = renderPerC.material.color;

        construirTorres = ScriptConstruirTorres.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    //Al clicar, construir la torre si no hi ha res
    void OnMouseDown(){
        if (!construirTorres.CanBuild)
            return;

        if(torre != null){
            Debug.Log("No pots construir!");
            return;
         }

        construirTorres.BuildTurretOn (this);
    }

    void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject())
        return;

        if (!construirTorres.CanBuild)
            return;

        if (construirTorres.HasGold)
        {
            //Si podem construir, color verd
            GetComponent<Renderer>().material.color = hoverColor;
        }
        else {
            //Si no vermell
            GetComponent<Renderer>().material.color = notGold;
        }


    }

    void OnMouseExit(){
        renderPerC.material.color = colorInicial;
    }
}
