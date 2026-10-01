using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Acceleration : MonoBehaviour
{
    [SerializeField] private float forceBoost = 15f;
    private float charge = 0;
    private float chargeMax = 3;
    private Rigidbody rigidbody;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        if (ControleurJeu.Instance != null && ControleurJeu.Instance.Controles != null)
        {
            PlayerInput controles = ControleurJeu.Instance.Controles;
            controles.actions.FindAction("Boost").performed += BoostAction;


        }

    }
    private void OnDestroy()
    {
        if (ControleurJeu.Instance == null)
            return;

        PlayerInput controles = ControleurJeu.Instance.Controles;

        if (controles == null)
            return;

        controles.actions.FindAction("Diriger").performed -= BoostAction;
        

    }

    private void FixedUpdate()
    {
        
    }
    private void BoostAction(InputAction.CallbackContext contexte)
    {
        if(charge>0 && charge < 3) {
        rigidbody = GetComponent<Rigidbody>(); 
        if (rigidbody != null)
        {
            rigidbody.AddForce(transform.forward * forceBoost, ForceMode.Impulse);
        }
         }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (charge < chargeMax)
        {
            charge = charge + 1;
            
        }
    }
}
