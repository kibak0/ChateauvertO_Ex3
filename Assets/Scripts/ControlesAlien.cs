using UnityEngine;
using UnityEngine.AI;

public class ControlesEnnemi : MonoBehaviour
{
    [Header("Etat")]
    [SerializeField] bool estMort = false;

    [Header("Cible")]
    [SerializeField] GameObject joueur;

    [Header("Déplacement")]
    [SerializeField] bool peutBouger = true;
    [SerializeField] float distancePoursuite = 5f;
    [SerializeField] float vitessePoursuite = 2f;
    [SerializeField] float vitesseRetour = 3f;
    [SerializeField] float pointsVie = 100f;
    Vector3 positionInitiale;

    [Header("Composants")]

    Animator animator;
    AudioSource audioSource;
    [SerializeField] AudioClip sonMort;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        pointsVie = 100f;
        positionInitiale = transform.position;

    }

    void Update()
    {

        if (peutBouger && !estMort)
        {
            GererDeplacement();
        }

    }

    void GererDeplacement()
    {
    }

    void RetournerPositionInitiale()
    {

    }


    public void RecevoirDegats(int degats)
    {
        if (estMort == false)
        {
            pointsVie -= degats;

            if (pointsVie <= 0)
            {
                Mourir();
            }
        }
    }

    public void Mourir()
    {
        audioSource.PlayOneShot(sonMort);
        estMort = true;

        // Arrêter l'agent 
        // Arrêter le chemin

        animator.SetTrigger("mort");

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hitbox") && !estMort)
        {
            Mourir();
        }
    }
}