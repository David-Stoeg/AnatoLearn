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
            id = 1,
            german_name = "Tiefer querer Dammmuskel (re.)",
            latin_name = "Musculus transversus perinei profundus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 2,
            german_name = "Tiefer querer Dammmuskel (li.)",
            latin_name = "Musculus transversus perinei profundus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 3,
            german_name = "Oberflächlicher querer Dammmuskel (re.)",
            latin_name = "Musculus transversus perinei superficialis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 4,
            german_name = "Oberflächlicher querer Dammmuskel (li.)",
            latin_name = "Musculus transversus perinei superficialis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 5,
            german_name = "Schwellkörpermuskel der Harnröhre (re.)",
            latin_name = "Musculus bulbospongiosus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 6,
            german_name = "Schwellkörpermuskel der Harnröhre (li.)",
            latin_name = "Musculus bulbospongiosus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 7,
            german_name = "Schambein-Mastdarm-Muskel (re.)",
            latin_name = "Musculus puborectalis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 8,
            german_name = "Schambein-Mastdarm-Muskel (li.)",
            latin_name = "Musculus puborectalis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 9,
            german_name = "Darmbein-Steissbein-Muskel (re.)",
            latin_name = "Musculus iliococcygeus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 10,
            german_name = "Darmbein-Steissbein-Muskel (li.)",
            latin_name = "Musculus iliococcygeus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 11,
            german_name = "Steissbeinmuskel (re.)",
            latin_name = "Musculus ischiococcygeus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 12,
            german_name = "Steissbeinmuskel (li.)",
            latin_name = "Musculus ischiococcygeus (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 13,
            german_name = "Viereckiger Lendenmuskel (re.)",
            latin_name = "Musculus quadratus lumborum (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 14,
            german_name = "Viereckiger Lendenmuskel (li.)",
            latin_name = "Musculus quadratus lumborum (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 16,
            german_name = "Zwerchfell",
            latin_name = "Diaphragma thoracicum",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 17,
            german_name = "Pyramidenmuskel (re.)",
            latin_name = "Musculus pyramidalis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 18,
            german_name = "Pyramidenmuskel (li.)",
            latin_name = "Musculus pyramidalis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 19,
            german_name = "Querer Bauchmuskel (re.)",
            latin_name = "Musculus transversus abdominis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 20,
            german_name = "Querer Bauchmuskel (li.)",
            latin_name = "Musculus transversus abdominis (sin.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 21,
            german_name = "Gerader Bauchmuskel (re.)",
            latin_name = "Musculus rectus abdominis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 22,
            german_name = "Gerader Bauchmuskel (li.)",
            latin_name = "Musculus rectus abdominis (sin.)",
            category = "Beckenmuskeln",
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
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 42,
            german_name = "Birnenförmiger Muskel (re.)",
            latin_name = "Musculus piriformis (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 43,
            german_name = "Kleiner Gesäßmuskel (re.)",
            latin_name = "Musculus gluteus minimus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 44,
            german_name = "Innerer Hüftlochmuskel (re.)",
            latin_name = "Musculus obturatorius internus (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 45,
            german_name = "Mittlerer Gesäßmuskel (re.)",
            latin_name = "Musculus gluteus medius (dex.)",
            category = "Beckenmuskeln",
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
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 49,
            german_name = "Schenkelbindenspanner (re.)",
            latin_name = "Musculus tensor fasciae latae (dex.)",
            category = "Beckenmuskeln",
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
            german_name = "Darmbeinmuskel (li.)",
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
            german_name = "Langer Kopf des Bizeps",
            latin_name = "Musculus biceps brachii, Caput longum",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 114,
            german_name = "Rabenschnabelmuskel",
            latin_name = "Musculus coracobrachialis",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 115,
            german_name = "Deltamuskel",
            latin_name = "Musculus deltoideus",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 116,
            german_name = "Untergrätenmuskel",
            latin_name = "Musculus infraspinatus",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 117,
            german_name = "Unterschulterblattmuskel",
            latin_name = "Musculus subscapularis",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 118,
            german_name = "Obergrätenmuskel",
            latin_name = "Musculus supraspinatus",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 119,
            german_name = "Großer Rundmuskel",
            latin_name = "Musculus teres major",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 120,
            german_name = "Kleiner Rundmuskel",
            latin_name = "Musculus teres minor",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 121,
            german_name = "Langer Kopf des Trizeps",
            latin_name = "Musculus triceps brachii, Caput longum",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 122,
            german_name = "Armbeuger",
            latin_name = "Musculus brachialis",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 123,
            german_name = "Ellenbogenmuskel",
            latin_name = "Musculus anconeus",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 124,
            german_name = "Oberarmspeichenmuskel",
            latin_name = "Musculus brachioradialis",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 125,
            german_name = "Runder Einwärtsdreher",
            latin_name = "Musculus pronator teres",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 126,
            german_name = "Auswärtsdreher",
            latin_name = "Musculus supinator",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 127,
            german_name = "Kurzer speichenseitiger Handstrecker",
            latin_name = "Musculus extensor carpi radialis brevis",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 128,
            german_name = "Langer speichenseitiger Handstrecker",
            latin_name = "Musculus extensor carpi radialis longus",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 129,
            german_name = "Ellenseitiger Handstrecker",
            latin_name = "Musculus extensor carpi ulnaris",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 130,
            german_name = "Kleinfingerstrecker",
            latin_name = "Musculus extensor digiti minimi",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 131,
            german_name = "Speichenseitiger Handbeuger",
            latin_name = "Musculus flexor carpi radialis",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 132,
            german_name = "Ellenseitiger Handbeuger",
            latin_name = "Musculus flexor carpi ulnaris",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 133,
            german_name = "Langer Daumenbeuger",
            latin_name = "Musculus flexor pollicis longus",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 134,
            german_name = "Schambein-Steißbein-Muskel (re.)",
            latin_name = "Musculus pubococcygeus (dex.)",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 135,
            german_name = "Schambein-Steißbein-Muskel (li.)",
            latin_name = "Musculus pubococcygeus (sin.)",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 136,
            german_name = "Sitzbein-Schwellkörper-Muskel (re.)",
            latin_name = "Musculus ischiocavernosus (dex.)",
            category = "",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 137,
            german_name = "Sitzbein-Schwellkörper-Muskel (li.)",
            latin_name = "Musculus ischiocavernosus (sin.)",
            category = "",
            parentId = 0
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
            id = 114,
            ansatz = "Mediale Fläche des Humerus in Verlängerung der Crista tuberculi minoris",
            innervation = "N. musculocutaneus (C5–C7)",
            funktion = "Adduktion, Flexion und Innenrotation im Schultergelenk",
            structure_id = 114
        });

        _connection.Insert(new Descriptions
        {
            id = 115,
            ansatz = "Tuberositas deltoidea des Humerus",
            innervation = "N. axillaris (C5–C6)",
            funktion = "Abduktion, Anteversion, Retroversion, Innen- und Außenrotation im Schultergelenk, je nach Faseranteil",
            structure_id = 115
        });

        _connection.Insert(new Descriptions
        {
            id = 116,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. suprascapularis (C4–C6)",
            funktion = "Außenrotation im Schultergelenk",
            structure_id = 116
        });

        _connection.Insert(new Descriptions
        {
            id = 117,
            ansatz = "Tuberculum minus des Humerus",
            innervation = "Nn. subscapulares (C5–C6)",
            funktion = "Innenrotation im Schultergelenk",
            structure_id = 117
        });

        _connection.Insert(new Descriptions
        {
            id = 118,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. suprascapularis (C4–C6)",
            funktion = "Abduktion im Schultergelenk",
            structure_id = 118
        });

        _connection.Insert(new Descriptions
        {
            id = 119,
            ansatz = "Crista tuberculi minoris des Humerus",
            innervation = "N. thoracodorsalis (C6–C7)",
            funktion = "Innenrotation, Adduktion und Retroversion im Schultergelenk",
            structure_id = 119
        });

        _connection.Insert(new Descriptions
        {
            id = 120,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. axillaris (C5–C6)",
            funktion = "Außenrotation und schwache Adduktion im Schultergelenk",
            structure_id = 120
        });

        _connection.Insert(new Descriptions
        {
            id = 121,
            ansatz = "Olecranon der Ulna",
            innervation = "N. radialis (C6–C8)",
            funktion = "Extension im Ellenbogengelenk; Retroversion und Adduktion im Schultergelenk",
            structure_id = 121
        });

        _connection.Insert(new Descriptions
        {
            id = 122,
            ansatz = "Tuberositas ulnae",
            innervation = "N. musculocutaneus (C5–C6)",
            funktion = "Flexion im Ellenbogengelenk",
            structure_id = 122
        });

        _connection.Insert(new Descriptions
        {
            id = 123,
            ansatz = "Olecranon und proximales Viertel der dorsalen Fläche der Ulna",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension im Ellenbogengelenk; spannt die Gelenkkapsel",
            structure_id = 123
        });

        _connection.Insert(new Descriptions
        {
            id = 124,
            ansatz = "Processus styloideus radii",
            innervation = "N. radialis (C5–C6)",
            funktion = "Flexion im Ellenbogengelenk; unterstützt Pronation und Supination des Unterarms in die Mittelstellung",
            structure_id = 124
        });

        _connection.Insert(new Descriptions
        {
            id = 125,
            ansatz = "Facies lateralis radii (Mitte der Außenseite des Radius)",
            innervation = "N. medianus (C6–C7)",
            funktion = "Pronation und schwache Flexion im Ellenbogengelenk",
            structure_id = 125
        });

        _connection.Insert(new Descriptions
        {
            id = 126,
            ansatz = "Proximales Drittel des Radius",
            innervation = "N. radialis (C5–C6)",
            funktion = "Supination des Unterarms",
            structure_id = 126
        });

        _connection.Insert(new Descriptions
        {
            id = 127,
            ansatz = "Basis des Os metacarpi III",
            innervation = "N. radialis (C7–C8)",
            funktion = "Dorsalextension und Radialabduktion im Handgelenk",
            structure_id = 127
        });

        _connection.Insert(new Descriptions
        {
            id = 128,
            ansatz = "Basis des Os metacarpi II",
            innervation = "N. radialis (C6–C7)",
            funktion = "Dorsalextension und Radialabduktion im Handgelenk",
            structure_id = 128
        });

        _connection.Insert(new Descriptions
        {
            id = 129,
            ansatz = "Basis des Os metacarpi V",
            innervation = "N. radialis (C7–C8)",
            funktion = "Dorsalextension und Ulnarabduktion im Handgelenk",
            structure_id = 129
        });

        _connection.Insert(new Descriptions
        {
            id = 130,
            ansatz = "Dorsalaponeurose des 5. Fingers",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension des 5. Fingers; unterstützt Dorsalextension im Handgelenk",
            structure_id = 130
        });

        _connection.Insert(new Descriptions
        {
            id = 131,
            ansatz = "Basis des Os metacarpi II und III",
            innervation = "N. medianus (C6–C7)",
            funktion = "Flexion und Radialabduktion im Handgelenk",
            structure_id = 131
        });

        _connection.Insert(new Descriptions
        {
            id = 132,
            ansatz = "Os pisiforme, Hamulus ossis hamati, Basis des Os metacarpi V",
            innervation = "N. ulnaris (C7–Th1)",
            funktion = "Flexion und Ulnarabduktion im Handgelenk",
            structure_id = 132
        });

        _connection.Insert(new Descriptions
        {
            id = 133,
            ansatz = "Basis der Endphalanx des Daumens",
            innervation = "N. medianus (C7–C8)",
            funktion = "Flexion im Daumengrund- und -endgelenk; unterstützt Flexion im Handgelenk",
            structure_id = 133
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
