using UnityEngine;

public class ShopUI_script : MonoBehaviour {
    //Millor no posar "Control" al nom o peta
    public torreAConstruir arrTurret;
    public torreAConstruir balistaTurret;
    public torreAConstruir canoTurret;
    public torreAConstruir magicTurret;


    //Cridada funcions ScriptConstruirTorres
    ScriptConstruirTorres construirTorres;

    void Start(){
        construirTorres = ScriptConstruirTorres.instance;

    }

    //Compra torre
    public void compradaTorreCano()
    {
       Debug.Log("Torre de canó comprada");
       construirTorres.SelectTurretToBuild(canoTurret);
    }    
    
    //Compra arrow
    public void compradaTorreArrow()
    {
        Debug.Log("Arrow torre comprada");
        construirTorres.SelectTurretToBuild(arrTurret);
    }

    //Compra magia
    public void compradaTorreMagia()
    {
       
        Debug.Log("Torre de Magia comprada");
        construirTorres.SelectTurretToBuild(magicTurret);
    }

    //Compra ballesta
    public void compradaTorreBalista()
    {
        Debug.Log("Balista Torre comprada");
        construirTorres.SelectTurretToBuild(balistaTurret);
    }

}
