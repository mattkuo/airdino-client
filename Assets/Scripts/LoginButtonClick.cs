using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoginButtonClick : MonoBehaviour {
	IFirebase firebase;

	// Use this for initialization
	void Start () {
//		firebase = Firebase.CreateNew ("https://airdino.firebaseio.com");
//
//
//
//		IFirebase usersRef = firebase.Push ();

//		Dictionary<string, object> dictionary = new Dictionary<string, object> ();
//		dictionary.Add ("id", 0);
//
//		usersRef.SetValue (dictionary);

//		firebase.ChildAdded += (object sender, ChangedEventArgs e) => {
//			Debug.Log("HIT");
//		};

//		usersRef.ChildChanged += (object sender, ChangedEventArgs e) => {
//			Debug.Log("HIAKSDKF");
//		};
//
//		usersRef.ValueUpdated += (object sender, ChangedEventArgs e) => {
//			Debug.Log("HIT");
//			Debug.Log(e.DataSnapshot.Key);
//			Dictionary<string, object> dict = e.DataSnapshot.DictionaryValue;
//
//			foreach(KeyValuePair<string, object> entry in dict) {
//				Debug.Log("HIT");
//				Debug.LogFormat("String: {0} Object: {1}", entry.Key, entry.Value);
//			}
//		};
//			
//		usersRef.ChildAdded += (object sender, ChangedEventArgs e) => {
//			Debug.Log("HIT@");
//			Debug.Log (e.DataSnapshot.Key);
//		};
//
//		firebase.ChildChanged += (object sender, ChangedEventArgs e) => {
//			Debug.Log("HIAKSDKF");
//		};
//
//		firebase.ValueUpdated += (object sender, ChangedEventArgs e) => {
//			Debug.Log("HIT");
//			Debug.Log(e.DataSnapshot.Key);
//			Dictionary<string, object> dict = e.DataSnapshot.DictionaryValue;
//
//			foreach(KeyValuePair<string, object> entry in dict) {
//				Debug.Log("HIT");
//				Debug.LogFormat("String: {0} Object: {1}", entry.Key, entry.Value);
//			}
//		};
//
//		firebase.ChildAdded += (object sender, ChangedEventArgs e) => {
//			Debug.Log("HIT@");
//			Debug.Log (e.DataSnapshot.Key);
//		};

		//firebase.SetValue ("working?");
	}

	public void onClick () {

	}

}
