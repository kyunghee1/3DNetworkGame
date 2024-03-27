using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterMoveAbility))]
[RequireComponent(typeof(CharacterRotateAbility))]
[RequireComponent(typeof(CharacterAttackAbility))]


public class Character : MonoBehaviour, IPunObservable, IDamaged
{
    public PhotonView PhotonView { get; private set; }
    public Stat Stat;

    private Vector3 _receivedPosition;
    private Quaternion _receivedRotation;



    void Awake()
    {
        Stat.Init();

        PhotonView =GetComponent<PhotonView>();
        if(PhotonView.IsMine)
        {
            UI_CharacterStat.Instance.MyCharacter = this;
        }
    }
    //데이터 동기화를 위해 데이터 전송 및 수신 기능을 가진 약속
  public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        //stream(통로)은 서버에서 주고받을 데이터가 담겨있는 변수
        if (!PhotonView.IsMine) //데이터를 전송
        {
            
            stream.SendNext(Stat.Health);
            stream.SendNext(Stat.Stamina);
        }
        else if(stream.IsReading)//데이터 수신
        {
           Stat.Health = (int)stream.ReceiveNext();
           Stat.Stamina = (float)stream.ReceiveNext();


        }
        //info 는 송수신 성공/ 실패 여부에 대한 메세지 담겨있다.
    }
    [PunRPC]
    public void Damaged(int damage)
    {
        Stat.Health -= damage;
    }

    void Update()
    {
        if (!PhotonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, _receivedPosition, Time.deltaTime * 20f);
            transform.rotation = Quaternion.Slerp(transform.rotation, _receivedRotation, Time.deltaTime * 20f);
        }

    }
}
