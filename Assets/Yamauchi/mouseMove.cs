using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour {
    GameObject spotLight;
	// Use this for initialization
	void Start () {
        spotLight = GameObject.Find("SpotLight");
	}
	
	// Update is called once per frame
    void Update()
    {
        Vector3 touchScreenPosition = Input.mousePosition;

        touchScreenPosition.x = Mathf.Clamp(touchScreenPosition.x, 0.0f, Screen.width);
        touchScreenPosition.y = Mathf.Clamp(touchScreenPosition.y, 0.0f, Screen.height);

        // 10.0fに深い意味は無い。画面に表示したいので適当な値を入れてカメラから離そうとしているだけ.
        touchScreenPosition.z = 7.0f;

        Camera gameCamera = Camera.main;
        Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);

        spotLight.transform.position = touchWorldPosition;
    }
}
