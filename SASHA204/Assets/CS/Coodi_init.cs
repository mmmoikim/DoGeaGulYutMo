using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coodi_init : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		manage_static.pan_array = new List<List<Vector3>> ();

		
		List<Vector3> temp0 = new List<Vector3>();
		
		temp0.Add(new Vector3((float)6.2, (float)-3.3, (float)-0.5));//0,0
		temp0.Add(new Vector3((float)6.9, (float)-3.3, (float)-0.4));//0,1
		temp0.Add(new Vector3((float)7.6, (float)-3.3, (float)-0.3));//0,2
		temp0.Add(new Vector3((float)8.3, (float)-3.3, (float)-0.2));//0,3
		temp0.Add(new Vector3((float)-0.1751623, (float)-6.647194, (float)-0.2));//0,4
		
		manage_static.pan_array.Add (temp0);
		List<Vector3> temp1 = new List<Vector3>();
		
		temp1.Add(new Vector3((float)4.344436, (float)-1.913014, (float)-0.5));//1,0
		temp1.Add(new Vector3((float)4.025804, (float)-0.526027, (float)-0.5));//1,1
		temp1.Add(new Vector3((float)3.688428, (float)0.6922728, (float)-0.5));//1,2
		temp1.Add(new Vector3((float)3.407282, (float)1.723141, (float)-0.5));//1,3
		temp1.Add(new Vector3((float)3.126136, (float)2.622809, (float)-0.5));//1,4


		manage_static.pan_array.Add (temp1);
		List<Vector3> temp2 = new List<Vector3>();

		temp2.Add(new Vector3((float)2.826246, (float)3.672421, (float)-0.5));//2,0
		temp2.Add(new Vector3((float)1.514231, (float)3.691163, (float)-0.5));//2,1
		temp2.Add(new Vector3((float)0.1647303, (float)3.691163, (float)-0.5));//2,2
		temp2.Add(new Vector3((float)-1.166027, (float)3.691163, (float)-0.5));//2,3
		temp2.Add(new Vector3((float)-2.553018, (float)3.691163, (float)-0.5));//2,4
		
		manage_static.pan_array.Add (temp2);
		List<Vector3> temp3 = new List<Vector3>();

		temp3.Add(new Vector3((float)-3.902523, (float)3.634934, (float)-0.5));//3,0
		temp3.Add(new Vector3((float)-4.164926, (float)2.604064, (float)-0.5));//3,1
		temp3.Add(new Vector3((float)-4.408585, (float)1.760626, (float)-0.5));//3,3
		temp3.Add(new Vector3((float)-4.689731, (float)0.6735287, (float)-0.5));//3,4
		temp3.Add(new Vector3((float)-5.027106, (float)-0.5635141, (float)-0.5));//3,5

		manage_static.pan_array.Add (temp3);
		List<Vector3> temp4 = new List<Vector3>();

		temp4.Add(new Vector3((float)-5.383224, (float)-1.950501, (float)-0.5));//4,0
		temp4.Add(new Vector3((float)-3.415204, (float)-1.987987, (float)-0.5));//4,1
		temp4.Add(new Vector3((float)-1.484671, (float)-1.987987, (float)-0.5));//4,2
		temp4.Add(new Vector3((float)0.4458658, (float)-1.987987, (float)-0.5));//4,3
		temp4.Add(new Vector3((float)2.376401, (float)-1.987987, (float)-0.5));//4,4

		manage_static.pan_array.Add (temp4);
		List<Vector3> temp5 = new List<Vector3>();

		temp5.Add(new Vector3((float)1.851595, (float)2.885211, (float)-0.5));//5,0
		temp5.Add(new Vector3((float)0.7644972, (float)2.154231, (float)-0.5));//5,1
		temp5.Add(new Vector3((float)-0.5475179, (float)1.310793, (float)-0.5));//5,2
		temp5.Add(new Vector3((float)-1.990735, (float)0.3361538, (float)-0.5));//5,3
		temp5.Add(new Vector3((float)-3.583895, (float)-0.7322011, (float)-0.5));//5,4
		manage_static.pan_array.Add (temp5);
		List<Vector3> temp6 = new List<Vector3>();


		temp6.Add(new Vector3((float)-2.852915, (float)2.885211, (float)-0.5));//6,0
		temp6.Add(new Vector3((float)-1.765817, (float)2.15423, (float)-0.5));//6,1
		temp6.Add(new Vector3((float)-0.5100319, (float)1.329535, (float)-0.5));//6,2
		temp6.Add(new Vector3((float)0.9706707, (float)0.3174089, (float)-0.5));//6,3
		temp6.Add(new Vector3((float)2.563832, (float)-0.750946, (float)-0.5));//6,4

		manage_static.pan_array.Add (temp6);

		List<Vector3> temp7 = new List<Vector3>();
		
		
		temp7.Add(new Vector3((float)4.283606, (float)-3.69566, (float)-2));//7
		temp7.Add(new Vector3((float)4.283606, (float)-3.69566, (float)-2));
		temp7.Add(new Vector3((float)4.283606, (float)-3.69566, (float)-2));
		temp7.Add(new Vector3((float)4.283606, (float)-3.69566, (float)-2));
		temp7.Add(new Vector3((float)4.283606, (float)-3.69566, (float)-2));
		
		manage_static.pan_array.Add (temp7);

		List<Vector3> temp8 = new List<Vector3>();
		
		
		temp8.Add(new Vector3((float)9.981609, (float)-0.4860255, (float)-2));//8
		temp8.Add(new Vector3((float)9.981609, (float)-0.4860255, (float)-2));
		temp8.Add(new Vector3((float)9.981609, (float)-0.4860255, (float)-2));
		temp8.Add(new Vector3((float)9.981609, (float)-0.4860255, (float)-2));
		temp8.Add(new Vector3((float)9.981609, (float)-0.4860255, (float)-2));
		
		manage_static.pan_array.Add (temp8);




	
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
