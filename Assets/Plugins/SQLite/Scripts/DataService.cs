using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
       
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);
            while (!loadDb.isDone) { } 
            
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;
                
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;
               
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;
		
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}

	public void CreateDB(){
		_connection.DropTable<AnatomicalStructures> ();
		_connection.DropTable<Descriptions> ();
		_connection.DropTable<Relations> ();
		_connection.DropTable<Models_3D> ();
		_connection.CreateTable<AnatomicalStructures> ();
		_connection.CreateTable<Descriptions> ();
		_connection.CreateTable<Relations> ();
		_connection.CreateTable<Models_3D> ();

		_connection.Insert(new AnatomicalStructures{
    		id = 1,
    		german_name = "Eckzahn",
    		latin_name = "latinEckzahn",
    		category = "Mund",
			parentId = 3	
		});

		_connection.Insert(new Descriptions{
    		id = 1,
    		text = "Ein schöner Zahn",
    		structure_id = 1
		});

		_connection.Insert(new Relations{
    		id = 1,
    		structure1_id = 1,
    		structure2_id = 1,
    		relation_type = "neben dem Zahn"
		});

		_connection.Insert(new Models_3D{
    		id = 1,
    		model_path = "AnatoModels/Test4MuscleSim",
    		structure_id = 1,
    		highlight_color = "white"
		});

		
	} 
	

	public IEnumerable<AnatomicalStructures> GetAnatomicalStructures(){
		return _connection.Table<AnatomicalStructures>();
	}
    public IEnumerable<AnatomicalStructures> GetSearchedModel(string searchText)
    {
        return _connection.Table<AnatomicalStructures>().Where(x => x.german_name == searchText);

    }

    public IEnumerable<AnatomicalStructures> GetLiveSearchedModel(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            return new List<AnatomicalStructures>();
        }

        return _connection.Table<AnatomicalStructures>()
            .Where(x => x.german_name != null && x.german_name.Contains(searchText))
            .OrderBy(x => !x.german_name.StartsWith(searchText))
            .ThenBy(x => x.german_name);
    }


    public IEnumerable<Models_3D> GetModels_3D(){
		return _connection.Table<Models_3D>();
	}

	public IEnumerable<Descriptions> GetDescriptions(){
		return _connection.Table<Descriptions>();
	}
	public IEnumerable<Relations> GetRelations(){
		return _connection.Table<Relations>();
	}

	//public IEnumerable<Person> GetPersonsNamedRoberto(){
	// 	return _connection.Table<Person>().Where(x => x.Name == "Roberto");
	//}

	//public Person GetJohnny(){
	//	return _connection.Table<Person>().Where(x => x.Name == "Johnny").FirstOrDefault();
	//}

	/* public Person CreatePerson(){
		var p = new Person{
				Name = "Johnny",
				Surname = "Mnemonic",
				Age = 21
		};
		_connection.Insert (p);
		return p;
	} */
}
