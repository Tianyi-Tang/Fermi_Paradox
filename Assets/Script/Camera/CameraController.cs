using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制摄像机的移动和放大；
/// </summary>
public class CameraController : MonoBehaviour
{
    private bool move_flag = true;//决定camera是否能移动
    private Vector3 moveInput;
    [SerializeField] private float panSpeed;

    [SerializeField] private float scrollSpeed;
    [SerializeField] private float minHight;
    [SerializeField] private float maxHight;

    [SerializeField]private Vector3 cameraPosition; //camera与行星系的距离

    private static CameraController _instance;



    public void stopMovingCamera()
    {
        move_flag = false;
    }

    public void letCameraMove()
    {
        move_flag = true;
    }


    void Update()
    {
        if(move_flag)
            cameraMovement();
    }

    private void cameraMovement()
    {
        Vector3 pos = transform.position;

        moveInput.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        /*
        Vector2 mousePos = Input.mousePosition;
      
        if (mousePos.x > Screen.width * 0.8f && mousePos.x < Screen.width)
            moveInput.x = 1;
        if (mousePos.x < Screen.width * 0.2f && mousePos.x > 0)
            moveInput.x = -1;
        if (mousePos.y > Screen.height * 0.8f && mousePos.y < Screen.height)
            moveInput.z = 1;
        if (mousePos.y < Screen.height * 0.2f && mousePos.y > 0)
            moveInput.z = -1;
        */

        pos.x += moveInput.normalized.x * panSpeed * Time.deltaTime;
        pos.y += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
        pos.z += moveInput.normalized.z * panSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minHight, maxHight);

        transform.position = pos;
    }

    /// <summary>
    /// 将camer对准制定行星系
    /// </summary>
    /// <param name="foucseObj">目标物体</param>
    public void focusingPlanetarySystem(Transform foucseObj)
    {
        Vector3 pos = foucseObj.position;
        pos.x += cameraPosition.x;
        pos.y += cameraPosition.y;
        pos.z += cameraPosition.z;

        transform.position = pos;
        transform.rotation = Quaternion.Euler(45, 0, 0);

        move_flag = false;
    }


    /// <summary>
    /// 将camer回归到正常视角并恢复自由移动
    /// </summary>
    public void backInitialState()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.position = new Vector3(transform.position.x - cameraPosition.x, 50, transform.position.z - cameraPosition.z);

        move_flag = true;
    }

}
