using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    [Header("Paramètres de mouvement")]
    [SerializeField] float vitesseDeplacement = 5f;
    public float vitesseRotation = 200f;
    Vector3 deplacementAvant;

    [Header("Paramètres de saut")]
    [SerializeField] float hauteurSaut = 2f;
    [SerializeField] float gravite = -9.81f;
    Vector3 deplacementVertical;

    [Header("Paramètres deplacement special")]
    [SerializeField] float forceSpeciale = 5f;
    [SerializeField] float decelerationSpeciale = 15f;
    Vector3 deplacementSpecial;

    [Header("Composants")]
    CharacterController characterController;
    Animator animator;

    // ========================================

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // ========================================
    public Vector3 CalculerDeplacement(Vector2 controleJoueur)
     {
        deplacementAvant = transform.forward * controleJoueur.y * vitesseDeplacement;
        return deplacementAvant;
    }

    public Vector3 CalculerGravite()
     {
        if (characterController.isGrounded && deplacementVertical.y < 0)
        {
            deplacementVertical.y = -2f;
        }
        else
        {
            deplacementVertical.y += gravite * Time.deltaTime;
        }
        return deplacementVertical;
    }

    public Vector3 CalculerForceSpeciale()
     {
        deplacementSpecial = Vector3.MoveTowards(deplacementSpecial, Vector3.zero, decelerationSpeciale * Time.deltaTime);
        return deplacementSpecial;

    }

    public void MettreAJourRotation(float directionX)
    {
        transform.Rotate(Vector3.up * directionX * vitesseRotation * Time.deltaTime);
    }

    public void MettreAJourDeplacement(Vector3 direction)
    {
        characterController.Move(direction * Time.deltaTime);
    }

    // ========================================

    public void Sauter()
    {
        if (characterController.isGrounded)
        {
            deplacementVertical.y = Mathf.Sqrt(hauteurSaut * -2f * gravite);
        }
    }

    public void Dash()
    {
        deplacementSpecial += transform.forward * forceSpeciale; // Appliquer une force vers l'avant du joueur
    }

    public void AjouterForce(Vector3 direction, float force)
    {
        deplacementSpecial += direction * force;
    }




}
