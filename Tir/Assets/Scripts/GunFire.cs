using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletMarkPrefab;
    [SerializeField] private GameObject wfxPrefab;
    [SerializeField] private Animator anim;

    public Transform fireOrigin;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ShowWFX();
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo)) {
                GameObject obj = Instantiate(bulletMarkPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                obj.transform.position += obj.transform.forward/1000;
            }
        } 

    }

    void ShowWFX() {
        anim.SetTrigger("doFire");
        var wfx = Instantiate(wfxPrefab, fireOrigin);
        Destroy(wfx, 0.1f);
    }
}
