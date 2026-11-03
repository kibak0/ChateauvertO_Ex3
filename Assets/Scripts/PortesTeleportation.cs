using Unity.Mathematics;
using UnityEngine;

public class PortesTeleportation : MonoBehaviour
{
    public Transform pointDeTeleportation;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CharacterController>().enabled = false;

            other.gameObject.transform.position = pointDeTeleportation.position;
            other.gameObject.transform.rotation = quaternion.LookRotation(pointDeTeleportation.forward, Vector3.up);

            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
