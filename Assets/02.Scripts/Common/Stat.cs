using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] //직렬화:수정이 가능하게
public class Stat
{
  
    public float RotationSpeed;
    public float AttackCoolTime;

    public float  Health;
    public float MaxHealth;

    public float MaxStamina ;
    public float Stamina ;

    public float RunSpeed;
    public float MoveSpeed;

    public float staminaRecoverRate;
    public float runningStaminaConsumptionRate;

    public float attackStaminaConsumption;

    public int Damage;
    

   public  bool isRunning = false;

    public void Init()
    {
        Health = MaxHealth;
        Stamina = MaxStamina;
    }
    void Start()
    {
      
    }

   
    void Update()
    {
       
    }

}
