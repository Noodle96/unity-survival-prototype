using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SelectionManager : MonoBehaviour
{

    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text_TMP;
    //Text interaction_text;

    private void Start()
    {
        interaction_text_TMP = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        //Camera.main = la cámara que tiene el tag MainCamera.
        //Input.mousePosition = posición del mouse en pixeles en pantalla.
        //ScreenPointToRay convierte ese punto 2D en un rayo 3D que sale desde la cámara.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //Este rayo toca algún collider en el mundo?
        //rellena hit con información del impacto:
        //hit.transform(objeto golpeado)
        //hit.point(punto exacto)
        //hit.distance(distancia)
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            InteractableObject interactable = hit.transform.GetComponentInParent<InteractableObject>();

            if (interactable != null)
            {
                interaction_text_TMP.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }
        }
        else
        {
            interaction_Info_UI.SetActive(false);
        }
    }
}