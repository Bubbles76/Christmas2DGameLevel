using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField,Header("Register to know when my health changes")]
    private HealthChangeEvent onHealthChange;

    [SerializeField, Header("Register to know when my health expires")]
    private HealthExpiredEvent onHealthExpired;

    [SerializeField]
    private float amount = 10f;

    private float maxAmount;


    public float Amount
    {
        get { return amount; }
        set
        {
            amount = value;

            if (onHealthChange != null)
            {
                onHealthChange.Invoke(HeathPercent);
            }
            // health expires, broatcast notification
            if (HeathPercent <= 0f && onHealthExpired != null)
            {
                onHealthExpired.Invoke();
            }
        }
    }


    private float HeathPercent
    {
        get { return Amount / maxAmount * 100; }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxAmount = amount;
    }



}
