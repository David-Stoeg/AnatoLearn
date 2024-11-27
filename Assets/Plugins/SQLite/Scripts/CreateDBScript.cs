using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateDBScript : MonoBehaviour {

	public Text DebugText;

	// Use this for initialization
	void Start () {
		StartSync();
	}

    private void StartSync()
    {
        var ds = new DataService("AnatoDb.db");
        ds.CreateDB();
        
        var AnatomicalStructures = ds.GetAnatomicalStructures ();
		var Relations = ds.GetRelations ();
		var Models_3D = ds.GetModels_3D ();
		var Descriptions = ds.GetDescriptions ();
        ToConsole (AnatomicalStructures);
		ToConsole (Relations);
		ToConsole (Models_3D);
		ToConsole (Descriptions);
    }
	
	private void ToConsole(IEnumerable<Models_3D> Models_3D){
		foreach (var model in Models_3D) {
			ToConsole(model.ToString());
		}
	}
		private void ToConsole(IEnumerable<AnatomicalStructures> AnatomicalStructures){
		foreach (var structure in AnatomicalStructures) {
			ToConsole(structure.ToString());
		}
	}
		private void ToConsole(IEnumerable<Descriptions> Descriptions){
		foreach (var description in Descriptions) {
			ToConsole(description.ToString());
		}
	}
		private void ToConsole(IEnumerable<Relations> Relations){
		foreach (var relation in Relations) {
			ToConsole(relation.ToString());
		}
	}
	
	private void ToConsole(string msg){
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}
}
