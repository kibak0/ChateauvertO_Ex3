using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SanteJoueur : MonoBehaviour
{
    [Header("Gestion de la santé")]
    public float niveauOxygene = 100f;
    public float niveauOxygeneMax = 100f;
    public float perteOxygene = 0.1f;

    [Header("Sons")]
    [SerializeField] AudioClip sonMort;
    [SerializeField] AudioClip sonOxygene;
    [SerializeField] AudioClip sonBlesse;

    [Header("Composants")]
    ControlesJoueur controles;
    Animator animator;
    AudioSource audiosource;

    private bool estMort = false;

    void Start()
    {
        controles = GetComponent<ControlesJoueur>();
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (estMort)
            return;

        RecevoirDegats(perteOxygene * Time.deltaTime);
    }

    public void RecevoirDegats(float degats)
    {
        if (estMort)
            return;

        niveauOxygene -= degats;
        niveauOxygene = Mathf.Clamp(niveauOxygene, 0f, niveauOxygeneMax);

        if (niveauOxygene <= 0f)
        {
            StartCoroutine(Mourir());
        }
    }

    public void Soigner(float soins)
    {
        if (estMort)
            return;

        niveauOxygene += soins;
        niveauOxygene = Mathf.Clamp(niveauOxygene, 0f, niveauOxygeneMax);
    }

    public IEnumerator Mourir()
    {
        if (estMort)
            yield break;

        estMort = true;

        // Changer l'état du personnage à MORT
        controles.etatPerso = EtatPerso.MORT;

        // Jouer le son de mort
        audiosource.PlayOneShot(sonMort);

        // Jouer l'animation de mort
        animator.SetTrigger("mort");

        yield return new WaitForSeconds(3f);

        // Recharger la scène actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}