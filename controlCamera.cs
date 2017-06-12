using UnityEngine;

public class controlCamera : MonoBehaviour {

    public float speed = 200f;
    public float x = 70f;

    private bool hihaMoviment = true;
    //Velocitat Scroll
    public float sSpeed = 10f;
    //Eixos Y per minim i maxim scroll parametres
    public float minYScroll = 135f;
    public float maxYScroll = 335f;

    //MAXIMS I MINIS EIX z
    public float minZMovement = -120f;
    public float maxZMovement = 115f;

    //MAXIMS I MINIS EIX x
    public float minXMovement = -130f;
    public float maxXMovement = 120f;

    // Update is called once per frame
    void Update () {

        //Si el JOC ha acabat, no movem camera
        if (propiertatsJoc.jocAcabat){
            this.enabled = false;
            return;
        }

        //ZOOM IN - ZOOM OUT
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 posicio = transform.position;
        posicio.y -= scroll * 2000 * sSpeed * Time.deltaTime;
        //LIMITS PER LES POSICIONS X,Y,Z
        posicio.y = Mathf.Clamp(posicio.y, minYScroll, maxYScroll);
        posicio.z = Mathf.Clamp(transform.position.z, minZMovement, maxZMovement);
        posicio.x = Mathf.Clamp(transform.position.x, minXMovement, maxXMovement);
        transform.position = posicio;

        //Amb el space movem o no
        if (Input.GetKeyDown(KeyCode.Space)){
            hihaMoviment = !hihaMoviment;
        }

        if (hihaMoviment)
            return;

        //transform.position.z = Mathf.Clamp(transform.position.z, -10, 10);
        //NO EMPRAR Input.GetKey("UP) - Emprar Input.GetKey(KeyCode.UpArrow), el primer donara errors per ser Linux/MacOS
        //ARROW DOWN
        if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= x){
            //print("up arrow key is held down");
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        //ARROW LEFT
        if(Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= x){
            //print("left arrow key is held down");
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        //ARROW RIGHT
        if(Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - x){
            //print("right arrow key is held down");
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        //ARROW UP
        if(Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - x){
            //print("up arrow key is held down");
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
	}
}
