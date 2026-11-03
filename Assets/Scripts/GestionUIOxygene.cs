using UnityEngine;
using UnityEngine.UI;
public class GestionUIOxygene : MonoBehaviour
{
    [SerializeField] SanteJoueur sante;
    [SerializeField] Slider slider1;
    [SerializeField] Slider slider2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (sante == null)
        {
            Debug.LogError("Le script Sante n'est pas assigné dans le personnage.");
            return;
        }

        slider1.maxValue = sante.niveauOxygeneMax;
        slider2.maxValue = sante.niveauOxygeneMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (sante == null)
        {
            return;
        }

        slider1.value = sante.niveauOxygene;
        slider2.value = sante.niveauOxygene;
    }
}
