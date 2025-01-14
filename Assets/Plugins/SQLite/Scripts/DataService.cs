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
            id = 15,
            german_name = "Zwerchfell (re.)",
            latin_name = "Diaphragma thoracicum (dex.)",
            category = "Beckenmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 16,
            german_name = "Zwerchfell (li.)",
            latin_name = "Diaphragma thoracicum (sin.)",
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

        _connection.Insert(new Descriptions
        {
            id = 1,
            text = "Ursprung: Sitzbeinast und Unterer Ast des Schambeins (Innenflächen) Ansatz: Dammkörper",
            structure_id = 1
        });

        _connection.Insert(new Descriptions
        {
            id = 2,
            text = "Ursprung: Sitzbeinast und Unterer Ast des Schambeins (Innenflächen) Ansatz: Dammkörper",
            structure_id = 2
        });

        _connection.Insert(new Descriptions
        {
            id = 3,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes (Innenfläche) Ansatz: Dammkörper",
            structure_id = 3
        });

        _connection.Insert(new Descriptions
        {
            id = 4,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes (Innenfläche) Ansatz: Dammkörper",
            structure_id = 4
        });

        _connection.Insert(new Descriptions
        {
            id = 5,
            text = "Ursprung: Becken - Sitzbeinast (Innenfläche) Ansatz: Bindegewebshülle",
            structure_id = 5
        });

        _connection.Insert(new Descriptions
        {
            id = 6,
            text = "Ursprung: Becken - Sitzbeinast (Innenfläche) Ansatz: Bindegewebshülle",
            structure_id = 6
        });

        _connection.Insert(new Descriptions
        {
            id = 7,
            text = "Ursprung: Dammkörper Ansatz: Bindegewebshülle des Harnröhrenschwellkörpers",
            structure_id = 6
        });

        _connection.Insert(new Descriptions
        {
            id = 8,
            text = "Ursprung: Becken - Sitzbein-Schambein-Ast (Ramus ischiopubicus) (Innenfläche) Ansatz: After-Steissbein-Band (Ligamentum anococcygeum)",
            structure_id = 7
        });

        _connection.Insert(new Descriptions
        {
            id = 9,
            text = "Ursprung: Becken - Sitzbein-Schambein-Ast (Ramus ischiopubicus) (Innenfläche) Ansatz: After-Steissbein-Band (Ligamentum anococcygeum)",
            structure_id = 8
        });

        _connection.Insert(new Descriptions
        {
            id = 10,
            text = "Ursprung: Becken - Sitzbeinstachel (Innenfläche) Ansatz: Wirbelsäule- Apex ossis coccygis, After-Steissbein-Band (Ligamentum anococcygeum)",
            structure_id = 9
        });

        _connection.Insert(new Descriptions
        {
            id = 11,
            text = "Ursprung: Becken - Sitzbeinstachel (Innenfläche) Ansatz: Wirbelsäule- Apex ossis coccygis, After-Steissbein-Band (Ligamentum anococcygeum)",
            structure_id = 10
        });

        _connection.Insert(new Descriptions
        {
            id = 12,
            text = "Ursprung: Wirbelsäule - Apex ossis sacri, Steissbein, Kreuzbein-Sitzbeinstachel-Band Ansatz: Becken - Sitzbeinstachel (Innenfläche)",
            structure_id = 11
        });

        _connection.Insert(new Descriptions
        {
            id = 13,
            text = "Ursprung: Wirbelsäule - Apex ossis sacri, Steissbein, Kreuzbein-Sitzbeinstachel-Band Ansatz: Becken - Sitzbeinstachel (Innenfläche)",
            structure_id = 12
        });

        _connection.Insert(new Descriptions
        {
            id = 14,
            text = "Ursprung: Darmbein-Lenden-Band (Lgamentum iliolumbale), Becken - Innere Lippe des Darmbeinkamms Ansatz: Brustkorb-Rippenkörper XII (anteroinferiorer Teil)",
            structure_id = 13
        });

        _connection.Insert(new Descriptions
        {
            id = 15,
            text = "Ursprung: Darmbein-Lenden-Band (Lgamentum iliolumbale), Becken - Innere Lippe des Darmbeinkamms Ansatz: Brustkorb-Rippenkörper XII (anteroinferiorer Teil)",
            structure_id = 14
        });

        _connection.Insert(new Descriptions
        {
            id = 16,
            text = "Ursprung: Brustkorb - Processus xiphoideus sterni, untere Rippenbogenränder, Rippenkörper VII-XII (Innenflächen), Ligamentum arcuatum medianum und laterale, Wirbelsäule - Wirbelkörper L1-L3, Bandscheiben, Ligamentum longitudinale anterius Ansatz: Centrum tendineum",
            structure_id = 15
        });

        _connection.Insert(new Descriptions
        {
            id = 17,
            text = "Ursprung: Brustkorb - Processus xiphoideus sterni, untere Rippenbogenränder, Rippenkörper VII-XII (Innenflächen), Ligamentum arcuatum medianum und laterale, Wirbelsäule - Wirbelkörper L1-L3, Bandscheiben, Ligamentum longitudinale anterius Ansatz: Centrum tendineum",
            structure_id = 16
        });

        _connection.Insert(new Descriptions
        {
            id = 18,
            text = "Ursprung: Becken - obere Ränder des Schambeinkörpers Ansatz: Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln)",
            structure_id = 17
        });

        _connection.Insert(new Descriptions
        {
            id = 19,
            text = "Ursprung: Becken - obere Ränder des Schambeinkörpers Ansatz: Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln)",
            structure_id = 18
        });

        _connection.Insert(new Descriptions
        {
            id = 20,
            text = "Ursprung: Brustkorb - Rippenkörper VII-XII (Innenflächen), Fascia thoracolumbalis und Fascia iliolumbalis, Becken - Innere Lippe des Darmbeinkamms und oberer vorderer Darmbeinstachel Ansatz: Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln), Becken - Schambeinleiste (Crista pubica)",
            structure_id = 19
        });

        _connection.Insert(new Descriptions
        {
            id = 21,
            text = "Ursprung: Brustkorb - Rippenkörper VII-XII (Innenflächen), Fascia thoracolumbalis und Fascia iliolumbalis, Becken - Innere Lippe des Darmbeinkamms und oberer vorderer Darmbeinstachel Ansatz: Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln), Becken - Schambeinleiste (Crista pubica)",
            structure_id = 20
        });

        _connection.Insert(new Descriptions
        {
            id = 22,
            text = "Ursprung: Becken - zwischen dem Schambeinhocker und der Facies symphysialis des Os pubis Ansatz: Brustkorb - Processus xiphoideus sterni, Rippenknorpel V-VII",
            structure_id = 21
        });

        _connection.Insert(new Descriptions
        {
            id = 23,
            text = "Ursprung: Becken - zwischen dem Schambeinhocker und der Facies symphysialis des Os pubis Ansatz: Brustkorb - Processus xiphoideus sterni, Rippenknorpel V-VII",
            structure_id = 22
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

        _connection.Insert(new Descriptions
        {
            id = 23,
            text = "Ursprung: Becken unterer Ast des Schambeins Ansatz: Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            structure_id = 23
        });

        _connection.Insert(new Descriptions
        {
            id = 24,
            text = "Ursprung: Becken unterer Ast des Schambeins Ansatz: Schienbein- Schienbeinhöcker (medialer Teil)",
            structure_id = 24
        });

        _connection.Insert(new Descriptions
        {
            id = 25,
            text = "Ursprung: Becken - Schambeinkamm am Ramus superior des Schambeins Ansatz: Oberschenkelknochen – Kammlinie (Diaphyse)",
            structure_id = 25
        });

        _connection.Insert(new Descriptions
        {
            id = 26,
            text = "Ursprung: Oberschenkelknochen - Zwischenrollhügellinie (proximale Epiphyse), innere Leiste der rauen Linie (Diaphyse) Ansatz: Schienbein- Schienbeinhocker (über das innere Halteband der Kniescheibe)",
            structure_id = 26
        });

        _connection.Insert(new Descriptions
        {
            id = 27,
            text = "Ursprung: Oberschenkelknochen- Corpus (anteriore Fläche) Ansatz: Schienbein- Schienbeinhöcker (mittels Kniescheibenband)",
            structure_id = 27
        });

        _connection.Insert(new Descriptions
        {
            id = 28,
            text = "Ursprung: Oberschenkelknochen ⁃ großer Rollhügel (proximale Epiphyse), äußere Leiste der rauen Linie (Diaphyse) Ansatz: Schienbein ⁃ Schienbeinhöcker (über das äußere Halteband der Kniescheibe)",
            structure_id = 28
        });

        _connection.Insert(new Descriptions
        {
            id = 29,
            text = "Ursprung: Oberschenkelknochen - Corpus (distaler Teil der anterioren Fläche) Ansatz: Kapsel des Kniegelenks (Bursa suprapatellaris)",
            structure_id = 29
        });

        _connection.Insert(new Descriptions
        {
            id = 30,
            text = "Ursprung: Becken- oberer Ast des Schambeins Ansatz: Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            structure_id = 30
        });

        _connection.Insert(new Descriptions
        {
            id = 31,
            text = "Ursprung: Becken - unterer Ast des Schambeins, Tuber ischiadicum des Sitzbeinastes Ansatz: Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse), Tuberculum adductorium des inneren Gelenkknorrens (distale Epiphyse)",
            structure_id = 31
        });

        _connection.Insert(new Descriptions
        {
            id = 32,
            text = "Ursprung: Wirbelsäule -Querfortsätze der Wirbel L1-L5, Wirbelkörper T12-L4 und Bandscheiben (laterale Seiten) Becken- Darmbeingrube Ansatz: Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            structure_id = 32
        });

        _connection.Insert(new Descriptions
        {
            id = 33,
            text = "Ursprung: Becken- Darmbeingrube Ansatz: Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            structure_id = 33
        });

        _connection.Insert(new Descriptions
        {
            id = 34,
            text = "Ursprung: Wirbelsäule - Querfortsätze der Wirbel L1-L5, Wirbelkörper T12-L4 und Bandscheiben (laterale Seiten) Ansatz: Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            structure_id = 34
        });

        _connection.Insert(new Descriptions
        {
            id = 35,
            text = "Ursprung: Wirbelsäule-Wirbelkörper T12-L1 und Bandscheibe (laterale Seiten) Ansatz: Becken - Schambeinkamm und Darmbein Schambein-Höcker des oberen Schambeinastes",
            structure_id = 35
        });

        _connection.Insert(new Descriptions
        {
            id = 36,
            text = "Ursprung: Beckenm- Tuber ischiadicum des Sitzbeinastes Ansatz: Schienbein - Condylus medialis (proximale Epiphyse). Schräges Kniekehlenband",
            structure_id = 36
        });

        _connection.Insert(new Descriptions
        {
            id = 37,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes, Kreuzbein- Sitzbeinhöcker-Band (Caput longum) Oberschenkelknochen - äußere Leiste der rauen Linie (mittleres 1/3 der Diaphyse - Caput breve) Ansatz: Wadenbein- Spitze des Caput (proximale Epiphyse)",
            structure_id = 37
        });

        _connection.Insert(new Descriptions
        {
            id = 38,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes, Kreuzbein – Sitzbeinhöcker - Band Ansatz: Schienbein – Schienbeinhöcker (medialer Teil)",
            structure_id = 38
        });

        _connection.Insert(new Descriptions
        {
            id = 39,
            text = "Ursprung: Becken – Sitzbeinstachel Ansatz: Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            structure_id = 39
        });

        _connection.Insert(new Descriptions
        {
            id = 40,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes Ansatz: Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            structure_id = 40
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

        _connection.Insert(new Descriptions
        {
            id = 41,
            text = "Ursprung: Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (äußere Fläche). Ansatz: Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse).",
            structure_id = 41
        });

        _connection.Insert(new Descriptions
        {
            id = 42,
            text = "Ursprung: Wirbelsäulen- Beckenflache des Kreuzbeins. Ansatz: Oberschenkelknochen = großer Rollhügel (proximale Epiphyse).",
            structure_id = 42
        });

        _connection.Insert(new Descriptions
        {
            id = 43,
            text = "Ursprung: Becken- Gesäßfläche des Darmbeins (zwischen der anterioren und der posterioren Linea glutealis). Ansatz: Oberschenkelknochen - großer Rollhügel (proximale Epiphyse).",
            structure_id = 43
        });

        _connection.Insert(new Descriptions
        {
            id = 44,
            text = "Ursprung: Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (Innenfläche). Ansatz: Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse).",
            structure_id = 44
        });

        _connection.Insert(new Descriptions
        {
            id = 45,
            text = "Ursprung: Becken- Gesäßfläche des Darmbeins (unterhalb des Darmbeinkamms zwischen der anterioren und der posterioren Linea glutealis). Ansatz: Oberschenkelknochen - großer Rollhügel (proximale Epiphyse).",
            structure_id = 45
        });

        _connection.Insert(new Descriptions
        {
            id = 46,
            text = "Ursprung: Becken- vorderer unterer Darmbeinstachel, Oberrand der Hüftgelenkspfanne (Acetabulum). Ansatz: Schienbein - Schienbeinhöcker (mittels Kniescheibenband).",
            structure_id = 46
        });

        _connection.Insert(new Descriptions
        {
            id = 47,
            text = "Ursprung: Becken - oberer vorderer Darmbeinstachel. Ansatz: Schienbein - Schienbeinhöcker (medialer Teil).",
            structure_id = 47
        });

        _connection.Insert(new Descriptions
        {
            id = 48,
            text = "Ursprung: Wirbelsäule - dorsale Kreuzbeinoberfläche, Fascia thoracolumbalis. Becken- Gesäßfläche des Darmbeins, Kreuzbein- Sitzbeinhöcker-Band. Ansatz: Darmbein-schienbein-Band Oberschenkelknochen - Gesäßmuskelrauigkeit (Diaphyse).",
            structure_id = 48
        });

        _connection.Insert(new Descriptions
        {
            id = 49,
            text = "Ursprung: Becken - oberer vorderer Darmbeinstachel. Ansatz: Darmbein-Schienbein-Band.",
            structure_id = 49
        });

        _connection.Insert(new Descriptions
        {
            id = 50,
            text = "Ursprung: Becken- Tuber ischiadicum des Sitzbeinastes (laterale Kante). Ansatz: Oberschenkelknochen - quadratischer Höcker der Zwischenrollhügelleiste (proximale Epiphyse).",
            structure_id = 50
        });

        _connection.Insert(new Descriptions
        {
            id = 51,
            text = "Ursprung: Oberschenkelknochen - Sulcus popliteus des äußeren Gelenkknorrens (distale Epiphyse). Ansatz: Schienbein- Hinterfläche (proximaler Teil der Diaphyse).",
            structure_id = 51
        });

        _connection.Insert(new Descriptions
        {
            id = 52,
            text = "Ursprung: Oberschenkelknochen - Epicondylus lateralis des äußeren Gelenkknorrens (distale Epiphyse). Schräges Kniekehlenband. Ansatz: Fuß - Fersenbeinhöcker.",
            structure_id = 52
        });

        _connection.Insert(new Descriptions
        {
            id = 53,
            text = "Ursprung: Schienbein- Hinterfläche (proximale 2/3 der Diaphyse). Zwischenknochenmembran des Unterschenkels. Wadenbein - Hinterfläche (proximale 2/3 der Diaphyse). Ansatz: Fuß - Tuberositas des Kahnbeins, inneres, mittleres und äußeres Keilbein, Basen der Mittelfußknochen II-IV (Unterseiten).",
            structure_id = 53
        });

        _connection.Insert(new Descriptions
        {
            id = 54,
            text = "Ursprung: Wadenbein mediale Fläche (distale 2/3 der Diaphyse). Zwischenknochenmembran des Unterschenkels. Ansatz: Dorsalaponeurose der Zehen.",
            structure_id = 54
        });

        _connection.Insert(new Descriptions
        {
            id = 55,
            text = "Ursprung: Wadenbein- laterale Fläche (distale 2/3 der Diaphyse). Zwischenmuskelscheidewände des Unterschenkels (Septum intermusculare cruris). Ansatz: Fuß - Tuberositas der Basis des 5. Mittelfußknochens (laterale Fläche).",
            structure_id = 55
        });

        _connection.Insert(new Descriptions
        {
            id = 56,
            text = "Ursprung: Wadenbein - vordere Kante (distales 1/3 der Diaphyse). Ansatz: Fuß - Basis des 5. Mittelfußknochens (Rückfläche).",
            structure_id = 56
        });

        _connection.Insert(new Descriptions
        {
            id = 57,
            text = "Ursprung: Wadenbein- Hinterfläche (distale 2/3 der Diaphyse). Zwischenknochenmembran des Unterschenkels. Ansatz: Fuß - Basis des Endglieds der Großzehe (Unterseite).",
            structure_id = 57
        });

        _connection.Insert(new Descriptions
        {
            id = 58,
            text = "Ursprung: Schienbein- Hinterfläche (mittleres 1/3 der Diaphyse). Ansatz: Fuß - Basen der Endphalangen der Zehen II-V (Unterseiten).",
            structure_id = 58
        });

        _connection.Insert(new Descriptions
        {
            id = 59,
            text = "Ursprung: Schienbein - laterale Fläche (proximale 2/3 der Diaphyse). Zwischenknochenmembran des Unterschenkels. Ansatz: Fuß - inneres Keilbein, Basis des 1. Mittelfußknochens (mediale und untere Seite).",
            structure_id = 59
        });

        _connection.Insert(new Descriptions
        {
            id = 60,
            text = "Ursprung: Schienbein- lateraler Kondylus (proximale Epiphyse). Wadenbein- Caput (proximale Epiphyse), mediale Fläche (Diaphyse), Zwischenknochenmembran des Unterschenkels. Ansatz: Dorsalaponeurose der Zehen.",
            structure_id = 60
        });

        _connection.Insert(new Descriptions
        {
            id = 61,
            text = "Ursprung: Wadenbein - Caput (proximale Epiphyse). laterale Fläche und vordere Kante (Diaphyse). Zwischenmuskelscheidewände des Unterschenkels (Septum Intermusculare cruris). Ansatz: Fuß - mittleres Keilbein, Tuberositas der Basis des 1. Mittelfußknochens (Unterseiten).",
            structure_id = 61
        });

        _connection.Insert(new Descriptions
        {
            id = 62,
            text = "Ursprung: Wadenbein- Caput (proximale Epiphyse), Dorsalfläche und dorsale Kante (proximales 1/4 der Diaphyse). Schienbein - Linea musculi solei auf der Dorsalseite und mediale Kante (Diaphyse). Ansatz: Fuß - Fersenbeinhöcker.",
            structure_id = 62
        });

        _connection.Insert(new Descriptions
        {
            id = 63,
            text = "Ursprung: Oberschenkelknochen Epicondylus lateralis des äußeren Gelenkknorrens, Epicondylus medialis des inneren Gelenkknorrens (distale Epiphyse). Ansatz: Fuß - Fersenbeinhöcker.",
            structure_id = 63
        });

        _connection.Insert(new Descriptions
        {
            id = 64,
            text = "Ursprung: Kurzer Wadenbelnmuskel (distale Sehne) und langes Fußsohlenband. Ansatz: Fuß - Basis des 5.Mittelfußknochens (untere Fläche).",
            structure_id = 64
        });

        _connection.Insert(new Descriptions
        {
            id = 65,
            text = "Ursprung: Fuß - medialer und lateraler Fortsatz des Fersenbeinhöckers, Plantaraponeurose. Ansatz: Fuß - Tuberositas der Basis des 5. Mittelfußknochens und Basis des Kleinzehengrundglieds (untere Seiten).",
            structure_id = 65
        });

        _connection.Insert(new Descriptions
        {
            id = 66,
            text = "Ursprung: Fuß - Basis des 5. Mittelfußknochens (untere Fläche), Langes Fußsohlenband. Ansatz: Fuß - Basis der proximalen Phalanx der Kleinzehe (Unterseite).",
            structure_id = 66
        });

        _connection.Insert(new Descriptions
        {
            id = 67,
            text = "Ursprung: Becken - unterer Ast des Schambeins. Ansatz: Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse).",
            structure_id = 67
        });

        _connection.Insert(new Descriptions
        {
            id = 68,
            text = "Ursprung: Becken - unterer Ast des Schambeins. Ansatz: Schienbein - Schienbeinhöcker (medialer Teil).",
            structure_id = 68
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

        _connection.Insert(new Descriptions
        {
            id = 69,
            text = "Ursprung: Becken - Schambeinkamm am Ramus superior des Schambeins. Ansatz: Oberschenkelknochen – Kammlinie (Diaphyse).",
            structure_id = 69
        });

        _connection.Insert(new Descriptions
        {
            id = 70,
            text = "Ursprung: Oberschenkelknochen - Zwischenrollhügellinie (proximale Epiphyse), innere Leiste der rauen Linie (Diaphyse). Ansatz: Schienbein - Schienbeinhöcker (über das innere Halteband der Kniescheibe).",
            structure_id = 70
        });

        _connection.Insert(new Descriptions
        {
            id = 71,
            text = "Ursprung: Oberschenkelknochen - Corpus (anteriore Fläche). Ansatz: Schienbein - Schienbeinhöcker (mittels Kniescheibenband).",
            structure_id = 71
        });

        _connection.Insert(new Descriptions
        {
            id = 72,
            text = "Ursprung: Oberschenkelknochen - großer Rollhügel (proximale Epiphyse), äußere Leiste der rauen Linie (Diaphyse). Ansatz: Schienbein - Schienbeinhöcker (über das äußere Halteband der Kniescheibe).",
            structure_id = 72
        });

        _connection.Insert(new Descriptions
        {
            id = 73,
            text = "Ursprung: Oberschenkelknochen - Corpus (distaler Teil der anterioren Fläche). Ansatz: Kapsel des Kniegelenks (Bursa suprapatellaris).",
            structure_id = 73
        });

        _connection.Insert(new Descriptions
        {
            id = 74,
            text = "Ursprung: Becken - oberer Ast des Schambeins. Ansatz: Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse).",
            structure_id = 74
        });

        _connection.Insert(new Descriptions
        {
            id = 75,
            text = "Ursprung: Becken - unterer Ast des Schambeins, Tuber ischiadicum des Sitzbeinastes. Ansatz: Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse), Tuberculum adductorium des inneren Gelenkknorrens (distale Epiphyse).",
            structure_id = 75
        });

        _connection.Insert(new Descriptions
        {
            id = 76,
            text = "Ursprung: Wirbelsäule - Querfortsätze der Wirbel L1-L5, Wirbelkörper T12-L4 und Bandscheiben (laterale Seiten), Becken - Darmbeingrube. Ansatz: Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse).",
            structure_id = 76
        });

        _connection.Insert(new Descriptions
        {
            id = 77,
            text = "Ursprung: Becken - Darmbeingrube. Ansatz: Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse).",
            structure_id = 77
        });

        _connection.Insert(new Descriptions
        {
            id = 78,
            text = "Ursprung: Wirbelsäule - Querfortsätze der Wirbel L1-L5, Wirbelkörper T12-L4 und Bandscheiben (laterale Seiten). Ansatz: Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse).",
            structure_id = 78
        });

        _connection.Insert(new Descriptions
        {
            id = 79,
            text = "Ursprung: Wirbelsäule - Wirbelkörper T12-L1 und Bandscheibe (laterale Seiten). Ansatz: Becken - Schambeinkamm und Darmbein, Schambein-Höcker des oberen Schambeinastes, Arcus iliopectineus.",
            structure_id = 79
        });

        _connection.Insert(new Descriptions
        {
            id = 80,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes. Ansatz: Schienbein - Condylus medialis (proximale Epiphyse), Schräges Kniekehlenband.",
            structure_id = 80
        });

        _connection.Insert(new Descriptions
        {
            id = 81,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes, Kreuzbein-Sitzbeinhöcker-Band (Caput longum). Oberschenkelknochen - äußere Leiste der rauen Linie (mittleres 1/3 der Diaphyse - Caput breve). Ansatz: Wadenbein - Spitze des Caput (proximale Epiphyse).",
            structure_id = 81
        });

        _connection.Insert(new Descriptions
        {
            id = 82,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes, Kreuzbein - Sitzbeinhöcker-Band. Ansatz: Schienbein - Schienbeinhöcker (medialer Teil).",
            structure_id = 82
        });

        _connection.Insert(new Descriptions
        {
            id = 83,
            text = "Ursprung: Becken - Sitzbeinstachel. Ansatz: Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse).",
            structure_id = 83
        });

        _connection.Insert(new Descriptions
        {
            id = 84,
            text = "Ursprung: Becken - Tuber ischiadicum des Sitzbeinastes. Ansatz: Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse).",
            structure_id = 84
        });

        _connection.Insert(new Descriptions
        {
            id = 85,
            text = "Ursprung: Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (äußere Fläche). Ansatz: Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse).",
            structure_id = 85
        });

        _connection.Insert(new Descriptions
        {
            id = 86,
            text = "Ursprung: Wirbelsäule - Beckenfläche des Kreuzbeins. Ansatz: Oberschenkelknochen - großer Rollhügel (proximale Epiphyse).",
            structure_id = 86
        });

        _connection.Insert(new Descriptions
        {
            id = 87,
            text = "Ursprung: Becken - Gesäßfläche des Darmbeins (zwischen der anterioren und der posterioren Linea glutealis). Ansatz: Oberschenkelknochen - großer Rollhügel (proximale Epiphyse).",
            structure_id = 87
        });

        _connection.Insert(new Descriptions
        {
            id = 88,
            text = "Ursprung: Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (Innenfläche). Ansatz: Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse).",
            structure_id = 88
        });

        _connection.Insert(new Descriptions
        {
            id = 89,
            text = "Ursprung: Becken- Gesäßfläche des Darmbeins (unterhalb des Darmbeinkamms zwischen der anterioren und der posterioren Linea glutealis). Ansatz: Oberschenkelknochen - großer Rollhügel (proximale Epiphyse).",
            structure_id = 89
        });

        _connection.Insert(new Descriptions
        {
            id = 90,
            text = "Ursprung: Becken- vorderer unterer Darmbeinstachel, Oberrand der Hüftgelenkspfanne (Acetabulum). Ansatz: Schienbein - Schienbeinhöcker (mittels Kniescheibenband).",
            structure_id = 90
        });

        _connection.Insert(new Descriptions
        {
            id = 91,
            text = "Ursprung: Becken ⁃ oberer vorderer Darmbeinstachel. Ansatz: Schienbein ⁃ Schienbeinhöcker (medialer Teil).",
            structure_id = 91
        });

        _connection.Insert(new Descriptions
        {
            id = 92,
            text = "Ursprung: Wirbelsäule - dorsale Kreuzbeinoberfläche, Fascia thoracolumbalis. Becken- Gesäßfläche des Darmbeins, Kreuzbein-Sitzbeinhöcker-Band. Ansatz: Darmbein-schienbein-Band, Oberschenkelknochen - Gesäßmuskelrauigkeit (Diaphyse).",
            structure_id = 92
        });

        _connection.Insert(new Descriptions
        {
            id = 93,
            text = "Ursprung: Becken - oberer vorderer Darmbeinstachel. Ansatz: Darmbein-Schienbein-Band.",
            structure_id = 93
        });

        _connection.Insert(new Descriptions
        {
            id = 94,
            text = "Ursprung: Becken- Tuber ischiadicum des Sitzbeinastes (laterale Kante). Ansatz: Oberschenkelknochen - quadratischer Höcker der Zwischenrollhügelleiste (proximale Epiphyse).",
            structure_id = 94
        });

        _connection.Insert(new Descriptions
        {
            id = 95,
            text = "Ursprung: Oberschenkelknochen - Sulcus popliteus des äußeren Gelenkknorrens (distale Epiphyse). Ansatz: Schienbein- Hinterfläche (proximaler Teil der Diaphyse).",
            structure_id = 95
        });

        _connection.Insert(new Descriptions
        {
            id = 96,
            text = "Ursprung: Oberschenkelknochen - Epicondylus lateralis des äußeren Geienkknorrens (distale Epiphyse). Ansatz: Fuß -Fersenbeinhöcker.",
            structure_id = 96
        });

        _connection.Insert(new Descriptions
        {
            id = 97,
            text = "Ursprung: Schienbein- Hinterfläche (proximale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Wadenbein - Hinterfläche (proximale 2/3 der Diaphyse). Ansatz: Fuß - Tuberositas des Kahnbeins, inneres, mittleres und äußeres Keilbein, Basen der Mittelfußknochen II-IV (Unterseiten).",
            structure_id = 97
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

        _connection.Insert(new Descriptions
        {
            id = 98,
            text = "Ursprung: Wadenbein mediale Fläche (distale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels. Ansatz: Dorsalaponeurose der Zehen.",
            structure_id = 98
        });

        _connection.Insert(new Descriptions
        {
            id = 99,
            text = "Ursprung: Wadenbein- laterale Fläche (distale 2/3 der Diaphyse), Zwischenmuskelscheidewände des Unterschenkels (Septum intermusculare cruris). Ansatz: Fuß - Tuberositas der Basis des 5. Mittelfußknochens (laterale Fläche).",
            structure_id = 99
        });

        _connection.Insert(new Descriptions
        {
            id = 100,
            text = "Ursprung: Wadenbein - vordere Kante (distales 1/3 der Diaphyse). Ansatz: Fuß - Basis des 5. Mittelfußknochens (Rückfläche).",
            structure_id = 100
        });

        _connection.Insert(new Descriptions
        {
            id = 101,
            text = "Ursprung: Wadenbein- Hinterfläche (distale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels. Ansatz: Fuß - Basis des Endglieds der Großzehe (Unterseite).",
            structure_id = 101
        });

        _connection.Insert(new Descriptions
        {
            id = 102,
            text = "Ursprung: Schienbein- Hinterfläche (mittleres 1/3 der Diaphyse). Ansatz: Fuß - Basen der Endphalangen der Zehen II-V (Unterseiten).",
            structure_id = 102
        });

        _connection.Insert(new Descriptions
        {
            id = 103,
            text = "Ursprung: Schienbein - laterale Flache (proximale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels. Ansatz: Fuß - inneres Keilbein, Basis des 1. Mittelfußknochens (mediale und untere Seite).",
            structure_id = 103
        });

        _connection.Insert(new Descriptions
        {
            id = 104,
            text = "Ursprung: Schienbein- lateraler Kondylus (proximale Epiphyse), Wadenbein- Caput (proximale Epiphyse), mediale Fläche (Diaphyse), Zwischenknochenmembran des Unterschenkels. Ansatz: Dorsalaponeurose der Zehen.",
            structure_id = 104
        });

        _connection.Insert(new Descriptions
        {
            id = 105,
            text = "Ursprung: Wadenbein - Caput (proximale Epiphyse), laterale Fläche und vordere Kante (Diaphyse), Zwischenmuskelscheidewände des Unterschenkels (Septum Intermusculare cruris). Ansatz: Fuß - mittleres Keilbein, Tuberositas der Basis des 1. Mittelfußknochens (Unterseiten).",
            structure_id = 105
        });

        _connection.Insert(new Descriptions
        {
            id = 106,
            text = "Ursprung: Wadenbein- Caput (proximale Epiphyse), Dorsalfläche und dorsale Kante (proximales 1/4 der Diaphyse), Schienbein - Linea musculi solei auf der Dorsalseite und mediale Kante (Diaphyse). Ansatz: Fuß -Fersenbeinhöcker.",
            structure_id = 106
        });

        _connection.Insert(new Descriptions
        {
            id = 107,
            text = "Ursprung: Oberschenkelknochen Epicondylus lateralis des äußeren Gelenkknorrens, Epicondylus medialis des inneren Gelenkknorrens (distale Epiphyse). Ansatz: Fuß - Fersenbeinhöcker.",
            structure_id = 107
        });

        _connection.Insert(new Descriptions
        {
            id = 108,
            text = "Ursprung: Kurzer Wadenbeinnuskel (distale Sehne) und langes Fußsohlenband. Ansatz: Fuß - Basis des 5.Mittelfußknochens (untere Fläche).",
            structure_id = 108
        });

        _connection.Insert(new Descriptions
        {
            id = 109,
            text = "Ursprung: Fuß - medialer und lateraler Fortsatz des Fersenbeinhöckers, Plantaraponeurose. Ansatz: Fuß - Tuberositas der Basis des 5. Mittelfußknochens und Basis des Kleinzehengrundglieds (untere Seiten).",
            structure_id = 109
        });

        _connection.Insert(new Descriptions
        {
            id = 110,
            text = "Ursprung: Fuß - Basis des 5. Mittelfußknochens (untere Fläche), Langes Fußsohlenband. Ansatz: Fuß - Basis der proximalen Phalanx der Kleinzehe (Unterseite).",
            structure_id = 110
        });

        _connection.Insert(new Descriptions
        {
            id = 111,
            text = "Ursprung: Corpora von jeweils zwei benachbarten Mittelfußknochen (an den gegenüber liegenden Flächen). Ansatz: Dorsalaponeurose der Zehen.",
            structure_id = 111
        });

        _connection.Insert(new Descriptions
        {
            id = 112,
            text = "Ursprung: Corpora von jeweils zwei benachbarten Mittelfußknochen (an den gegenüber liegenden Flächen). Ansatz: Dorsalaponeurose der Zehen.",
            structure_id = 112
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

        Debug.Log(query);
        Debug.Log(searchPattern);
        Debug.Log(searchPattern);
        Debug.Log(startsWithPattern);
        Debug.Log(startsWithPattern);

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
