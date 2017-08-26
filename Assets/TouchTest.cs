using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class TouchTest : MonoBehaviour {

	public GameObject Player;
	public GameObject TouchObject;
    // Use this for initialization
    void Start () {
		this.UpdateAsObservable()
			.Where(_ => OnTouchDown())
        	.Subscribe(_ => Player.transform.LookAt(TouchObject.transform));
    }
    //スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
    bool OnTouchDown() {
        // タッチされているとき
        if( 0 < Input.touchCount){
            // タッチされている指の数だけ処理
            for(int i = 0; i < Input.touchCount; i++){
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしたときかどうか
                if(t.phase == TouchPhase.Began ){
                    //タッチした位置からRayを飛ばす
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit)){
						Debug.Log(hit.collider.gameObject.name);
                        //Rayを飛ばしてあたったオブジェクトが自分自身だったら
                        if (hit.collider.gameObject.tag == "Enemy"){
							TouchObject = hit.collider.gameObject;
							//Player.transform.LookAt(TouchObject.transform);
                            return true;
                        }
                    }
                }
            }
        }
        return false; //タッチされてなかったらfalse
    }
}
