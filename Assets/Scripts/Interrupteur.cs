using UnityEngine;

public class Interrupteur : MonoBehaviour
{
    [SerializeField] Animator animatorPorte;
    bool estOuvert = false;

    public void Activer()
    {
        if (estOuvert == false)
        {
            estOuvert = true;
            animatorPorte.SetTrigger("interrupteur");
        }
    }

}
