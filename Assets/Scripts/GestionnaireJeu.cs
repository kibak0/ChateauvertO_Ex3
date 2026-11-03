using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public enum EtatJeu
{
    JEU, PAUSE
}
public class GestionnaireJeu : MonoBehaviour
{
    public static GestionnaireJeu instance; // Singleton pour accéder à l'instance du gestionnaire de jeu
    [SerializeField] public EtatJeu etatJeu; // État actuel du jeu (INTRO, JEU, FIN, PAUSE)


    [Header("Menu Pause")]
    [SerializeField] InputAction pauseAction; // Action de pause
    [SerializeField] GameObject menuPause; // Référence au menu de pause

    // ======================

    void OnEnable()
    {
        pauseAction.Enable(); // Activer l'action de pause
    }
    void OnDisable()
    {
        pauseAction.Disable(); // Désactiver l'action de pause
    }
    // ======================   

    void Start()
    {
        if (instance == null)
        {
            instance = this; // Assigner l'instance du gestionnaire de jeu
            etatJeu = EtatJeu.JEU; // Initialiser l'état du jeu à JEU
        }
        else
        {
            Destroy(gameObject); // Détruire l'objet si une instance existe déjà
        }

    }

    void Update()
    {
        if (pauseAction.WasPressedThisFrame()) // Vérifier si l'action de pause a été déclenchée
        {
            if (etatJeu == EtatJeu.JEU)
            {
                Time.timeScale = 0f; // Mettre le temps à l'arrêt
                Pause(true); // Mettre le jeu en pause
            }
            else if (etatJeu == EtatJeu.PAUSE)
            {
                Time.timeScale = 1f; // Reprendre le temps
                Pause(false); // Reprendre le jeu
            }
        }
    }

    public void AllerIntro()
    {
        SceneManager.LoadScene("Intro"); // Charger la scène d'introduction
    }

    public void AllerFin()
    {
        SceneManager.LoadScene("Fin"); // Charger la scène de fin
    }

    public void Pause(bool enPause)
    {
        if (enPause)
        {
            menuPause.SetActive(true); // Activer le menu de pause
            etatJeu = EtatJeu.PAUSE; // Mettre à jour l'état du jeu à PAUSE
        }
        else
        {
            menuPause.SetActive(false); // Désactiver le menu de pause
            etatJeu = EtatJeu.JEU; // Mettre à jour l'état du jeu à JEU
        }
    }

}
