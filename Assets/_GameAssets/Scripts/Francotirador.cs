using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Francotirador : MonoBehaviour {

    [SerializeField] Transform puntoDisparo;
    [SerializeField] Camera miCamara;
    [SerializeField] GameObject mirilla;
    bool apuntando = false;
    float currentFOV;
    float minFOV= 25;
    float maxFOV;


    private void Start() {
        maxFOV = miCamara.fieldOfView;
        currentFOV = miCamara.fieldOfView;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Boton derecho pulsado");
            apuntando = true;
         }
        if (Input.GetMouseButtonUp(1)) {
        
            apuntando = false;
            currentFOV = maxFOV;
            mirilla.SetActive(false);
        }

        if (apuntando == true) {
            currentFOV = currentFOV - 1;
            currentFOV = Mathf.Max(currentFOV, minFOV);
            if (currentFOV == minFOV) {
                mirilla.SetActive(true);
            }
        }

        miCamara.fieldOfView = currentFOV;

    }
        
    private void OnMouseDown() {
        Vector3 forward = puntoDisparo.forward;
        Ray rayo = new Ray(puntoDisparo.position, forward);
        RaycastHit hitinfo;
       bool impactoConseguido =  Physics.Raycast(rayo ,out hitinfo, 25);

        if (impactoConseguido == true) {
            print(hitinfo.collider.gameObject.name);
            Debug.DrawLine(
                puntoDisparo.position,
                hitinfo.collider.transform.position,
                Color.red,
                5);
        } else
      
            print("Fail!");
    }
}
