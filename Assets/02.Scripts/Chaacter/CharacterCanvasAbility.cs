using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCanvasAbility : CharacterAbility
{
    public Canvas MyCanvas;
    public Text NicknameTextUI;

    public Slider HealthSilder;
    public Slider StaminaSilder;
    // Start is called before the first frame update
    void Start()
    {
        NicknameTextUI.text = _owner.PhotonView.Controller.NickName;
   
    }

    // Update is called once per frame
    void Update()
    {
        //Todo. 빌보드구현
        MyCanvas.transform.forward = Camera.main.transform.forward;

        HealthSilder.value  =(float)_owner.Stat.Health / _owner.Stat.MaxHealth;
        StaminaSilder.value = _owner.Stat.Stamina / _owner.Stat.MaxStamina;
    }
}
