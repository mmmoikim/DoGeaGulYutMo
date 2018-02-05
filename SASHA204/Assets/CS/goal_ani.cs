using UnityEngine;
using System.Collections;

public enum mal_ani_state
{
	None,
	OPen
}

public class goal_ani : MonoBehaviour {


	public Texture[] goal_ani_0,goal_ani_1,goal_ani_2,goal_ani_3;
	public mal_ani_state ANI;
	int Ani_count;
	int state = -2;
	int pre_count;
	
	void Start()
	{
		GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = false;

	}
	
	public void goal_on_0 ()
	{
		state = 0;
		ANI = mal_ani_state.OPen;
		Ani_count = 0;
	}
	
	public void goal_on_1 ()
	{
		state = 1;
		ANI = mal_ani_state.OPen;
		Ani_count = 0;
	}
	
	public void goal_on_2 ()
	{
		state = 2;
		ANI = mal_ani_state.OPen;
		Ani_count = 0;
	}
	
	public void goal_on_3 ()
	{
		state = 3;
		ANI = mal_ani_state.OPen;
		Ani_count = 0;
	}
	
	public void ani_ing_0 ()
	{
		GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = true;
		renderer.material.mainTexture = goal_ani_0 [Ani_count];
		if (pre_count == 50) {
						Ani_count++;
			pre_count = 0;
				}
		pre_count++;
		if (Ani_count >= goal_ani_0.Length) {
			ANI = mal_ani_state.None;
			GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = false;
			Ani_count = 0;
		} 
	
		
	}
	public void ani_ing_1 ()
	{
		GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = true;
		renderer.material.mainTexture = goal_ani_1 [Ani_count];
		if (pre_count == 50) {
			Ani_count++;
			pre_count = 0;
		}
		pre_count++;
		if (Ani_count >= goal_ani_1.Length) {
			ANI = mal_ani_state.None;
			Ani_count = 0;
			GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = false;
		} 
		
	}
	public void ani_ing_2 ()
	{
		GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = true;
		renderer.material.mainTexture = goal_ani_2 [Ani_count];
		if (pre_count == 50) {
			Ani_count++;
			pre_count = 0;
		}
		pre_count++;
		if (Ani_count >= goal_ani_2.Length) {
			ANI = mal_ani_state.None;
			Ani_count = 0;
			GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = false;
		} 
		
	}
	public void ani_ing_3 ()
	{
		GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = true;
		renderer.material.mainTexture = goal_ani_3 [Ani_count];
		if (pre_count == 50) {
			Ani_count++;
			pre_count = 0;
		}
		pre_count++;
		if (Ani_count >= goal_ani_3.Length) {
			ANI = mal_ani_state.None;
			Ani_count = 0;
			GameObject.Find ("goal_ani").GetComponent<MeshRenderer> ().enabled = false;
		} 
		
	}
	
	void Update()
	{
		if (ANI == mal_ani_state.OPen) {
		

			switch (state) {
			case 0:
				ani_ing_0 ();
				break;
			case 1:
				ani_ing_1 ();
				break;
			case 2:
				ani_ing_2 ();
				break;
			case 3:
				ani_ing_3 ();
				break;
			}
			
		}
	}
}
