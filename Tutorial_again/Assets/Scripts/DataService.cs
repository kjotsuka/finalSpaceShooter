/*using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName)
    {

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}

    public void CreateDB()
    {
        _connection.DropTable<Person>();
        _connection.CreateTable<Person>();
    }
    /*
		_connection.InsertAll (new[]{
    new HighScores{
        PlayerID = 1,
        Username = "pp",
        Score = 1200,
        Level =1
        },

        new HighScores{s
        PlayerID = 2,
        Username = "bb",
        Score = 1500,
        Level =1
        },

        new HighScores{
        PlayerID = 3,
        Username = "daddy",
        Score = 13000,
        Level =1
        },

        new HighScores{
        PlayerID = 4,
        Username = "wow",
        Score = 2500,
        Level =1
},
        });
	}

	public IEnumerable<HighScores> GetPersons(){
		return _connection.Table<HighScores>();
	}

	public IEnumerable<HighScores> GetPersonsNamedRoberto(){
		return _connection.Table<HighScores>().Where(x => x.Username == "daddy");
	}

	public Person GetJohnny(){
		return _connection.Table<HighScores>().Where(x => x.Username == "bb").FirstOrDefault();
	}

	public Person CreatePerson(){
		var p = new HighScores{
				Username = "Johnny",
				Score = 1,
				Level = 21
		};
		_connection.Insert (p);
		return p;
	}


*/

//}

