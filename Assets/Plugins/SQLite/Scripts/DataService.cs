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

	}

    public void CreateDB()
    {
        _connection.DropTable<AnatomicalStructures>();
        _connection.DropTable<Descriptions>();
        _connection.DropTable<Relations>();
        _connection.DropTable<Models_3D>();
        _connection.CreateTable<AnatomicalStructures>();
        _connection.CreateTable<Descriptions>();
        _connection.CreateTable<Relations>();
        _connection.CreateTable<Models_3D>();

        //Beckenmuskeln
        _connection.Insert(new AnatomicalStructures
        {
            id = 0,
            german_name = "Tiefer querer Dammmuskel (re.)",
            latin_name = "Musculus transversus perinei profundus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 1,
            german_name = "Tiefer querer Dammmuskel (li.)",
            latin_name = "Musculus transversus perinei profundus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 2,
            german_name = "Oberflächlicher querer Dammmuskel (re.)",
            latin_name = "Musculus transversus perinei superficialis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 3,
            german_name = "Oberflächlicher querer Dammmuskel (li.)",
            latin_name = "Musculus transversus perinei superficialis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 4,
            german_name = "Sitzbein Schwellkörper Muskel (re.)",
            latin_name = "Musculus ischiocavernosus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 5,
            german_name = "Sitzbein Schwellkörper Muskel (li.)",
            latin_name = "Musculus ischiocavernosus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 6,
            german_name = "Schwellkörpermuskel der Harnröhre (re.)",
            latin_name = "Musculus bulbospongiosus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 7,
            german_name = "Schwellkörpermuskel der Harnröhre (li.)",
            latin_name = "Musculus bulbospongiosus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 8,
            german_name = "Schambein-Mastdarm-Muskel (re.)",
            latin_name = "Musculus puborectalis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 9,
            german_name = "Schambein-Mastdarm-Muskel (li.)",
            latin_name = "Musculus puborectalis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 10,
            german_name = "Darmbein-Steißbein-Muskel (re.)",
            latin_name = "Musculus iliococcygeus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 11,
            german_name = "Darmbein-Steißbein-Muskel (li.)",
            latin_name = "Musculus iliococcygeus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 12,
            german_name = "Steißbeinmuskel (re.)",
            latin_name = "Musculus ischiococcygeus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 13,
            german_name = "Steißbeinmuskel (li.)",
            latin_name = "Musculus ischiococcygeus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 14,
            german_name = "Viereckiger Lendenmuskel (re.)",
            latin_name = "Musculus quadratus lumborum (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 15,
            german_name = "Viereckiger Lendenmuskel (li.)",
            latin_name = "Musculus quadratus lumborum (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 16,
            german_name = "Pyramidenmuskel (re.)",
            latin_name = "Musculus pyramidalis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 17,
            german_name = "Pyramidenmuskel (li.)",
            latin_name = "Musculus pyramidalis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 18,
            german_name = "Querer Bauchmuskel (re.)",
            latin_name = "Musculus transversus abdominis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 19,
            german_name = "Querer Bauchmuskel (li.)",
            latin_name = "Musculus transversus abdominis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 20,
            german_name = "Gerader Bauchmuskel (re.)",
            latin_name = "Musculus rectus abdominis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 21,
            german_name = "Gerader Bauchmuskel (li.)",
            latin_name = "Musculus rectus abdominis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        //Zwerchfell
        _connection.Insert(new AnatomicalStructures
        {
            id = 22,
            german_name = "Zwerchfell",
            latin_name = "Diaphragma thoracicum",
            category = "Zwerchfell",
            parentId = 0
        });

        //Beinmuskeln
        _connection.Insert(new AnatomicalStructures
        {
            id = 23,
            german_name = "Kurzer Schenkelanzieher (re.)",
            latin_name = "Musculus adductor brevis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 24,
            german_name = "Schlanker Muskel (re.)",
            latin_name = "Musculus gracilis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 25,
            german_name = "Kammmuskel (re.)",
            latin_name = "Musculus pectineus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 26,
            german_name = "Innerer Schenkelmuskel (re.)",
            latin_name = "Musculus vastus medialis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 27,
            german_name = "Mittlerer Schenkelmuskel (re.)",
            latin_name = "Musculus vastus intermedius (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 28,
            german_name = "Äußerer Schenkelmuskel (re.)",
            latin_name = "Musculus vastus lateralis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 29,
            german_name = "Musculus articularis genus (re.)",
            latin_name = "Musculus articularis genus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 30,
            german_name = "Langer Schenkelanzieher (re.)",
            latin_name = "Musculus adductor longus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 31,
            german_name = "Großer Schenkelanzieher (re.)",
            latin_name = "Musculus adductor magnus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 32,
            german_name = "Hüft-Lenden-Muskel (re.)",
            latin_name = "Musculus iliopsoae (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 33,
            german_name = "Darmbeinmuskel (re.)",
            latin_name = "Musculus iliacus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 34,
            german_name = "Großer Lendenmuskel (re.)",
            latin_name = "Musculus major psoae (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 35,
            german_name = "Kleiner Lendenmuskel (re.)",
            latin_name = "Musculus minor psoae (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 36,
            german_name = "Plattensehnenmuskel (re.)",
            latin_name = "Musculus semimembranosus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 37,
            german_name = "Zweiköpfiger Schenkelmuskel (re.)",
            latin_name = "Musculus biceps femoris (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 38,
            german_name = "Halbsehnenmuskel (re.)",
            latin_name = "Musculus semitendinosus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 39,
            german_name = "Oberer Zwillingsmuskel (re.)",
            latin_name = "Musculus gemellus superior (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 40,
            german_name = "Unterer Zwillingsmuskel (re.)",
            latin_name = "Musculus gemellus inferior (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 41,
            german_name = "Äußerer Hüftlochmuskel (re.)",
            latin_name = "Musculus obturatorius externus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 42,
            german_name = "Birnenförmiger Muskel (re.)",
            latin_name = "Musculus piriformis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 43,
            german_name = "Kleiner Gesäßmuskel (re.)",
            latin_name = "Musculus gluteus minimus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 44,
            german_name = "Innerer Hüftlochmuskel (re.)",
            latin_name = "Musculus obturatorius internus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 45,
            german_name = "Mittlerer Gesäßmuskel (re.)",
            latin_name = "Musculus gluteus medius (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 46,
            german_name = "Gerader Schenkelmuskel (re.)",
            latin_name = "Musculus rectus femoris (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 47,
            german_name = "Schneidermuskel (re.)",
            latin_name = "Musculus sartorius (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 48,
            german_name = "Großer Gesäßmuskel (re.)",
            latin_name = "Musculus gluteus maximus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 49,
            german_name = "Schenkelbindenspanner (re.)",
            latin_name = "Musculus tensor fasciae latae (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 50,
            german_name = "Vierseitiger Schenkelmuskel (re.)",
            latin_name = "Musculus quadratus femoris (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 51,
            german_name = "Kniekehlenmuskel (re.)",
            latin_name = "Musculus popliteus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 52,
            german_name = "Sohlenspanner (re.)",
            latin_name = "Musculus plantaris (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 53,
            german_name = "Hinterer Schienbeinmuskel (re.)",
            latin_name = "Musculus tibialis posterior (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 54,
            german_name = "Langer Großzehenstrecker (re.)",
            latin_name = "Musculus extensor hallucis longus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 55,
            german_name = "Kurzer Wadenbeinmuskel (re.)",
            latin_name = "Musculus fibularis brevis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 56,
            german_name = "Dritter Wadenbeinmuskel (re.)",
            latin_name = "Musculus fibularis tertius (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 57,
            german_name = "Langer Großzehenbeuger (re.)",
            latin_name = "Musculus flexor hallucis longus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 58,
            german_name = "Langer Zehenbeuger (re.)",
            latin_name = "Musculus flexor digitorum longus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 59,
            german_name = "Vorderer Schienbeinmuskel (re.)",
            latin_name = "Musculus tibialis anterior (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 60,
            german_name = "Langer Zehenstrecker (re.)",
            latin_name = "Musculus extensor digitorum longus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 61,
            german_name = "Langer Wadenbeinmuskel (re.)",
            latin_name = "Musculus fibularis longus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 62,
            german_name = "Schollenmuskel (re.)",
            latin_name = "Musculus soleus (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 63,
            german_name = "Zwillingswadenmuskel (re.)",
            latin_name = "Musculus gastrocnemius (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 64,
            german_name = "Kleinzehengegensteller (re.)",
            latin_name = "Musculus opponens digiti minimi pedis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 65,
            german_name = "Kleinzehenspreizer (re.)",
            latin_name = "Musculus abductor digiti minimi pedis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 66,
            german_name = "Kurzer Kleinzehenbeuger (re.)",
            latin_name = "Musculus flexor digiti minimi brevis pedis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 67,
            german_name = "Kurzer Schenkelanzieher (li.)",
            latin_name = "Musculus adductor brevis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 68,
            german_name = "Schlanker Muskel (li.)",
            latin_name = "Musculus gracilis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 69,
            german_name = "Kammmuskel (li.)",
            latin_name = "Musculus pectineus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 70,
            german_name = "Innerer Schenkelmuskel (li.)",
            latin_name = "Musculus vastus medialis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 71,
            german_name = "Mittlerer Schenkelmuskel (li.)",
            latin_name = "Musculus vastus intermedius (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 72,
            german_name = "Äußerer Schenkelmuskel (li.)",
            latin_name = "Musculus vastus lateralis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 73,
            german_name = "Musculus articularis genus (li.)",
            latin_name = "Musculus articularis genus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 74,
            german_name = "Langer Schenkelanzieher (li.)",
            latin_name = "Musculus adductor longus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 75,
            german_name = "Großer Schenkelanzieher (li.)",
            latin_name = "Musculus adductor magnus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 76,
            german_name = "Hüft-Lenden-Muskel (li.)",
            latin_name = "Musculus iliopsoae (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 77,
            german_name = "Darmbeinmuskel (sin.)",
            latin_name = "Musculus iliacus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 78,
            german_name = "Großer Lendenmuskel (li.)",
            latin_name = "Musculus major psoae (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 79,
            german_name = "Kleiner Lendenmuskel (li.)",
            latin_name = "Musculus minor psoae (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 80,
            german_name = "Plattensehnenmuskel (li.)",
            latin_name = "Musculus semimembranosus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 81,
            german_name = "Zweiköpfiger Schenkelmuskel (li.)",
            latin_name = "Musculus biceps femoris (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 82,
            german_name = "Halbsehnenmuskel (li.)",
            latin_name = "Musculus semitendinosus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 83,
            german_name = "Oberer Zwillingsmuskel (li.)",
            latin_name = "Musculus gemellus superior (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 84,
            german_name = "Unterer Zwillingsmuskel (li.)",
            latin_name = "Musculus gemellus inferior (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 85,
            german_name = "Äußerer Hüftlochmuskel (li.)",
            latin_name = "Musculus obturatorius externus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 86,
            german_name = "Birnenförmiger Muskel (li.)",
            latin_name = "Musculus piriformis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 87,
            german_name = "Kleiner Gesäßmuskel (li.)",
            latin_name = "Musculus gluteus minimus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 88,
            german_name = "Innerer Hüftlochmuskel (li.)",
            latin_name = "Musculus obturatorius internus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 89,
            german_name = "Mittlerer Gesäßmuskel (li.)",
            latin_name = "Musculus gluteus medius (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 90,
            german_name = "Gerader Schenkelmuskel (li.)",
            latin_name = "Musculus rectus femoris (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 91,
            german_name = "Schneidermuskel (li.)",
            latin_name = "Musculus sartorius (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 92,
            german_name = "Großer Gesäßmuskel (li.)",
            latin_name = "Musculus gluteus maximus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 93,
            german_name = "Schenkelbindenspanner (li.)",
            latin_name = "Musculus tensor fasciae latae (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 94,
            german_name = "Vierseitiger Schenkelmuskel (li.)",
            latin_name = "Musculus quadratus femoris (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 95,
            german_name = "Kniekehlenmuskel (li.)",
            latin_name = "Musculus popliteus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 96,
            german_name = "Sohlenspanner (li.)",
            latin_name = "Musculus plantaris (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 97,
            german_name = "Hinterer Schienbeinmuskel (li.)",
            latin_name = "Musculus tibialis posterior (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 98,
            german_name = "Langer Großzehenstrecker (li.)",
            latin_name = "Musculus extensor hallucis longus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 99,
            german_name = "Kurzer Wadenbeinmuskel (li.)",
            latin_name = "Musculus fibularis brevis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 100,
            german_name = "Dritter Wadenbeinmuskel (li.)",
            latin_name = "Musculus fibularis tertius (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 101,
            german_name = "Langer Großzehenbeuger (li.)",
            latin_name = "Musculus flexor hallucis longus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 102,
            german_name = "Langer Zehenbeuger (li.)",
            latin_name = "Musculus flexor digitorum longus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 103,
            german_name = "Vorderer Schienbeinmuskel (li.)",
            latin_name = "Musculus tibialis anterior (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 104,
            german_name = "Langer Zehenstrecker (li.)",
            latin_name = "Musculus extensor digitorum longus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 105,
            german_name = "Langer Wadenbeinmuskel (li.)",
            latin_name = "Musculus fibularis longus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 106,
            german_name = "Schollenmuskel (li.)",
            latin_name = "Musculus soleus (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 107,
            german_name = "Zwillingswadenmuskel (li.)",
            latin_name = "Musculus gastrocnemius (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 108,
            german_name = "Kleinzehengegensteller (li.)",
            latin_name = "Musculus opponens digiti minimi pedis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 109,
            german_name = "Kleinzehenspreizer (li.)",
            latin_name = "Musculus abductor digiti minimi pedis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 110,
            german_name = "Kurzer Kleinzehenbeuger (li.)",
            latin_name = "Musculus flexor digiti minimi brevis pedis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 111,
            german_name = "Rückseitige Zwischenknochenmuskeln des Fußes (re.)",
            latin_name = "Musculi interossei dorsales pedis (dex.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 112,
            german_name = "Rückseitige Zwischenknochenmuskeln des Fußes (li.)",
            latin_name = "Musculi interossei dorsales pedis (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 113,
            german_name = "Langer Kopf des Bizeps (li.)",
            latin_name = "Musculus biceps brachii (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 114,
            german_name = "Langer Kopf des Bizeps (re.)",
            latin_name = "Musculus biceps brachii (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 115,
            german_name = "Rabenschnabelmuskel (li.)",
            latin_name = "Musculus coracobrachialis (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 116,
            german_name = "Rabenschnabelmuskel (re.)",
            latin_name = "Musculus coracobrachialis (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 117,
            german_name = "Deltamuskel (li.)",
            latin_name = "Musculus deltoideus (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 118,
            german_name = "Deltamuskel (re.)",
            latin_name = "Musculus deltoideus (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 119,
            german_name = "Untergrätenmuskel (li.)",
            latin_name = "Musculus infraspinatus (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 120,
            german_name = "Untergrätenmuskel (re.)",
            latin_name = "Musculus infraspinatus (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 121,
            german_name = "Unterschulterblattmuskel (li.)",
            latin_name = "Musculus subscapularis (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 122,
            german_name = "Unterschulterblattmuskel (re.)",
            latin_name = "Musculus subscapularis (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 123,
            german_name = "Obergrätenmuskel (li.)",
            latin_name = "Musculus supraspinatus (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 124,
            german_name = "Obergrätenmuskel (re.)",
            latin_name = "Musculus supraspinatus (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 125,
            german_name = "Großer Rundmuskel (li.)",
            latin_name = "Musculus teres major (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 126,
            german_name = "Großer Rundmuskel (re.)",
            latin_name = "Musculus teres major (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 127,
            german_name = "Kleiner Rundmuskel (li.)",
            latin_name = "Musculus teres minor (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 128,
            german_name = "Kleiner Rundmuskel (re.)",
            latin_name = "Musculus teres minor (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 129,
            german_name = "Langer Kopf des Trizeps (li.)",
            latin_name = "Musculus triceps brachii (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 130,
            german_name = "Langer Kopf des Trizeps (re.)",
            latin_name = "Musculus triceps brachii (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 131,
            german_name = "Armbeuger (li.)",
            latin_name = "Musculus brachialis (sin.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 132,
            german_name = "Armbeuger (re.)",
            latin_name = "Musculus brachialis (dex.)",
            category = "Schulter + Oberarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 133,
            german_name = "Ellenbogenmuskel (li.)",
            latin_name = "Musculus anconeus (sin.)",
            category = "Armmitte",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 134,
            german_name = "Ellenbogenmuskel (re.)",
            latin_name = "Musculus anconeus (dex.)",
            category = "Armmitte",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 135,
            german_name = "Oberarmspeichenmuskel (li.)",
            latin_name = "Musculus brachioradialis (sin.)",
            category = "Armmitte",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 136,
            german_name = "Oberarmspeichenmuskel (re.)",
            latin_name = "Musculus brachioradialis (dex.)",
            category = "Armmitte",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 137,
            german_name = "Runder Einwärtsdreher (li.)",
            latin_name = "Musculus pronator teres (sin.)",
            category = "Armmitte",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 138,
            german_name = "Runder Einwärtsdreher (re.)",
            latin_name = "Musculus pronator teres (dex.)",
            category = "Armmitte",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 139,
            german_name = "Auswärtsdreher (li.)",
            latin_name = "Musculus supinator (sin.)",
            category = "Armmitte",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 140,
            german_name = "Auswärtsdreher (re.)",
            latin_name = "Musculus supinator (dex.)",
            category = "Armmitte",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 141,
            german_name = "Kurzer speichenseitiger Handstrecker (sin.)",
            latin_name = "Musculus extensor carpi radialis brevis (sin.)",
            category = "Unterarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 142,
            german_name = "Kurzer speichenseitiger Handstrecker (dex.)",
            latin_name = "Musculus extensor carpi radialis brevis (dex.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 143,
            german_name = "Langer speichenseitiger Handstrecker (sin.)",
            latin_name = "Musculus extensor carpi radialis longus  (sin.)",
            category = "Unterarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 144,
            german_name = "Langer speichenseitiger Handstrecker (dex.)",
            latin_name = "Musculus extensor carpi radialis longus (dex.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 145,
            german_name = "Ellenseitiger Handstrecker (sin.)",
            latin_name = "Musculus extensor carpi ulnaris (sin.)",
            category = "Unterarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 146,
            german_name = "Ellenseitiger Handstrecker (dex.)",
            latin_name = "Musculus extensor carpi ulnaris (dex.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 147,
            german_name = "Kleinfingerstrecker (sin.)",
            latin_name = "Musculus extensor digiti minimi (sin.)",
            category = "Unterarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 148,
            german_name = "Kleinfingerstrecker (dex.)",
            latin_name = "Musculus extensor digiti minimi (dex.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 149,
            german_name = "Speichenseitiger Handbeuger (sin.)",
            latin_name = "Musculus flexor carpi radialis (sin.)",
            category = "Unterarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 150,
            german_name = "Speichenseitiger Handbeuger (dex.)",
            latin_name = "Musculus flexor carpi radialis (dex.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 151,
            german_name = "Ellenseitiger Handbeuger (sin.)",
            latin_name = "Musculus flexor carpi ulnaris (sin.)",
            category = "Unterarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 152,
            german_name = "Ellenseitiger Handbeuger (dex.)",
            latin_name = "Musculus flexor carpi ulnaris (dex.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 153,
            german_name = "Langer Daumenbeuger (sin.)",
            latin_name = "Musculus flexor pollicis longus (sin.)",
            category = "Unterarm",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 154,
            german_name = "Langer Daumenbeuger (dex.)",
            latin_name = "Musculus flexor pollicis longus (dex.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 155,
            german_name = "Lenden-Rippenmuskel (sin.)",
            latin_name = "Musculus iliocostalis lumborum (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 156,
            german_name = "Lenden-Rippenmuskel (dex.)",
            latin_name = "Musculus iliocostalis lumborum (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 157,
            german_name = "Zwischenwirbelmuskeln der Lendenwirbelsäule (sin.)",
            latin_name = "Musculi interspinales lumborum (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 158,
            german_name = "Zwischenwirbelmuskeln der Lendenwirbelsäule (dex.)",
            latin_name = "Musculi interspinales lumborum (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 159,
            german_name = "Seitliche Zwischenquerfortsatzmuskeln (sin.)",
            latin_name = "Musculi intertransversarii laterales lumborum (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 160,
            german_name = "Seitliche Zwischenquerfortsatzmuskeln (dex.)",
            latin_name = "Musculi intertransversarii laterales lumborum (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 161,
            german_name = "Rippenheber (sin.)",
            latin_name = "Musculi levatores costarum (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 162,
            german_name = "Rippenheber (dex.)",
            latin_name = "Musculi levatores costarum (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 163,
            german_name = "Langer Rückenmuskel (sin.)",
            latin_name = "Musculus longissimus thoracis (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 164,
            german_name = "Langer Rückenmuskel (dex.)",
            latin_name = "Musculus longissimus thoracis (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 165,
            german_name = "Vielgefiederter Muskel (sin.)",
            latin_name = "Musculus multifidus (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 166,
            german_name = "Vielgefiederter Muskel (dex.)",
            latin_name = "Musculus multifidus (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 167,
            german_name = "Unterer schräger Kopfmuskel (sin.)",
            latin_name = "Musculus obliquus inferior capitis (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 168,
            german_name = "Unterer schräger Kopfmuskel (dex.)",
            latin_name = "Musculus obliquus inferior capitis (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 169,
            german_name = "Oberer schräger Kopfmuskel (sin.)",
            latin_name = "Musculus obliquus superior capitis (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 170,
            german_name = "Oberer schräger Kopfmuskel (dex.)",
            latin_name = "Musculus obliquus superior capitis (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 171,
            german_name = "Drehmuskeln (sin.)",
            latin_name = "Musculi rotatores (thoracis breves + longi) (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 172,
            german_name = "Drehmuskeln (dex.)",
            latin_name = "Musculi rotatores (thoracis breves + longi) (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 173,
            german_name = "Halbdornmuskel des Thorax (sin.)",
            latin_name = "Musculus semispinalis thoracis (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 174,
            german_name = "Halbdornmuskel des Thorax (dex.)",
            latin_name = "Musculus semispinalis thoracis (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 175,
            german_name = "Dornmuskel (sin.)",
            latin_name = "Musculus spinalis thoracis (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 176,
            german_name = "Dornmuskel (dex.)",
            latin_name = "Musculus spinalis thoracis (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 177,
            german_name = "Riemenmuskel des Halses (sin.)",
            latin_name = "Musculus splenius cervicis (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 178,
            german_name = "Riemenmuskel des Halses (dex.)",
            latin_name = "Musculus splenius cervicis (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 179,
            german_name = "Oberer hinterer Sägemuskel (sin.)",
            latin_name = "Musculus serratus posterior superior (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 180,
            german_name = "Oberer hinterer Sägemuskel (dex.)",
            latin_name = "Musculus serratus posterior superior (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 181,
            german_name = "Unterer hinterer Sägemuskel (sin.)",
            latin_name = "Musculus serratus posterior inferior (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 182,
            german_name = "Unterer hinterer Sägemuskel (dex.)",
            latin_name = "Musculus serratus posterior inferior (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 183,
            german_name = "Breiter Rückenmuskel (sin.)",
            latin_name = "Musculus latissimus dorsi (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 184,
            german_name = "Breiter Rückenmuskel (dex.)",
            latin_name = "Musculus latissimus dorsi (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 185,
            german_name = "Kleiner Rautenmuskel (sin.)",
            latin_name = "Musculus rhomboideus minor (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 186,
            german_name = "Kleiner Rautenmuskel (dex.)",
            latin_name = "Musculus rhomboideus minor (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 187,
            german_name = "Großer Rautenmuskel (sin.)",
            latin_name = "Musculus rhomboideus major (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 188,
            german_name = "Großer Rautenmuskel (dex.)",
            latin_name = "Musculus rhomboideus major (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 189,
            german_name = "Kapuzenmuskel (sin.)",
            latin_name = "Musculus trapezius (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 190,
            german_name = "Kapuzenmuskel (dex.)",
            latin_name = "Musculus trapezius (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 191,
            german_name = "Zwischenwirbelmuskeln der Brustwirbelsäule (sin.)",
            latin_name = "Musculi interspinales thoracis (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 192,
            german_name = "Zwischenwirbelmuskeln der Brustwirbelsäule (dex.)",
            latin_name = "Musculi interspinales thoracis (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 193,
            german_name = "Zwischenquerfortsatzmuskeln der Brustwirbelsäule (sin.)",
            latin_name = "Musculi intertransversarii thoracis (sin.)",
            category = "Torso Rücken",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 194,
            german_name = "Zwischenquerfortsatzmuskeln der Brustwirbelsäule (dex.)",
            latin_name = "Musculi intertransversarii thoracis (dex.)",
            category = "Torso Rücken",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 195,
            german_name = "Schambein-Steißbein-Muskel (re.)",
            latin_name = "Musculus pubococcygeus (dex.)",
            category = "Beckenboden",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 196,
            german_name = "Schambein-Steißbein-Muskel (li.)",
            latin_name = "Musculus pubococcygeus (sin.)",
            category = "Beckenboden",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 197,
            german_name = "Langer Daumenabzieher-Muskel (re.)",
            latin_name = "Musculus abductor pollicis longus (dex.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 198,
            german_name = "Langer Daumenabzieher-Muskel (li.)",
            latin_name = "Musculus abductor pollicis longus (sin.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 199,
            german_name = "Zeigefingerstrecker-Muskel (re.)",
            latin_name = "Musculus extensor indicis (dex.)",
            category = "Unterarmmuskulatur",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 200,
            german_name = "Zeigefingerstrecker-Muskel (li.)",
            latin_name = "Musculus extensor indicis (sin.)",
            category = "Unterarmmuskulatur",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 201,
            german_name = "Palmaris longus-Muskel (li.)",
            latin_name = "Musculus palmaris longus (sin.)",
            category = "Unterarm",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 202,
            german_name = "Palmaris longus-Muskel (re.)",
            latin_name = "Musculus palmaris longus (dex.)",
            category = "Unterarm",
            parentId = 0
        });
        //Descriptions Becken

        _connection.Insert(new Descriptions
        {
            id = 0,
            ansatz = "Sitzbeinast und Unterer Ast des Schambeins (Innenflächen)",
            innervation = "Dammnerv (re.) S1-S4",
            funktion = "Unterstützung des Beckenbodens und der Organe; Stabilisation des Damms",
            structure_id = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 1,
            ansatz = "Sitzbeinast und Unterer Ast des Schambeins (Innenflächen)",
            innervation = "Dammnerv (li.) S1-S4",
            funktion = "Unterstützung des Beckenbodens und der Organe; Stabilisation des Damms",
            structure_id = 1
        });

        _connection.Insert(new Descriptions
        {
            id = 2,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes (Innenfläche)",
            innervation = "Dammnerv (re.) S1-S4",
            funktion = "Unterstützung des Damms, Stabilisation der Beckenbodenregion",
            structure_id = 2
        });

        _connection.Insert(new Descriptions
        {
            id = 3,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes (Innenfläche)",
            innervation = "Dammnerv (li.) S1-S4",
            funktion = "Unterstützung des Damms, Stabilisation der Beckenbodenregion",
            structure_id = 3
        });

        _connection.Insert(new Descriptions
        {
            id = 4,
            ansatz = "Becken - Sitzbeinast (Innenfläche)",
            innervation = "Schamnerv (re.) S2-S4",
            funktion = "Stabilisation der Genitalregion, Erhöhung des Beckenbodendrucks",
            structure_id = 4
        });

        _connection.Insert(new Descriptions
        {
            id = 5,
            ansatz = "Becken - Sitzbeinast (Innenfläche)",
            innervation = "Schamnerv (li.) S2-S4",
            funktion = "Stabilisation der Genitalregion, Erhöhung des Beckenbodendrucks",
            structure_id = 5
        });

        _connection.Insert(new Descriptions
        {
            id = 6,
            ansatz = "Dammkörper",
            innervation = "Schamnerv (re.) S2-S4",
            funktion = "Unterstützung der Harnröhrenkontrolle, Stabilisierung der Genitalregion",
            structure_id = 6
        });

        _connection.Insert(new Descriptions
        {
            id = 7,
            ansatz = "Dammkörper",
            innervation = "Schamnerv (li.) S2-S4",
            funktion = "Unterstützung der Harnröhrenkontrolle, Stabilisierung der Genitalregion",
            structure_id = 7
        });

        _connection.Insert(new Descriptions
        {
            id = 8,
            ansatz = "Becken - Sitzbein-Schambein-Ast (Innenfläche)",
            innervation = "Äste des Kreuzbeinnervengeflechts (S4)",
            funktion = "Unterstützung der Darmschließmuskulatur, Stabilisierung des Enddarms",
            structure_id = 8
        });

        _connection.Insert(new Descriptions
        {
            id = 9,
            ansatz = "Becken - Sitzbein-Schambein-Ast (Innenfläche)",
            innervation = "Äste des Kreuzbeinnervengeflechts (S4)",
            funktion = "Unterstützung der Darmschließmuskulatur, Stabilisierung des Enddarms",
            structure_id = 9
        });

        _connection.Insert(new Descriptions
        {
            id = 10,
            ansatz = "Becken - Sitzbeinstachel (Innenfläche)",
            innervation = "Äste des Kreuzbeinnervengeflechts (S4)",
            funktion = "Stabilisierung des Beckenbodens und des Steißbeins",
            structure_id = 10
        });

        _connection.Insert(new Descriptions
        {
            id = 11,
            ansatz = "Becken - Sitzbeinstachel (Innenfläche)",
            innervation = "Äste des Kreuzbeinnervengeflechts (S4)",
            funktion = "Stabilisierung des Beckenbodens und des Steißbeins",
            structure_id = 11
        });

        _connection.Insert(new Descriptions
        {
            id = 12,
            ansatz = "Wirbelsäule - Apex ossis sacri, Steißbein",
            innervation = "Äste des Kreuzbeinnervengeflechts (S4-S5)",
            funktion = "Stabilisierung des Steißbeins und des Beckenbodens",
            structure_id = 12
        });

        _connection.Insert(new Descriptions
        {
            id = 13,
            ansatz = "Wirbelsäule - Apex ossis sacri, Steißbein",
            innervation = "Äste des Kreuzbeinnervengeflechts (S4-S5)",
            funktion = "Stabilisierung des Steißbeins und des Beckenbodens",
            structure_id = 13
        });

        _connection.Insert(new Descriptions
        {
            id = 14,
            ansatz = "Becken - Innere Lippe des Darmbeinkamms",
            innervation = "Vordere Äste der Spinalnerven (T12, L1-L4)",
            funktion = "Stabilisierung der Lendenwirbelsäule und des Beckens",
            structure_id = 14
        });

        _connection.Insert(new Descriptions
        {
            id = 15,
            ansatz = "Becken - Innere Lippe des Darmbeinkamms",
            innervation = "Vordere Äste der Spinalnerven (T12, L1-L4)",
            funktion = "Stabilisierung der Lendenwirbelsäule und des Beckens",
            structure_id = 15
        });

        _connection.Insert(new Descriptions
        {
            id = 16,
            ansatz = "Becken - obere Ränder des Schambeinkörpers",
            innervation = "Unterrippennerv (T12)",
            funktion = "Stabilisierung der unteren Bauchwand",
            structure_id = 16
        });

        _connection.Insert(new Descriptions
        {
            id = 17,
            ansatz = "Becken - obere Ränder des Schambeinkörpers",
            innervation = "Unterrippennerv (T12)",
            funktion = "Stabilisierung der unteren Bauchwand",
            structure_id = 17
        });

        _connection.Insert(new Descriptions
        {
            id = 18,
            ansatz = "Brustkorb - Rippenkörper VII-XII, Fascia thoracolumbalis",
            innervation = "Rechte Zwischenrippennerven - T7-T12",
            funktion = "Stabilisierung des Rumpfes, Unterstützung des Beckenbodens",
            structure_id = 18
        });

        _connection.Insert(new Descriptions
        {
            id = 19,
            ansatz = "Brustkorb - Rippenkörper VII-XII, Fascia thoracolumbalis",
            innervation = "Linke Zwischenrippennerven - T7-T12",
            funktion = "Stabilisierung des Rumpfes, Unterstützung des Beckenbodens",
            structure_id = 19
        });

        _connection.Insert(new Descriptions
        {
            id = 20,
            ansatz = "Becken - zwischen Schambeinhöcker und Symphysis pubica",
            innervation = "Zwischenrippennerven (T5-T12)",
            funktion = "Flexion des Rumpfes, Unterstützung der inneren Organe",
            structure_id = 20
        });

        _connection.Insert(new Descriptions
        {
            id = 21,
            ansatz = "Becken - zwischen Schambeinhöcker und Symphysis pubica",
            innervation = "Zwischenrippennerven (T5-T12)",
            funktion = "Flexion des Rumpfes, Unterstützung der inneren Organe",
            structure_id = 21
        });

        //Descriptiions Zwerchfell
        _connection.Insert(new Descriptions
        {
            id = 22,
            ansatz = "Brustkorb - Processus xiphoideus sterni, untere Rippenbogenränder",
            innervation = "Zwerchfellnerven (C3-C5)",
            funktion = "Atemfunktion, Unterstützung des Beckenbodens",
            structure_id = 22
        });

        //Descriptions Beinmuskeln
        _connection.Insert(new Descriptions
        {
            id = 23,
            ansatz = "Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            innervation = "Hüftlochnerv - L2-L3",
            funktion = "Adduktion des Oberschenkels",
            structure_id = 23
        });

        _connection.Insert(new Descriptions
        {
            id = 24,
            ansatz = "Schienbein - Schienbeinhöcker (medialer Teil)",
            innervation = "Hüftlochnerv - L2-L3",
            funktion = "Adduktion des Oberschenkels, Flexion und Innenrotation des Knies",
            structure_id = 24
        });

        _connection.Insert(new Descriptions
        {
            id = 25,
            ansatz = "Oberschenkelknochen – Kammlinie (Diaphyse)",
            innervation = "Hüftlochnerv und Schenkelnerv - L2-L3",
            funktion = "Adduktion, Flexion und Außenrotation des Oberschenkels",
            structure_id = 25
        });

        _connection.Insert(new Descriptions
        {
            id = 26,
            ansatz = "Schienbein - Schienbeinhöcker (über das innere Halteband der Kniescheibe)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 26
        });

        _connection.Insert(new Descriptions
        {
            id = 27,
            ansatz = "Schienbein - Schienbeinhöcker (mittels Kniescheibenband)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 27
        });

        _connection.Insert(new Descriptions
        {
            id = 28,
            ansatz = "Schienbein - Schienbeinhöcker (über das äußere Halteband der Kniescheibe)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 28
        });

        _connection.Insert(new Descriptions
        {
            id = 29,
            ansatz = "Kapsel des Kniegelenks (Bursa suprapatellaris)",
            innervation = "Schenkelnerv - L2-L3",
            funktion = "Schutz des Kniegelenks bei Bewegung",
            structure_id = 29
        });

        _connection.Insert(new Descriptions
        {
            id = 30,
            ansatz = "Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            innervation = "Hüftlochnerv - L2-L4",
            funktion = "Adduktion des Oberschenkels",
            structure_id = 30
        });

        _connection.Insert(new Descriptions
        {
            id = 31,
            ansatz = "Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse), Tuberculum adductorium des inneren Gelenkknorrens (distale Epiphyse)",
            innervation = "Hüftlochnerv - L2-L4, Schienbeinnerv L4",
            funktion = "Adduktion des Oberschenkels",
            structure_id = 31
        });

        _connection.Insert(new Descriptions
        {
            id = 32,
            ansatz = "Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Rechte vordere Äste der Spinalnerven - L1-L3, Schenkelnerv - L2-L3",
            funktion = "Flexion des Oberschenkels, Stabilisierung des Beckens",
            structure_id = 32
        });

        _connection.Insert(new Descriptions
        {
            id = 33,
            ansatz = "Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Schenkelnerv L2-L3",
            funktion = "Flexion des Oberschenkels",
            structure_id = 33
        });

        _connection.Insert(new Descriptions
        {
            id = 34,
            ansatz = "Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Rami anteriores nervorum sacralium - L1-L3",
            funktion = "Flexion des Oberschenkels",
            structure_id = 34
        });

        _connection.Insert(new Descriptions
        {
            id = 35,
            ansatz = "Becken - Schambeinkamm und Darmbein",
            innervation = "Vorderer Ast des Spinalnervs - L1",
            funktion = "Stabilisierung des Beckens",
            structure_id = 35
        });

        _connection.Insert(new Descriptions
        {
            id = 36,
            ansatz = "Schienbein - Condylus medialis (proximale Epiphyse)",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Beugung des Knies, Stabilisierung des Knies",
            structure_id = 36
        });

        _connection.Insert(new Descriptions
        {
            id = 37,
            ansatz = "Wadenbein - Spitze des Caput (proximale Epiphyse)",
            innervation = "Schienbeinnerv (Caput longum) und Wadenbeinnerv (Caput breve) - L5-S2",
            funktion = "Beugung des Knies, Außenrotation des Oberschenkels",
            structure_id = 37
        });

        _connection.Insert(new Descriptions
        {
            id = 38,
            ansatz = "Schienbein - Condylus medialis",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Beugung des Knies, Innenrotation des Oberschenkels",
            structure_id = 38
        });

        _connection.Insert(new Descriptions
        {
            id = 39,
            ansatz = "Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S2",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 39
        });

        _connection.Insert(new Descriptions
        {
            id = 40,
            ansatz = "Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L4-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 40
        });

        _connection.Insert(new Descriptions
        {
            id = 41,
            ansatz = "Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Hüftlochnerv – L3-L4",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 41
        });

        _connection.Insert(new Descriptions
        {
            id = 42,
            ansatz = "Oberschenkelknochen = großer Rollhügel (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – S1-S2",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 42
        });

        _connection.Insert(new Descriptions
        {
            id = 43,
            ansatz = "Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Oberer Gesäßnerv -L4-S1",
            funktion = "Abduktion und Innenrotation des Oberschenkels",
            structure_id = 43
        });

        _connection.Insert(new Descriptions
        {
            id = 44,
            ansatz = "Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 44
        });

        _connection.Insert(new Descriptions
        {
            id = 45,
            ansatz = "Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Oberer Gesäßnerv -L4-S1",
            funktion = "Abduktion und Stabilisierung des Beckens",
            structure_id = 45
        });

        _connection.Insert(new Descriptions
        {
            id = 46,
            ansatz = "Schienbein - Schienbeinhöcker (mittels Kniescheibenband)",
            innervation = "Schenkelnerv L2-L4",
            funktion = "Beugung des Oberschenkels, Streckung des Knies",
            structure_id = 46
        });

        _connection.Insert(new Descriptions
        {
            id = 47,
            ansatz = "Schienbein - Schienbeinhöcker (medialer Teil)",
            innervation = "Schenkelnerv L2-L3",
            funktion = "Flexion, Abduktion und Außenrotation des Oberschenkels",
            structure_id = 47
        });

        _connection.Insert(new Descriptions
        {
            id = 48,
            ansatz = "Oberschenkelknochen - Gesäßmuskelrauigkeit (Diaphyse)",
            innervation = "Unterer Gesäßnerv – L5-S2",
            funktion = "Hüftstreckung, Außenrotation des Oberschenkels",
            structure_id = 48
        });

        _connection.Insert(new Descriptions
        {
            id = 49,
            ansatz = "Darmbein-Schienbein-Band",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Spannt die Oberschenkelfaszie, unterstützt die Hüftabduktion",
            structure_id = 49
        });

        _connection.Insert(new Descriptions
        {
            id = 50,
            ansatz = "Oberschenkelknochen - quadratischer Höcker der Zwischenrollhügelleiste (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 50
        });

        _connection.Insert(new Descriptions
        {
            id = 51,
            ansatz = "Schienbein- Hinterfläche (proximaler Teil der Diaphyse)",
            innervation = "Schienbeinnerv – L4-S1",
            funktion = "Beugung und Innenrotation des Knies",
            structure_id = 51
        });

        _connection.Insert(new Descriptions
        {
            id = 52,
            ansatz = "Fuß - Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Beugung des Knies, Plantarflexion des Fußes",
            structure_id = 52
        });

        _connection.Insert(new Descriptions
        {
            id = 53,
            ansatz = "Fuß - Tuberositas des Kahnbeins, Keilbeine, Mittelfußknochen II-IV (Unterseiten)",
            innervation = "Schienbeinnerv – L4-L5",
            funktion = "Plantarflexion und Supination des Fußes",
            structure_id = 53
        });

        _connection.Insert(new Descriptions
        {
            id = 54,
            ansatz = "Dorsalaponeurose der Zehen",
            innervation = "Tiefer Wadenbeinnerv – L5",
            funktion = "Streckung der Großzehe, Dorsalflexion des Fußes",
            structure_id = 54
        });

        _connection.Insert(new Descriptions
        {
            id = 55,
            ansatz = "Fuß - Tuberositas der Basis des 5. Mittelfußknochens (laterale Fläche)",
            innervation = "Oberflächlicher Wadenbeinnerv – L5-S1",
            funktion = "Plantarflexion und Eversion des Fußes",
            structure_id = 55
        });

        _connection.Insert(new Descriptions
        {
            id = 56,
            ansatz = "Fuß - Basis des 5. Mittelfußknochens (Rückfläche)",
            innervation = "Tiefer Wadenbeinnerv – L5-S1",
            funktion = "Dorsalflexion und Eversion des Fußes",
            structure_id = 56
        });

        _connection.Insert(new Descriptions
        {
            id = 57,
            ansatz = "Fuß - Basis des Endglieds der Großzehe (Unterseite)",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Flexion der Großzehe, Plantarflexion des Fußes",
            structure_id = 57
        });

        _connection.Insert(new Descriptions
        {
            id = 58,
            ansatz = "Fuß - Basen der Endphalangen der Zehen II-V (Unterseiten)",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Flexion der Zehen II-V, Plantarflexion des Fußes",
            structure_id = 58
        });

        _connection.Insert(new Descriptions
        {
            id = 59,
            ansatz = "Fuß - inneres Keilbein, Basis des 1. Mittelfußknochens (mediale und untere Seite)",
            innervation = "Tiefer Wadenbeinnerv – L4-L5",
            funktion = "Dorsalflexion und Inversion des Fußes",
            structure_id = 59
        });

        _connection.Insert(new Descriptions
        {
            id = 60,
            ansatz = "Dorsalaponeurose der Zehen",
            innervation = "Tiefer Wadenbeinnerv – L5-S1",
            funktion = "Streckung der Zehen, Dorsalflexion des Fußes",
            structure_id = 60
        });

        _connection.Insert(new Descriptions
        {
            id = 61,
            ansatz = "Fuß - mittleres Keilbein, Tuberositas der Basis des 1. Mittelfußknochens (Unterseiten)",
            innervation = "Oberflächlicher Wadenbeinnerv – L5-S1",
            funktion = "Plantarflexion und Eversion des Fußes",
            structure_id = 61
        });

        _connection.Insert(new Descriptions
        {
            id = 62,
            ansatz = "Fuß - Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Plantarflexion des Fußes",
            structure_id = 62
        });

        _connection.Insert(new Descriptions
        {
            id = 63,
            ansatz = "Fuß - Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Plantarflexion des Fußes, Beugung des Knies",
            structure_id = 63
        });

        _connection.Insert(new Descriptions
        {
            id = 64,
            ansatz = "Fuß - Basis des 5. Mittelfußknochens (untere Fläche)",
            innervation = "Oberflächlicher Ast des äußeren Fußsohlennervs - S2-S3",
            funktion = "Beugt und dreht den Kleinzeh",
            structure_id = 64
        });

        _connection.Insert(new Descriptions
        {
            id = 65,
            ansatz = "Fuß - Tuberositas der Basis des 5. Mittelfußknochens und Basis des Kleinzehengrundglieds (untere Seiten)",
            innervation = "Äußerer Fußsohlennerv – S1-S3",
            funktion = "Abduktion des Kleinzehs",
            structure_id = 65
        });

        _connection.Insert(new Descriptions
        {
            id = 66,
            ansatz = "Fuß - Basis der proximalen Phalanx der Kleinzehe (Unterseite)",
            innervation = "Oberflächlicher Ast des äußeren Fußsohlennervs - S2-S3",
            funktion = "Beugung des Kleinzehs",
            structure_id = 66
        });

        _connection.Insert(new Descriptions
        {
            id = 67,
            ansatz = "Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            innervation = "Hüftlochnerv - L2-L3",
            funktion = "Adduktion und Flexion des Oberschenkels",
            structure_id = 67
        });

        _connection.Insert(new Descriptions
        {
            id = 68,
            ansatz = "Schienbein - Schienbeinhöcker (medialer Teil)",
            innervation = "Hüftlochnerv - L2-L3",
            funktion = "Adduktion des Oberschenkels, Flexion des Knies",
            structure_id = 68
        });

        _connection.Insert(new Descriptions
        {
            id = 69,
            ansatz = "Oberschenkelknochen – Kammlinie (Diaphyse)",
            innervation = "Hüftlochnerv und Schenkelnerv - L2-L3",
            funktion = "Adduktion, Flexion und Außenrotation des Oberschenkels",
            structure_id = 69
        });

        _connection.Insert(new Descriptions
        {
            id = 70,
            ansatz = "Schienbein- Schienbeinhöcker (über das innere Halteband der Kniescheibe)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 70
        });

        _connection.Insert(new Descriptions
        {
            id = 71,
            ansatz = "Schienbein- Schienbeinhöcker (mittels Kniescheibenband)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 71
        });

        _connection.Insert(new Descriptions
        {
            id = 72,
            ansatz = "Schienbein - Schienbeinhöcker (über das äußere Halteband der Kniescheibe)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 72
        });

        _connection.Insert(new Descriptions
        {
            id = 73,
            ansatz = "Kapsel des Kniegelenks (Bursa suprapatellaris)",
            innervation = "Schenkelnerv - L2-L3",
            funktion = "Stabilisierung der Kniescheibe während der Bewegung",
            structure_id = 73
        });

        _connection.Insert(new Descriptions
        {
            id = 74,
            ansatz = "Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            innervation = "Hüftlochnerv - L2-L4",
            funktion = "Adduktion und Flexion des Oberschenkels",
            structure_id = 74
        });

        _connection.Insert(new Descriptions
        {
            id = 75,
            ansatz = "Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse), Tuberculum adductorium des inneren Gelenkknorrens",
            innervation = "Hüftlochnerv - L2-L4, Schienbeinnerv L4",
            funktion = "Adduktion und Flexion des Oberschenkels, Extension des Oberschenkels",
            structure_id = 75
        });

        _connection.Insert(new Descriptions
        {
            id = 76,
            ansatz = "Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Linke vordere Äste der Spinalnerven - L1-L3, Schenkelnerv - L2-L3",
            funktion = "Flexion des Oberschenkels, Aufrichten des Oberkörpers",
            structure_id = 76
        });

        _connection.Insert(new Descriptions
        {
            id = 77,
            ansatz = "Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Schenkelnerv - L2-L3",
            funktion = "Flexion des Oberschenkels",
            structure_id = 77
        });

        _connection.Insert(new Descriptions
        {
            id = 78,
            ansatz = "Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Rami anteriores nervorum sacralium - L1-L3",
            funktion = "Flexion des Oberschenkels",
            structure_id = 78
        });

        _connection.Insert(new Descriptions
        {
            id = 79,
            ansatz = "Becken - Schambeinkamm und Darmbein",
            innervation = "Vorderer Ast des Spinalnervs - L1",
            funktion = "Flexion und Außenrotation des Oberschenkels",
            structure_id = 79
        });

        _connection.Insert(new Descriptions
        {
            id = 80,
            ansatz = "Schienbein - Condylus medialis (proximale Epiphyse), Schräges Kniekehlenband",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Beugung des Knies, Innenrotation des Oberschenkels",
            structure_id = 80
        });

        _connection.Insert(new Descriptions
        {
            id = 81,
            ansatz = "Wadenbein- Spitze des Caput (proximale Epiphyse)",
            innervation = "Schienbeinnerv (Caput longum) und Wadenbeinnerv (Caput breve) – L5-S2",
            funktion = "Beugung des Knies, Außenrotation des Oberschenkels",
            structure_id = 81
        });

        _connection.Insert(new Descriptions
        {
            id = 82,
            ansatz = "Schienbein – Schienbeinhöcker (medialer Teil)",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Beugung des Knies, Innenrotation des Oberschenkels",
            structure_id = 82
        });

        _connection.Insert(new Descriptions
        {
            id = 83,
            ansatz = "Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S2",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 83
        });

        _connection.Insert(new Descriptions
        {
            id = 84,
            ansatz = "Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L4-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 84
        });

        _connection.Insert(new Descriptions
        {
            id = 85,
            ansatz = "Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Hüftlochnerv – L3-L4",
            funktion = "Außenrotation des Oberschenkels, Adduktion",
            structure_id = 85
        });

        _connection.Insert(new Descriptions
        {
            id = 86,
            ansatz = "Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – S1-S2",
            funktion = "Außenrotation und Abduktion des Oberschenkels",
            structure_id = 86
        });

        _connection.Insert(new Descriptions
        {
            id = 87,
            ansatz = "Becken - Gesäßfläche des Darmbeins (zwischen der anterioren und der posterioren Linea glutealis)",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Abduktion und Innenrotation des Oberschenkels",
            structure_id = 87
        });

        _connection.Insert(new Descriptions
        {
            id = 88,
            ansatz = "Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (Innenfläche)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 88
        });

        _connection.Insert(new Descriptions
        {
            id = 89,
            ansatz = "Becken - Gesäßfläche des Darmbeins (unterhalb des Darmbeinkamms zwischen der anterioren und der posterioren Linea glutealis)",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Abduktion des Oberschenkels",
            structure_id = 89
        });

        _connection.Insert(new Descriptions
        {
            id = 90,
            ansatz = "Becken - vorderer unterer Darmbeinstachel, Oberrand der Hüftgelenkspfanne (Acetabulum)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Flexion des Oberschenkels, Streckung des Knies",
            structure_id = 90
        });

        _connection.Insert(new Descriptions
        {
            id = 91,
            ansatz = "Becken - oberer vorderer Darmbeinstachel",
            innervation = "Schenkelbeinhöcker (medialer Teil)",
            funktion = "Beugung und Außenrotation des Oberschenkels, Beugung des Knies",
            structure_id = 91
        });

        _connection.Insert(new Descriptions
        {
            id = 92,
            ansatz = "Wirbelsäule - dorsale Kreuzbeinoberfläche, Fascia thoracolumbalis, Becken - Gesäßfläche des Darmbeins, Kreuzbein-Sitzbeinhöcker-Band",
            innervation = "Unterer Gesäßnerv - L5-S2",
            funktion = "Extension, Abduktion und Außenrotation des Oberschenkels",
            structure_id = 92
        });

        _connection.Insert(new Descriptions
        {
            id = 93,
            ansatz = "Becken - oberer vorderer Darmbeinstachel",
            innervation = "Darmbein-Schienbein-Band",
            funktion = "Flexion, Abduktion und Innenrotation des Oberschenkels",
            structure_id = 93
        });

        _connection.Insert(new Descriptions
        {
            id = 94,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes (laterale Kante)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 94
        });

        _connection.Insert(new Descriptions
        {
            id = 95,
            ansatz = "Oberschenkelknochen - Sulcus popliteus des äußeren Gelenkknorrens (distale Epiphyse)",
            innervation = "Schienbeinnerv - L4-S1",
            funktion = "Flexion und Innenrotation des Knies",
            structure_id = 95
        });

        _connection.Insert(new Descriptions
        {
            id = 96,
            ansatz = "Oberschenkelknochen - Epicondylus lateralis des äußeren Gelenkknorrens (distale Epiphyse), Schräges Kniekehlenband",
            innervation = "Schienbeinnerv - S1-S2",
            funktion = "Flexion des Knies, Plantarflexion des Fußes",
            structure_id = 96
        });

        _connection.Insert(new Descriptions
        {
            id = 97,
            ansatz = "Schienbein - Hinterfläche (proximale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Wadenbein - Hinterfläche (proximale 2/3 der Diaphyse)",
            innervation = "Schienbeinnerv - L4-L5",
            funktion = "Plantarflexion und Inversion des Fußes",
            structure_id = 97
        });

        _connection.Insert(new Descriptions
        {
            id = 98,
            ansatz = "Wadenbein - mediale Fläche (distale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels",
            innervation = "Tiefer Wadenbeinnerv - L5",
            funktion = "Dorsalextension des Fußes, Streckung der Großzehe",
            structure_id = 98
        });

        _connection.Insert(new Descriptions
        {
            id = 99,
            ansatz = "Wadenbein - laterale Fläche (distale 2/3 der Diaphyse), Zwischenmuskelscheidewände des Unterschenkels (Septum intermusculare cruris)",
            innervation = "Oberflächlicher Wadenbeinnerv - L5-S1",
            funktion = "Plantarflexion und Eversion des Fußes",
            structure_id = 99
        });

        _connection.Insert(new Descriptions
        {
            id = 100,
            ansatz = "Wadenbein - vordere Kante (distales 1/3 der Diaphyse)",
            innervation = "Tiefer Wadenbeinnerv - L5-S1",
            funktion = "Dorsalextension und Eversion des Fußes",
            structure_id = 100
        });

        _connection.Insert(new Descriptions
        {
            id = 101,
            ansatz = "Wadenbein - Hinterfläche (distale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels",
            innervation = "Schienbeinnerv - L5-S2",
            funktion = "Plantarflexion und Beugung der Großzehe",
            structure_id = 101
        });

        _connection.Insert(new Descriptions
        {
            id = 102,
            ansatz = "Schienbein - Hinterfläche (mittleres 1/3 der Diaphyse)",
            innervation = "Schienbeinnerv - L5-S2",
            funktion = "Plantarflexion und Beugung der Zehen II-V",
            structure_id = 102
        });

        _connection.Insert(new Descriptions
        {
            id = 103,
            ansatz = "Schienbein - laterale Fläche (proximale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels",
            innervation = "Tiefer Wadenbeinnerv - L4-L5",
            funktion = "Dorsalextension des Fußes, Inversion",
            structure_id = 103
        });

        _connection.Insert(new Descriptions
        {
            id = 104,
            ansatz = "Schienbein - lateraler Kondylus (proximale Epiphyse), Wadenbein - Caput (proximale Epiphyse), mediale Fläche (Diaphyse), Zwischenknochenmembran des Unterschenkels",
            innervation = "Tiefer Wadenbeinnerv - L5-S1",
            funktion = "Dorsalextension des Fußes, Streckung der Zehen",
            structure_id = 104
        });

        _connection.Insert(new Descriptions
        {
            id = 105,
            ansatz = "Wadenbein - Caput (proximale Epiphyse), laterale Fläche und vordere Kante (Diaphyse), Zwischenmuskelscheidewände des Unterschenkels (Septum Intermusculare cruris)",
            innervation = "Oberflächlicher Wadenbeinnerv - L5-S1",
            funktion = "Plantarflexion und Eversion des Fußes",
            structure_id = 105
        });

        _connection.Insert(new Descriptions
        {
            id = 106,
            ansatz = "Wadenbein - Caput (proximale Epiphyse), Dorsalfläche und dorsale Kante (proximales 1/4 der Diaphyse), Schienbein - Linea musculi solei auf der Dorsalseite und mediale Kante (Diaphyse)",
            innervation = "Schienbeinnerv - S1-S2",
            funktion = "Plantarflexion des Fußes",
            structure_id = 106
        });

        _connection.Insert(new Descriptions
        {
            id = 107,
            ansatz = "Oberschenkelknochen - Epicondylus lateralis des äußeren Gelenkknorrens, Epicondylus medialis des inneren Gelenkknorrens (distale Epiphyse)",
            innervation = "Schienbeinnerv - S1-S2",
            funktion = "Plantarflexion des Fußes, Beugung des Knies",
            structure_id = 107
        });

        _connection.Insert(new Descriptions
        {
            id = 108,
            ansatz = "Kurzer Wadenbeinmuskel (distale Sehne) und langes Fußsohlenband",
            innervation = "Oberflächlicher Ast des äußeren Fußsohlennervs - S2-S3",
            funktion = "Opposition des Kleinzehs",
            structure_id = 108
        });

        _connection.Insert(new Descriptions
        {
            id = 109,
            ansatz = "Fuß - medialer und lateraler Fortsatz des Fersenbeinhöckers, Plantaraponeurose",
            innervation = "Äußerer Fußsohlennerv - S1-S3",
            funktion = "Abduktion des Kleinzehs",
            structure_id = 109
        });

        _connection.Insert(new Descriptions
        {
            id = 110,
            ansatz = "Fuß - Basis des 5. Mittelfußknochens (untere Fläche), Langes Fußsohlenband",
            innervation = "Oberflächlicher Ast des äußeren Fußsohlennervs - S2-S3",
            funktion = "Flexion des Kleinzehs",
            structure_id = 110
        });

        _connection.Insert(new Descriptions
        {
            id = 111,
            ansatz = "Corporat von jeweils zwei benachbarten Mittelfußknochen (an den gegenüberliegenden Flächen)",
            innervation = "Äußerer Fußsohlennerv - S2-S3",
            funktion = "Abduktion der Zehen",
            structure_id = 111
        });

        _connection.Insert(new Descriptions
        {
            id = 112,
            ansatz = "Corporat von jeweils zwei benachbarten Mittelfußknochen (an den gegenüberliegenden Flächen)",
            innervation = "Äußerer Fußsohlennerv - S2-S3",
            funktion = "Abduktion der Zehen",
            structure_id = 112
        });

        _connection.Insert(new Descriptions
        {
            id = 113,
            ansatz = "Tuberositas radii und über die Aponeurosis musculi bicipitis brachii an der Fascia antebrachii",
            innervation = "N. musculocutaneus (C5–C6)",
            funktion = "Flexion und Supination im Ellenbogengelenk; unterstützt Flexion im Schultergelenk",
            structure_id = 113
        });

        _connection.Insert(new Descriptions
        {
            id = 115,
            ansatz = "Mediale Fläche des Humerus in Verlängerung der Crista tuberculi minoris",
            innervation = "N. musculocutaneus (C5–C7)",
            funktion = "Adduktion, Flexion und Innenrotation im Schultergelenk",
            structure_id = 115
        });

        _connection.Insert(new Descriptions
        {
            id = 117,
            ansatz = "Tuberositas deltoidea des Humerus",
            innervation = "N. axillaris (C5–C6)",
            funktion = "Abduktion, Anteversion, Retroversion, Innen- und Außenrotation im Schultergelenk, je nach Faseranteil",
            structure_id = 117
        });

        _connection.Insert(new Descriptions
        {
            id = 119,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. suprascapularis (C4–C6)",
            funktion = "Außenrotation im Schultergelenk",
            structure_id = 119
        });

        _connection.Insert(new Descriptions
        {
            id = 121,
            ansatz = "Tuberculum minus des Humerus",
            innervation = "Nn. subscapulares (C5–C6)",
            funktion = "Innenrotation im Schultergelenk",
            structure_id = 121
        });

        _connection.Insert(new Descriptions
        {
            id = 123,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. suprascapularis (C4–C6)",
            funktion = "Abduktion im Schultergelenk",
            structure_id = 123
        });

        _connection.Insert(new Descriptions
        {
            id = 125,
            ansatz = "Crista tuberculi minoris des Humerus",
            innervation = "N. thoracodorsalis (C6–C7)",
            funktion = "Innenrotation, Adduktion und Retroversion im Schultergelenk",
            structure_id = 125
        });

        _connection.Insert(new Descriptions
        {
            id = 127,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. axillaris (C5–C6)",
            funktion = "Außenrotation und schwache Adduktion im Schultergelenk",
            structure_id = 127
        });

        _connection.Insert(new Descriptions
        {
            id = 129,
            ansatz = "Olecranon der Ulna",
            innervation = "N. radialis (C6–C8)",
            funktion = "Extension im Ellenbogengelenk; Retroversion und Adduktion im Schultergelenk",
            structure_id = 129
        });

        _connection.Insert(new Descriptions
        {
            id = 131,
            ansatz = "Tuberositas ulnae",
            innervation = "N. musculocutaneus (C5–C6)",
            funktion = "Flexion im Ellenbogengelenk",
            structure_id = 131
        });

        _connection.Insert(new Descriptions
        {
            id = 133,
            ansatz = "Olecranon und proximales Viertel der dorsalen Fläche der Ulna",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension im Ellenbogengelenk; spannt die Gelenkkapsel",
            structure_id = 133
        });

        _connection.Insert(new Descriptions
        {
            id = 135,
            ansatz = "Processus styloideus radii",
            innervation = "N. radialis (C5–C6)",
            funktion = "Flexion im Ellenbogengelenk; unterstützt Pronation und Supination des Unterarms in die Mittelstellung",
            structure_id = 135
        });

        _connection.Insert(new Descriptions
        {
            id = 137,
            ansatz = "Facies lateralis radii (Mitte der Außenseite des Radius)",
            innervation = "N. medianus (C6–C7)",
            funktion = "Pronation und schwache Flexion im Ellenbogengelenk",
            structure_id = 137
        });

        _connection.Insert(new Descriptions
        {
            id = 139,
            ansatz = "Proximales Drittel des Radius",
            innervation = "N. radialis (C5–C6)",
            funktion = "Supination des Unterarms",
            structure_id = 139
        });

        _connection.Insert(new Descriptions
        {
            id = 141,
            ansatz = "Basis des Os metacarpi III",
            innervation = "N. radialis (C7–C8)",
            funktion = "Dorsalextension und Radialabduktion im Handgelenk",
            structure_id = 141
        });

        _connection.Insert(new Descriptions
        {
            id = 143,
            ansatz = "Basis des Os metacarpi II",
            innervation = "N. radialis (C6–C7)",
            funktion = "Dorsalextension und Radialabduktion im Handgelenk",
            structure_id = 143
        });

        _connection.Insert(new Descriptions
        {
            id = 145,
            ansatz = "Basis des Os metacarpi V",
            innervation = "N. radialis (C7–C8)",
            funktion = "Dorsalextension und Ulnarabduktion im Handgelenk",
            structure_id = 145
        });

        _connection.Insert(new Descriptions
        {
            id = 147,
            ansatz = "Dorsalaponeurose des 5. Fingers",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension des 5. Fingers; unterstützt Dorsalextension im Handgelenk",
            structure_id = 147
        });

        _connection.Insert(new Descriptions
        {
            id = 149,
            ansatz = "Basis des Os metacarpi II und III",
            innervation = "N. medianus (C6–C7)",
            funktion = "Flexion und Radialabduktion im Handgelenk",
            structure_id = 149
        });

        _connection.Insert(new Descriptions
        {
            id = 151,
            ansatz = "Os pisiforme, Hamulus ossis hamati, Basis des Os metacarpi V",
            innervation = "N. ulnaris (C7–Th1)",
            funktion = "Flexion und Ulnarabduktion im Handgelenk",
            structure_id = 151
        });

        _connection.Insert(new Descriptions
        {
            id = 153,
            ansatz = "Basis der Endphalanx des Daumens",
            innervation = "N. medianus (C7–C8)",
            funktion = "Flexion im Daumengrund- und -endgelenk; unterstützt Flexion im Handgelenk",
            structure_id = 153
        });

        _connection.Insert(new Descriptions
        {
            id = 155,
            ansatz = "Untere Rippen (Anguli costarum) und Fascia thoracolumbalis",
            innervation = "Rr. dorsales der Spinalnerven (C8–L1)",
            funktion = "Dorsalextension der Wirbelsäule, Lateralflexion zur ipsilateralen Seite",
            structure_id = 155
        });

        _connection.Insert(new Descriptions
        {
            id = 157,
            ansatz = "Dornfortsätze der benachbarten Lendenwirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung und Dorsalextension der Lendenwirbelsäule",
            structure_id = 157
        });

        _connection.Insert(new Descriptions
        {
            id = 159,
            ansatz = "Querfortsätze der benachbarten Lendenwirbel",
            innervation = "Rr. ventrales und dorsales der Spinalnerven",
            funktion = "Lateralflexion der Wirbelsäule",
            structure_id = 159
        });

        _connection.Insert(new Descriptions
        {
            id = 161,
            ansatz = "Anguli costarum (Rippenwinkel)",
            innervation = "Rr. dorsales der Spinalnerven (C8–Th11)",
            funktion = "Heben der Rippen, Unterstützung bei Inspiration und Lateralflexion der Wirbelsäule",
            structure_id = 161
        });

        _connection.Insert(new Descriptions
        {
            id = 163,
            ansatz = "Rippen und Querfortsätze der Brustwirbel",
            innervation = "Rr. dorsales der Spinalnerven (C4–L5)",
            funktion = "Dorsalextension und Lateralflexion der Wirbelsäule",
            structure_id = 163
        });

        _connection.Insert(new Descriptions
        {
            id = 165,
            ansatz = "Dornfortsätze der Wirbel, 2–4 Segmente überspannend",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung der Wirbelsäule, Dorsalextension und Rotation zur Gegenseite",
            structure_id = 165
        });

        _connection.Insert(new Descriptions
        {
            id = 167,
            ansatz = "Processus transversus des Atlas (C1)",
            innervation = "N. suboccipitalis (C1)",
            funktion = "Rotation des Kopfes zur ipsilateralen Seite",
            structure_id = 167
        });

        _connection.Insert(new Descriptions
        {
            id = 169,
            ansatz = "Os occipitale zwischen Linea nuchae superior und inferior",
            innervation = "N. suboccipitalis (C1)",
            funktion = "Dorsalextension und Lateralflexion des Kopfes",
            structure_id = 169
        });

        _connection.Insert(new Descriptions
        {
            id = 171,
            ansatz = "Dornfortsätze der Wirbel, überspringen 1 (breves) oder 2 (longi) Segmente",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Rotation und Stabilisierung der Wirbelsäule",
            structure_id = 171
        });

        _connection.Insert(new Descriptions
        {
            id = 173,
            ansatz = "Dornfortsätze der Brust- und Halswirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Dorsalextension der Wirbelsäule und des Kopfes, Rotation zur Gegenseite",
            structure_id = 173
        });

        _connection.Insert(new Descriptions
        {
            id = 175,
            ansatz = "Dornfortsätze der oberen Brust- und unteren Halswirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Dorsalextension der Wirbelsäule",
            structure_id = 175
        });

        _connection.Insert(new Descriptions
        {
            id = 177,
            ansatz = "Querfortsätze der oberen Halswirbel (C1–C3)",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Dorsalextension des Halses und des Kopfes, Rotation und Lateralflexion zur ipsilateralen Seite",
            structure_id = 177
        });

        _connection.Insert(new Descriptions
        {
            id = 179,
            ansatz = "Rippen 2–5 (kraniale Ränder)",
            innervation = "Nn. intercostales (Th1–Th4)",
            funktion = "Heben der Rippen, Unterstützung bei Inspiration",
            structure_id = 179
        });

        _connection.Insert(new Descriptions
        {
            id = 181,
            ansatz = "Rippen 9–12 (kaudale Ränder)",
            innervation = "Nn. intercostales (Th9–Th12)",
            funktion = "Senken der Rippen, Unterstützung bei Exspiration",
            structure_id = 181
        });

        _connection.Insert(new Descriptions
        {
            id = 183,
            ansatz = "Crista tuberculi minoris des Humerus",
            innervation = "N. thoracodorsalis (C6–C8)",
            funktion = "Adduktion, Innenrotation und Retroversion im Schultergelenk",
            structure_id = 183
        });

        _connection.Insert(new Descriptions
        {
            id = 185,
            ansatz = "Margo medialis der Scapula (oberhalb der Spina scapulae)",
            innervation = "N. dorsalis scapulae (C4–C5)",
            funktion = "Fixierung der Scapula, Adduktion und Elevation der Scapula",
            structure_id = 185
        });

        _connection.Insert(new Descriptions
        {
            id = 187,
            ansatz = "Margo medialis der Scapula (unterhalb der Spina scapulae)",
            innervation = "N. dorsalis scapulae (C4–C5)",
            funktion = "Fixierung der Scapula, Adduktion und Elevation der Scapula",
            structure_id = 187
        });

        _connection.Insert(new Descriptions
        {
            id = 189,
            ansatz = "Laterales Drittel der Clavicula, Acromion, Spina scapulae",
            innervation = "N. accessorius (XI. Hirnnerv) und Plexus cervicalis (C2–C4)",
            funktion = "Fixierung der Scapula, Elevation, Depression, Retraktion und Rotation der Scapula",
            structure_id = 189
        });

        _connection.Insert(new Descriptions
        {
            id = 191,
            ansatz = "Dornfortsätze der benachbarten Brustwirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung und Dorsalextension der Brustwirbelsäule",
            structure_id = 191
        });

        _connection.Insert(new Descriptions
        {
            id = 193,
            ansatz = "Querfortsätze der benachbarten Brustwirbel",
            innervation = "Rr. dorsales und ventrales der Spinalnerven",
            funktion = "Lateralflexion der Brustwirbelsäule",
            structure_id = 193
        });

        _connection.Insert(new Descriptions
        {
            id = 195,
            ansatz = "Becken – Schambeinkörper (Innenfläche), Wirbelsäule – Apex ossis coccygis, After-Steißbein-Band (Ligamentum anococcygeum)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) - S4",
            funktion = "Stabilisierung des Rumpfes, Unterstützung der inneren Organe",
            structure_id = 154
        });

        _connection.Insert(new Descriptions
        {
            id = 196,
            ansatz = "Becken – Schambeinkörper (Innenfläche), Wirbelsäule – Apex ossis coccygis, After-Steißbein-Band (Ligamentum anococcygeum)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) - S4",
            funktion = "Stabilisierung des Rumpfes, Unterstützung der inneren Organe",
            structure_id = 155
        });

        _connection.Insert(new Descriptions
        {
            id = 197,
            ansatz = "Basis des Os metacarpi I",
            innervation = "N. radialis (C6–C7)",
            funktion = "Abduktion und Extension des Daumens im Sattelgelenk, Radialabduktion der Hand",
            structure_id = 197
        });


        _connection.Insert(new Descriptions
        {
            id = 199,
            ansatz = "Dorsalaponeurose des Zeigefingers",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension des Zeigefingers, unterstützt Dorsalextension der Hand",
            structure_id = 199
        });


        _connection.Insert(new Descriptions
        {
            id = 201,
            ansatz = "Aponeurosis palmaris",
            innervation = "N. medianus (C7–C8)",
            funktion = "Spannt die Palmaraponeurose, unterstützt Flexion im Handgelenk",
            structure_id = 201
        });

    }







    public IEnumerable<AnatomicalStructures> GetAnatomicalStructures(){
		return _connection.Table<AnatomicalStructures>();
	}
    public IEnumerable<AnatomicalStructures> GetSearchedModel(string searchText)
    {
        return _connection.Table<AnatomicalStructures>().Where(x => x.german_name == searchText);

    }
    public IEnumerable<AnatomicalStructures> GetGermanForLatin(string latinName)
    {
        return _connection.Table<AnatomicalStructures>().Where(x => x.latin_name == latinName);

    }
    public IEnumerable<Descriptions> GetDescription(int id) { 
        return _connection.Table<Descriptions>().Where(x => x.structure_id == id);
    }

    public IEnumerable<AnatomicalStructures> GetLiveSearchedModel(string searchText)
    {

        string query = @"
        SELECT DISTINCT id, german_name, latin_name, category, parentId
        FROM AnatomicalStructures
        WHERE (german_name IS NOT NULL AND german_name LIKE ?) 
           OR (latin_name IS NOT NULL AND latin_name LIKE ?)
        ORDER BY 
            CASE WHEN german_name LIKE ? THEN 1 ELSE 2 END,
            CASE WHEN latin_name LIKE ? THEN 1 ELSE 2 END,
            german_name,
            latin_name";

        string searchPattern = $"%{searchText}%";
        string startsWithPattern = $"{searchText}%";

        var results = _connection.Query<AnatomicalStructures>(query, searchPattern, searchPattern, startsWithPattern, startsWithPattern);

        return results;
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
