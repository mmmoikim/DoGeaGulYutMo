using UnityEngine;
using System.Collections;

public class piece : MonoBehaviour
{


		private GameObject[] piece0 = new GameObject[4];
		private GameObject[] piece1 = new GameObject[4];
		private GameObject[] piece2 = new GameObject[4];
		private GameObject[] piece3 = new GameObject[4];
		private SpriteRenderer myRenderer;
		private int goalin0 = 4, goalin1 = 4, goalin2 = 4, goalin3 = 4;
		public Sprite piece0_sp, piece1_sp, piece2_sp, piece3_sp;



		// Use this for initialization
		void Start ()
		{

				init_piece ();

				piece_off_0 (4);
				piece_off_1 (4);
				piece_off_2 (4);
				piece_off_3 (4);
				goalin0 = 0;
				goalin1 = 0;
				goalin2 = 0;
				goalin3 = 0;
	
		}

		public void init_piece ()
		{
				for (int i=0; i<4; i++) {
						piece0 [i] = GameObject.Find ("CharBoxPiece_0_" + i);
						piece1 [i] = GameObject.Find ("CharBoxPiece_1_" + i);
						piece2 [i] = GameObject.Find ("CharBoxPiece_2_" + i);
						piece3 [i] = GameObject.Find ("CharBoxPiece_3_" + i);
				}
		}

		void piece_on_0 (int num)//몇개 키나
		{
				if (goalin0 + num > 4) {
						Debug.Log ("0번 끝남");
				} else {
						for (int i=0; i<num; i++) {
								int temp = goalin0 + i;
				piece0[temp].gameObject.GetComponent<SpriteRenderer> ().sprite = piece0_sp;
						}
				}

		}

		void piece_on_1 (int num)//몇개 키나
		{
				if (goalin1 + num > 4) {
						Debug.Log ("1번 끝남");
				} else {
						for (int i=0; i<num; i++) {
				int temp = goalin1 + i;
				piece1[temp].gameObject.GetComponent<SpriteRenderer> ().sprite = piece1_sp;
						}
				}
		
		}

		void piece_on_2 (int num)//몇개 키나
		{
				if (goalin2 + num > 4) {
						Debug.Log ("2번 끝남");
				} else {
						for (int i=0; i<num; i++) {
								int temp = goalin2 + i;
				piece2[temp].gameObject.GetComponent<SpriteRenderer> ().sprite = piece2_sp;
						}
				}
		
		}

		void piece_on_3 (int num)//몇개 키나
		{
				if (goalin3 + num > 4) {
						Debug.Log ("2번 끝남");
				} else {
						for (int i=0; i<num; i++) {
								int temp = goalin3 + i;
				piece3[temp].gameObject.GetComponent<SpriteRenderer> ().sprite = piece3_sp;
						}
				}
		
		}

		void piece_off_0 (int num)
		{

				for (int i= goalin0; i>(goalin0 - num); i--) {
						piece0[i-1].gameObject.GetComponent<SpriteRenderer> ().sprite = null;
				}
		}

		void piece_off_1 (int num)
		{
		
				for (int i= goalin1; i>(goalin1 - num); i--) {
			piece1[i-1].gameObject.GetComponent<SpriteRenderer> ().sprite = null;
				}
		}

		void piece_off_2 (int num)
		{
		
				for (int i= goalin2; i>(goalin2 - num); i--) {
			piece2[i-1].gameObject.GetComponent<SpriteRenderer> ().sprite = null;
				}
		}
	
		void piece_off_3 (int num)
		{
		
				for (int i= goalin3; i>(goalin3 - num); i--) {
			piece3[i-1].gameObject.GetComponent<SpriteRenderer> ().sprite = null;
				}
		}



	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
