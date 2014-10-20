using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	
	public	Texture2D	tex		= null;
	public	Vector2		tiling	= new Vector2(1.0f,1.0f);
	public	Vector2		offset	= new Vector2(0.0f,0.0f);
	public	Color		color	= Color.white;
	
	void Start () {
		if(tex != null)	renderer.material.SetTexture("_MainTex",tex);
		renderer.material.SetTextureScale	("_MainTex",tiling);
		renderer.material.SetTextureOffset	("_MainTex",offset);
		renderer.material.SetColor			("_TintColor",color);
	}
}
