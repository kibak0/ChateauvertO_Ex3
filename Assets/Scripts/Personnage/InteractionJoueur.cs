using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InteractionJoueur : MonoBehaviour
{
    [Header("Raycast d'interaction")]
    [SerializeField] float distanceInteraction = 2f; // Distance maximale pour interagir avec un interrupteur
    [SerializeField] LayerMask couchesInteractives; // Couches sur lesquelles le joueur peut


    [Header("Composants")]
    ControlesJoueur controles;
    Animator animator;

    void Start()
    {
        controles = GetComponent<ControlesJoueur>();
        animator = GetComponent<Animator>();
    }


    void OnDrawGizmos()
    {
        // Dessiner un rayon pour visualiser la distance d'interaction dans l'éditeur
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.forward * distanceInteraction);
    }

    void OnTriggerEnter(Collider other)
    {

    }
    public void DetecterInterrupteur()
    {
        Vector3 positionDepart = transform.position + Vector3.up;

        if (Physics.Raycast(positionDepart, transform.forward, out RaycastHit hitInfo, distanceInteraction, couchesInteractives))
        {
            Interrupteur interrupteur = hitInfo.collider.GetComponent<Interrupteur>();
            if (interrupteur != null)
            {
                interrupteur.Activer();
            }
        }

    }


}
