using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

[RequireComponent(typeof(CharacterMoveAbility))]
[RequireComponent(typeof(CharacterRotateAbility))]
[RequireComponent(typeof(CharacterAttackAbility))]


public class Character : MonoBehaviour, IPunObservable, IDamaged
{
    public PhotonView PhotonView { get; private set; }
    public Stat Stat;

    private Vector3 _receivedPosition;
    private Quaternion _receivedRotation;

    public ParticleSystem HitEffect;



    void Awake()
    {
        Stat.Init();

        PhotonView = GetComponent<PhotonView>();
        if (PhotonView.IsMine)
        {
            UI_CharacterStat.Instance.MyCharacter = this;
        }
    }
    private void Update()
    {
        if (!PhotonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, _receivedPosition, Time.deltaTime * 20f);
            transform.rotation = Quaternion.Slerp(transform.rotation, _receivedRotation, Time.deltaTime * 20f);
        }
    }
    //데이터 동기화를 위해 데이터 전송 및 수신 기능을 가진 약속
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // stream(통로)은 서버에서 주고받을 데이터가 담겨있는 변수
        if (stream.IsWriting)     // 데이터를 전송하는 상황
        {
            stream.SendNext(Stat.Health);
            stream.SendNext(Stat.Stamina);
        }
        else if (stream.IsReading) // 데이터를 수신하는 상황
        {
            // 데이터를 전송한 순서와 똑같이 받은 데이터를 캐스팅해야된다.
            Stat.Health = (int)stream.ReceiveNext();
            Stat.Stamina = (float)stream.ReceiveNext();
        }
        // info는 송수신 성공/실패 여부에 대한 메시지 담겨있다.
    }
    [PunRPC]
    public void Damaged(int damage)
    {
        Stat.Health -= damage;
    }

    public void TakeDamage(int damage)
    {
        //적이 피격되었을 때 호출되는 메서드
        //피격 이펙트 생성 및 동기화
        if (PhotonView.IsMine)
        {
            PhotonView.RPC("SpawnHitEffect", RpcTarget.All);
        }
        //피격에 대한 처리(예: 체력 감소 등)
    }
    [PunRPC]
    void SpawnHitEffect()
    {
        //damageInfo.Position = (other.transform.position + transform.position) /2f;
        

        //일정 시간 후에 이펙트를 파괴
        Destroy(HitEffect, 3f);
    }
    
    private GameObject Instantiate(object hitEffectPrefab, Vector3 position, Quaternion identity)
    {
        throw new NotImplementedException();
    }
}
 

