using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class CharacterMoveAbility : MonoBehaviour
{
    //목표: [W],[A],[S],[D]및 방향키를 누르면 캐릭터를 그 방향으로 이동시키고 싶다.
    private CharacterController _characterController;
    public float moveSpeed = 7.0f;    //이동 속도
    private Vector3 moveDirecton; //이동 방향

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        //순서
        //1. 사용자의 키보드 입력을 받는다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDirecton = new Vector3(h, 0f, v).normalized;


        //2. '캐릭터가 바라보는 방향'을 기준으로 방향을 설정한다.
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);
        //3. 이동속도에 따라 그 방향으로 이동한다.
        _characterController.Move(dir * (moveSpeed * Time.deltaTime));
        //4. 중력 적용하세요.
        dir.y = -1f;
    }
   
}
