using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour {

    public Transform target;

    void Update() {

        if(target) transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

    }

}
