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
    NavMeshAgent agent;
    [SerializeField] AudioClip sonMort;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();

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
        Vector3 direction = joueur.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance <= distancePoursuite)
        {
            agent.SetDestination(joueur.transform.position);
        }
        else
        {
            agent.SetDestination(positionInitiale);
        }

        animator.SetFloat("vitesse", agent.velocity.magnitude);
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