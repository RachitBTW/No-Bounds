using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Transform blockArm;

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {
            transform.localRotation = Quaternion.Euler(180, 0f, -rotationZ);
            blockArm.localRotation = Quaternion.Lerp(blockArm.rotation, Quaternion.Euler(new Vector3(0f, 180, 0f)), Time.deltaTime * 4f);
            /*blockArm.localRotation = Quaternion.Euler(0f, 180, 0f);*/
        }
        else
        {
            //blockArm.localRotation = Quaternion.Euler(0f, 0f, 0f);
            blockArm.localRotation = Quaternion.Lerp(blockArm.rotation, Quaternion.Euler(new Vector3(0f, 0f, 0f)), Time.deltaTime * 4f);

        }


    }

}
