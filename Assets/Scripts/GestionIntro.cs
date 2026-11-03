using UnityEngine;
using UnityEngine.SceneManagement;
public class GestionIntro : MonoBehaviour
{
    public void QuitterJeu()
    {
        Application.Quit(); // Quitter l'application
    }

    public void DemarrerJeu()
    {
        SceneManager.LoadScene("Jeu"); // Charger la scène de jeu
    }
}
