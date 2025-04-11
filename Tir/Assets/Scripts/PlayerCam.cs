using System.Collections;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 400f;
    public float sensY = 400f;
    
    public Transform orientation;

    float xRotation;
    float yRotation;

    float fov = 60;
    bool isZoom = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        if (Input.GetMouseButtonDown(1) && !isZoom) {
            isZoom = true;
            StartCoroutine(Zoom());
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Cursor.visible) 
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }

    IEnumerator Zoom() {
        for (int i = 0; i < 30; i++) {
            Camera.main.fieldOfView -= 1f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(1);
        Camera.main.fieldOfView = fov;
        isZoom = false;
    }

}
