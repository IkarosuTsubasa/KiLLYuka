using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class RotateTargetIcon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.UpdateAsObservable()
            .Subscribe(_ => transform.Rotate(new Vector3(0, 5, 0)));    
	}
}
