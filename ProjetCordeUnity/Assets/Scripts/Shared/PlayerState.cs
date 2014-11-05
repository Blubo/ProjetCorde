using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public bool v_isLinked;
	private float _linkingTimer;

	// Use this for initialization
	void Start () {
		_linkingTimer=5f;
		v_isLinked=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(v_isLinked==false){
			_linkingTimer -= Time.deltaTime;
		}

		if(_linkingTimer<=0){
			_linkingTimer=5;
			v_isLinked=true;

		}
	}
}
