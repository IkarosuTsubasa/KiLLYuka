using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Triggers;

public class SkillCoolDown : MonoBehaviour {

	public float cooldown; 
	public float currentCoolDown;
	public Image SkillButton;
	private void Start(){
		currentCoolDown = 5;
		this.UpdateAsObservable()
			.Where(_ => currentCoolDown<cooldown)
    		.Subscribe(_ => Updateimage());
	}
	void Updateimage()
	{
		currentCoolDown += 0.1f;
		SkillButton.fillAmount = currentCoolDown/cooldown; 
	}
	void OnClick() 
	{
		if(currentCoolDown >= cooldown)
		{	//TODO: something
			currentCoolDown = 0;
		}
	}
}