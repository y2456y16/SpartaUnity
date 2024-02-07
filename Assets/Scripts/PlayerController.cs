using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    private float camCurYRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;

    [SerializeField]
    private GameObject playerArmature;

    [HideInInspector] //public이지만 가리려고 할때 이용
    public bool canLook = true;

    private Rigidbody _rigidbody;

    public static PlayerController instance; //싱글톤
    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; //cursor가 보이지 않도록 잠금
    }

    private void LateUpdate()
    {
        /*
        if (canLook)
        {
            CameraLook();
        }
        */
    }

    void CameraLook()//마우스 움직임에 따른 움직임
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurYRot += mouseDelta.x * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);//최소, 최대치를 넘지 않도록
        camCurYRot = Mathf.Clamp(camCurYRot, minXLook, maxXLook);//최소, 최대치를 넘지 않도록

        playerArmature.transform.eulerAngles += new Vector3(0, -camCurYRot, 0);
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}