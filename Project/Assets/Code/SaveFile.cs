using System.IO;
using UnityEngine;
using System.Linq;
public class SaveFile : MonoBehaviour{
	public static string path = $"{Application.dataPath}/Save.json";
	public static bool loading;
	[System.Serializable]
	public struct Structure{
		public string[] itemTypes;
		public int[] itemQuantities;
		public Entity[] team;
		public Vector3 playerPosition;
	}
	public void Update(){
		if(!SaveFile.loading){return;}
		this.Load();
		SaveFile.loading = this.enabled = false;
	}
	public void Save(){
		var player = GameObject.Find("Player");
		var structure = new Structure();
		structure.itemTypes = Inventory.main?.items.Keys.ToArray();
		structure.itemQuantities = Inventory.main?.items.Values.ToArray();
		structure.team = Team.main?.members;
		structure.playerPosition = player.GetComponent<Transform>().position;
		File.WriteAllText(SaveFile.path,JsonUtility.ToJson(structure,true));
	}
	public void Load(){
		if(!File.Exists(SaveFile.path)){return;}
		var player = GameObject.Find("Player");
		var json = File.ReadAllText(SaveFile.path);
		var structure = JsonUtility.FromJson<Structure>(json);
		if(Inventory.main != null){
			for(var index = 0;index < structure.itemTypes.Length;index += 1){
				Inventory.main.items[structure.itemTypes[index]] = structure.itemQuantities[index];
			}
		}
		if(Team.main != null){Team.main.members = structure.team;}
		if(player != null){player.GetComponent<Transform>().position = structure.playerPosition;}
	}
}
