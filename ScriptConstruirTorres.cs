using UnityEngine;

public class ScriptConstruirTorres : MonoBehaviour {

    //Variable sense referencia per els nodes
    public static ScriptConstruirTorres instance;

    //Només un ScriptConstruirTorres però amb instancies al iniciar-ho amb la variable de abaix
    void Awake(){
        if(instance != null)
        {
            Debug.LogError("Més d'un Script ScriptConstruirTorres en la escena");
        }
        instance = this;
    }

   /* //Torre per defecte, asset/prefab
    public GameObject torrePrefabAsset;
    public GameObject torrePrefabArrow;
    public GameObject torrePrefabBalista;
    public GameObject torrePrefabMagia;
    */

    public torreAConstruir turretToBuild;

    //Propietat per agafar el turretPlacementOn
    public bool CanBuild { get { return turretToBuild != null; } }
    //Te gold per construir
    public bool HasGold { get { return Jugador.gold >= turretToBuild.costTorre; } }

    public void BuildTurretOn(nodo nodo){
        if(Jugador.gold < turretToBuild.costTorre){
            print("No tens or suficient");
            return;
        }
        //Eliminem el or del or que tenim
        Jugador.gold -= turretToBuild.costTorre;

        GameObject tempTorre = (GameObject) Instantiate(turretToBuild.prefabTorre, nodo.GetBuildPosition(), Quaternion.identity);
        nodo.torre = tempTorre;

        print("Construcció finalitzada, queden" + Jugador.gold);
    }

   public void SelectTurretToBuild(torreAConstruir turret){
        turretToBuild = turret;
    }
}
