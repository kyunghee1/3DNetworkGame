using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//photon API 를 사용하기 위한 네임스페이스

//역할: 포톤 서버 연결 관리자

public class PhotonManager : MonoBehaviourPunCallbacks //PUN의 다양한 서버 이벤트(콜백함수)를 받는다.
{
   
    void Start()
    {
        //목적: 연결을 하고싶다.
        //순서:
        //1. 게임 버전을 설정한다.
        PhotonNetwork.GameVersion = "0.0.1";
        //<전체를 뒤엎을 변화>, < 기능수정, 추가>, <버그, 내부적 코드 수정>
        
        //2. 닉네임을 설정한다.
        PhotonNetwork.NickName = $"김경희_{UnityEngine.Random.Range(0, 100)}";

        //3. 씬을 설정한다.
        //4. 연결한다.
        PhotonNetwork.ConnectUsingSettings();
    }
    //포톤 서버에 접속 후 호출되는 콜백 함수
    public override void OnConnected()
    {
        Debug.Log("서버접속 성공");
        Debug.Log(PhotonNetwork.CloudRegion);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("서버접속 해제");
    }
    //포톤 마스터 서버에 접속 후 호출되는 콜백 함수
    public override void OnConnectedToMaster()
    {
        Debug.Log("마스터 서버 접속 성공");
    }

    void Update()
    {
        
    }
}
