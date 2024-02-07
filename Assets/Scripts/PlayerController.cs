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

    [HideInInspector] //public������ �������� �Ҷ� �̿�
    public bool canLook = true;

    private Rigidbody _rigidbody;

    public static PlayerController instance; //�̱���
    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; //cursor�� ������ �ʵ��� ���
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

    void CameraLook()//���콺 �����ӿ� ���� ������
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurYRot += mouseDelta.x * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);//�ּ�, �ִ�ġ�� ���� �ʵ���
        camCurYRot = Mathf.Clamp(camCurYRot, minXLook, maxXLook);//�ּ�, �ִ�ġ�� ���� �ʵ���

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