using UnityEngine;
using System.Collections;

public class info_invisible : MonoBehaviour{
	private SpriteRenderer myRenderer;
	public Sprite do_sp;
	public Sprite gea_sp;
	public Sprite gul_sp;
	public Sprite yut_sp;
	public Sprite mo_sp;
	public Sprite Bdo_sp;
	public Sprite nack_sp;
	
	void Start()
	{
		myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		myRenderer.sprite = null;

	}
	
	public void do_on()
	{
		myRenderer.sprite = do_sp;
	//	GameObject.Find ("S_marker0").SendMessage ("marker_on");
	}
	public void gea_on()
	{
		myRenderer.sprite = gea_sp;
	//	GameObject.Find ("S_marker0").SendMessage ("marker_on");
	}
	public void gul_on()
	{
		myRenderer.sprite = gul_sp;
	//	GameObject.Find ("S_marker0").SendMessage ("marker_on");
	}
	public void yut_on()
	{
		myRenderer.sprite = yut_sp;
	//	GameObject.Find ("S_marker0").SendMessage ("marker_on");
	}
	public void mo_on()
	{
		myRenderer.sprite = mo_sp;
	//	GameObject.Find ("S_marker0").SendMessage ("marker_on");
	}
	public void Bdo_on()
	{
		myRenderer.sprite = Bdo_sp;
	}
	public void nack_on()
	{
		myRenderer.sprite = nack_sp;
	}
	

	
}
