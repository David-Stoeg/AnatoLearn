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


        //Becken Muskeln
        _connection.Insert(new AnatomicalStructures
        {
            id = 0,
            latin_name = "Musculus transversus perinei profundus (dex.)",
            german_name = "Tiefer querer Dammmuskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 1,
            latin_name = "Musculus transversus perinei profundus (sin.)",
            german_name = "Tiefer querer Dammmuskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 2,
            latin_name = "Musculus transversus perinei superficialis (dex.)",
            german_name = "Oberflächlicher querer Dammmuskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 3,
            latin_name = "Musculus transversus perinei superficialis (sin.)",
            german_name = "Oberflächlicher querer Dammmuskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 4,
            latin_name = "Musculus ischiocavernosus (dex.)",
            german_name = "Sitzbein-Schwellkörper-Muskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 5,
            latin_name = "Musculus ischiocavernosus (sin.)",
            german_name = "Sitzbein-Schwellkörper-Muskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 6,
            latin_name = "Musculus bulbospongiosus (dex.)",
            german_name = "Schwellkörpermuskel der Harnröhre (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 7,
            latin_name = "Musculus bulbospongiosus (sin.)",
            german_name = "Schwellkörpermuskel der Harnröhre (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 8,
            latin_name = "Musculus puborectalis (dex.)",
            german_name = "Schambein-Mastdarm-Muskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 9,
            latin_name = "Musculus puborectalis (sin.)",
            german_name = "Schambein-Mastdarm-Muskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 10,
            latin_name = "Musculus iliococcygeus (dex.)",
            german_name = "Darmbein-Steißbein-Muskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 11,
            latin_name = "Musculus iliococcygeus (sin.)",
            german_name = "Darmbein-Steißbein-Muskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 12,
            latin_name = "Musculus ischiococcygeus (dex.)",
            german_name = "Steißbeinmuskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 13,
            latin_name = "Musculus ischiococcygeus (sin.)",
            german_name = "Steißbeinmuskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 14,
            latin_name = "Musculus quadratus lumborum (dex.)",
            german_name = "Viereckiger Lendenmuskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 15,
            latin_name = "Musculus quadratus lumborum (sin.)",
            german_name = "Viereckiger Lendenmuskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 16,
            latin_name = "Musculus pyramidalis (dex.)",
            german_name = "Pyramidenmuskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 17,
            latin_name = "Musculus pyramidalis (sin.)",
            german_name = "Pyramidenmuskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 18,
            latin_name = "Musculus transversus abdominis (dex.)",
            german_name = "Querer Bauchmuskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 19,
            latin_name = "Musculus transversus abdominis (sin.)",
            german_name = "Querer Bauchmuskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 20,
            latin_name = "Musculus rectus abdominis (dex.)",
            german_name = "Gerader Bauchmuskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 21,
            latin_name = "Musculus rectus abdominis (sin.)",
            german_name = "Gerader Bauchmuskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 22,
            latin_name = "Musculus pubococcygeus (dex.)",
            german_name = "Schambein-Steißbein-Muskel (re.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 23,
            latin_name = "Musculus pubococcygeus (sin.)",
            german_name = "Schambein-Steißbein-Muskel (li.)",
            category = "Becken Muskeln",
            parentId = 0
        });

        //Becken Descriptions
        _connection.Insert(new Descriptions
        {
            id = 0,
            ansatz = "Sitzbeinast und Unterer Ast des Schambeins (Innenflächen), Dammkörper",
            innervation = "Dammnerv (re.) S1-S4",
            funktion = "Unterstützung des Beckenbodens und der Organe; Stabilisation des Damms",
            structure_id = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 1,
            ansatz = "Sitzbeinast und Unterer Ast des Schambeins (Innenflächen), Dammkörper",
            innervation = "Dammnerv (li.) S1-S4",
            funktion = "Unterstützung des Beckenbodens und der Organe; Stabilisation des Damms",
            structure_id = 1
        });
        _connection.Insert(new Descriptions
        {
            id = 2,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes (Innenfläche), Dammkörper",
            innervation = "Dammnerv (re.) S1-S4",
            funktion = "Unterstützung des Damms, Stabilisation der Beckenbodenregion",
            structure_id = 2
        });
        _connection.Insert(new Descriptions
        {
            id = 3,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes (Innenfläche), Dammkörper",
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
            ansatz = "Dammkörper, Bindegewebshülle des Harnröhrenschwellkörpers",
            innervation = "Schamnerv (re.) S2-S4",
            funktion = "Unterstützung der Harnröhrenkontrolle, Stabilisierung der Genitalregion",
            structure_id = 6
        });
        _connection.Insert(new Descriptions
        {
            id = 7,
            ansatz = "Dammkörper, Bindegewebshülle des Harnröhrenschwellkörpers",
            innervation = "Schamnerv (li.) S2-S4",
            funktion = "Unterstützung der Harnröhrenkontrolle, Stabilisierung der Genitalregion",
            structure_id = 7
        });
        _connection.Insert(new Descriptions
        {
            id = 8,
            ansatz = "Becken - Sitzbein-Schambein-Ast (Innenfläche), After-Steißbein-Band (Ligamentum anococcygeum)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) (re.) - S4",
            funktion = "Unterstützung der Darmschließmuskulatur, Stabilisierung des Enddarms",
            structure_id = 8
        });
        _connection.Insert(new Descriptions
        {
            id = 9,
            ansatz = "Becken - Sitzbein-Schambein-Ast (Innenfläche), After-Steißbein-Band (Ligamentum anococcygeum)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) (li.) - S4",
            funktion = "Unterstützung der Darmschließmuskulatur, Stabilisierung des Enddarms",
            structure_id = 9
        });
        _connection.Insert(new Descriptions
        {
            id = 10,
            ansatz = "Becken - Sitzbeinstachel (Innenfläche), Wirbelsäule - Apex ossis coccygis, After-Steißbein-Band (Ligamentum anococcygeum)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) - S4",
            funktion = "Stabilisierung des Beckenbodens und des Steißbeins",
            structure_id = 10
        });
        _connection.Insert(new Descriptions
        {
            id = 11,
            ansatz = "Becken - Sitzbeinstachel (Innenfläche), Wirbelsäule - Apex ossis coccygis, After-Steißbein-Band (Ligamentum anococcygeum)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) - S4",
            funktion = "Stabilisierung des Beckenbodens und des Steißbeins",
            structure_id = 11
        });
        _connection.Insert(new Descriptions
        {
            id = 12,
            ansatz = "Wirbelsäule - Apex ossis sacri, Steißbein, Kreuzbein-Sitzbeinstachel-Band, Becken - Sitzbeinstachel (Innenfläche)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) S4-S5",
            funktion = "Stabilisierung des Steißbeins und des Beckenbodens",
            structure_id = 12
        });
        _connection.Insert(new Descriptions
        {
            id = 13,
            ansatz = "Wirbelsäule - Apex ossis sacri, Steißbein, Kreuzbein-Sitzbeinstachel-Band, Becken - Sitzbeinstachel (Innenfläche)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) S4-S5",
            funktion = "Stabilisierung des Steißbeins und des Beckenbodens",
            structure_id = 13
        });
        _connection.Insert(new Descriptions
        {
            id = 14,
            ansatz = "Darmbein-Lenden-Band (Lgamentum iliolumbale) Becken - Innere Gruppe des Darmbeinkamms, Brustkorb-Rippenkörper XII (anteroinferiorer Tell)",
            innervation = "Vordere Äste der Spinalnerven (T12, L1-L4)",
            funktion = "Stabilisierung der Lendenwirbelsäule und des Beckens",
            structure_id = 14
        });
        _connection.Insert(new Descriptions
        {
            id = 15,
            ansatz = "Darmbein-Lenden-Band (Lgamentum iliolumbale) Becken - Innere Gruppe des Darmbeinkamms, Brustkorb-Rippenkörper XII (anteroinferiorer Tell)",
            innervation = "Vordere Äste der Spinalnerven (T12, L1-L4)",
            funktion = "Stabilisierung der Lendenwirbelsäule und des Beckens",
            structure_id = 15
        });
        _connection.Insert(new Descriptions
        {
            id = 16,
            ansatz = "Becken - obere Ränder des Schambeinkörpers, Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln)",
            innervation = "Unterrippennerv (T12)",
            funktion = "Stabilisierung der unteren Bauchwand",
            structure_id = 16
        });
        _connection.Insert(new Descriptions
        {
            id = 17,
            ansatz = "Becken - obere Ränder des Schambeinkörpers, Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln)",
            innervation = "Unterrippennerv (T12)",
            funktion = "Stabilisierung der unteren Bauchwand",
            structure_id = 17
        });
        _connection.Insert(new Descriptions
        {
            id = 18,
            ansatz = "Brustkorb- Rlppenkörper VIl-XIl (lnnenfläche),  Fascia thoracolumbalis und Fascia iliolumbalis, Becken - Innere Lippe des Darmbeinkamms und oberer vorderer Darmbeinstachel, Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln), Becken - Schambeinleiste (Crista pubica)",
            innervation = "Rechte Zwischenrippennerven - 17-T12, Hüft-Becken-Nerv (Nervus llohypogastricus) - T12-L1, Hüft-Leisten-Nerv (Nervus ilioinguinalis) - L1-L4",
            funktion = "Stabilisierung des Rumpfes, Unterstützung des Beckenbodens",
            structure_id = 18
        });
        _connection.Insert(new Descriptions
        {
            id = 19,
            ansatz = "Brustkorb- Rlppenkörper VIl-XIl (lnnenfläche),  Fascia thoracolumbalis und Fascia iliolumbalis, Becken - Innere Lippe des Darmbeinkamms und oberer vorderer Darmbeinstachel, Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln), Becken - Schambeinleiste (Crista pubica)",
            innervation = "Rechte Zwischenrippennerven - 17-T12, Hüft-Becken-Nerv (Nervus llohypogastricus) - T12-L1, Hüft-Leisten-Nerv (Nervus ilioinguinalis) - L1-L4",
            funktion = "Stabilisierung des Rumpfes, Unterstützung des Beckenbodens",
            structure_id = 19
        });
        _connection.Insert(new Descriptions
        {
            id = 20,
            ansatz = "Becken - zwischen Schambeinhöcker und Symphysis pubica, Brustkorb - Processus iphoideus sterni, Rippenknorpel V-VII",
            innervation = "Zwischenrippennerven (T5-T12)",
            funktion = "Flexion des Rumpfes, Unterstützung der inneren Organe",
            structure_id = 20
        });
        _connection.Insert(new Descriptions
        {
            id = 21,
            ansatz = "Becken - zwischen Schambeinhöcker und Symphysis pubica, Brustkorb - Processus iphoideus sterni, Rippenknorpel V-VII",
            innervation = "Zwischenrippennerven (T5-T12)",
            funktion = "Flexion des Rumpfes, Unterstützung der inneren Organe",
            structure_id = 21
        });
        _connection.Insert(new Descriptions
        {
            id = 22,
            ansatz = "Becken – Schambeinkörper (Innenfläche), Wirbelsäule – Apex ossis coccygis, After-Steißbein-Band (Ligamentum anococcygeum)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) - S4",
            funktion = "Stabilisierung des Rumpfes, Unterstützung der inneren Organe",
            structure_id = 22
        });
        _connection.Insert(new Descriptions
        {
            id = 23,
            ansatz = "Becken – Schambeinkörper (Innenfläche), Wirbelsäule – Apex ossis coccygis, After-Steißbein-Band (Ligamentum anococcygeum)",
            innervation = "Äste des Kreuzbeinnervengeflechts (Rami plexus sacralis) - S4",
            funktion = "Stabilisierung des Rumpfes, Unterstützung der inneren Organe",
            structure_id = 23
        });

        //Zwerchfell
        _connection.Insert(new AnatomicalStructures
        {
            id = 24,
            latin_name = "Diaphragma thoracicum",
            german_name = "Zwerchfell",
            category = "Becken Muskeln",
            parentId = 0
        });

        //ZwerchfellDescription
        _connection.Insert(new Descriptions
        {
            id = 24,
            ansatz = "Brustkorb - Processus xiphoideus sterni, untere Rippenbogenränder, Rippenkörper VII-XIl (Innenflächen), Ligamentum arcuatum medianum und laterale Wirbelsäule - Wirbelkörper L1-L3, Bandscheiben, Ligamentum longitudinale anterius, Centrum tendineum",
            innervation = "Zwerchfellnerven (C3-C5)",
            funktion = "Atemfunktion, Unterstützung des Beckenbodens",
            structure_id = 24
        });

        //Bein Muskeln
        _connection.Insert(new AnatomicalStructures
        {
            id = 25,
            latin_name = "Musculus adductor brevis (dex.)",
            german_name = "Kurzer Schenkelanzieher (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 26,
            latin_name = "Musculus adductor brevis (sin.)",
            german_name = "Kurzer Schenkelanzieher (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 27,
            latin_name = "Musculus gracilis (dex.)",
            german_name = "Schlanker Muskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 28,
            latin_name = "Musculus gracilis (sin.)",
            german_name = "Schlanker Muskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 29,
            latin_name = "Musculus pectineus (dex.)",
            german_name = "Kammmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 30,
            latin_name = "Musculus pectineus (sin.)",
            german_name = "Kammmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 31,
            latin_name = "Musculus vastus medialis (dex.)",
            german_name = "Innerer Schenkelmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 32,
            latin_name = "Musculus vastus medialis (sin.)",
            german_name = "Innerer Schenkelmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 33,
            latin_name = "Musculus vastus intermedius (dex.)",
            german_name = "Mittlerer Schenkelmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 34,
            latin_name = "Musculus vastus intermedius (sin.)",
            german_name = "Mittlerer Schenkelmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 25,
            ansatz = "Becken unterer Ast des Schambeins, Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            innervation = "Hüftlochnerv - L2-L3",
            funktion = "Adduktion und Flexion des Oberschenkels",
            structure_id = 25
        });
        _connection.Insert(new Descriptions
        {
            id = 26,
            ansatz = "Becken unterer Ast des Schambeins, Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            innervation = "Hüftlochnerv - L2-L3",
            funktion = "Adduktion und Flexion des Oberschenkels",
            structure_id = 26
        });
        _connection.Insert(new Descriptions
        {
            id = 27,
            ansatz = "Becken unterer Ast des Schambeins, Schienbein - Schienbeinhöcker (medialer Teil)",
            innervation = "Hüftlochnerv - L2-L3",
            funktion = "Adduktion des Oberschenkels, Flexion und Innenrotation des Knies",
            structure_id = 27
        });
        _connection.Insert(new Descriptions
        {
            id = 28,
            ansatz = "Becken unterer Ast des Schambeins, Schienbein - Schienbeinhöcker (medialer Teil)",
            innervation = "Hüftlochnerv - L2-L3",
            funktion = "Adduktion des Oberschenkels, Flexion und Innenrotation des Knies",
            structure_id = 28
        });
        _connection.Insert(new Descriptions
        {
            id = 29,
            ansatz = "Becken - Schambeinkamm am Ramus superior des Schambeins, Oberschenkelknochen – Kammlinie (Diaphyse)",
            innervation = "Hüftlochnerv und Schenkelnerv - L2-L3",
            funktion = "Adduktion, Flexion und Außenrotation des Oberschenkels",
            structure_id = 29
        });
        _connection.Insert(new Descriptions
        {
            id = 30,
            ansatz = "Becken - Schambeinkamm am Ramus superior des Schambeins, Oberschenkelknochen – Kammlinie (Diaphyse)",
            innervation = "Hüftlochnerv und Schenkelnerv - L2-L3",
            funktion = "Adduktion, Flexion und Außenrotation des Oberschenkels",
            structure_id = 30
        });
        _connection.Insert(new Descriptions
        {
            id = 31,
            ansatz = "Oberschenkelknochen - Zwischenrollhügellinie (proximale Epiphyse), innere Leiste der rauen Linie (Diaphyse), Schienbein - Schienbeinhöcker (über das innere Halteband der Kniescheibe)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 31
        });
        _connection.Insert(new Descriptions
        {
            id = 32,
            ansatz = "Oberschenkelknochen - Zwischenrollhügellinie (proximale Epiphyse), innere Leiste der rauen Linie (Diaphyse), Schienbein - Schienbeinhöcker (über das innere Halteband der Kniescheibe)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 32
        });
        _connection.Insert(new Descriptions
        {
            id = 33,
            ansatz = "Oberschenkelknochen - Corpus (anteriore Fläche), Schienbein - Schienbeinhöcker (mittels Kniescheibenband)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 33
        });
        _connection.Insert(new Descriptions
        {
            id = 34,
            ansatz = "Oberschenkelknochen - Corpus (anteriore Fläche), Schienbein - Schienbeinhöcker (mittels Kniescheibenband)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 34
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 35,
            latin_name = "Musculus vastus lateralis (dex.)",
            german_name = "Äußerer Schenkelmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 36,
            latin_name = "Musculus vastus lateralis (sin.)",
            german_name = "Äußerer Schenkelmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 37,
            latin_name = "Musculus articularis genus (dex.)",
            german_name = "Musculus articularis genus (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 38,
            latin_name = "Musculus articularis genus (sin.)",
            german_name = "Musculus articularis genus (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 39,
            latin_name = "Musculus adductor longus (dex.)",
            german_name = "Langer Schenkelanzieher (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 40,
            latin_name = "Musculus adductor longus (sin.)",
            german_name = "Langer Schenkelanzieher (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 41,
            latin_name = "Musculus adductor magnus (dex.)",
            german_name = "Großer Schenkelanzieher (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 42,
            latin_name = "Musculus adductor magnus (sin.)",
            german_name = "Großer Schenkelanzieher (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 43,
            latin_name = "Musculus iliopsoae (dex.)",
            german_name = "Hüft-Lenden-Muskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 44,
            latin_name = "Musculus iliopsoae (sin.)",
            german_name = "Hüft-Lenden-Muskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 35,
            ansatz = "Oberschenkelknochen – großer Rollhügel (proximale Epiphyse), äußere Leiste der rauen Linie (Diaphyse), Schienbein – Schienbeinhöcker (über das äußere Halteband der Kniescheibe)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 35
        });
        _connection.Insert(new Descriptions
        {
            id = 36,
            ansatz = "Oberschenkelknochen – großer Rollhügel (proximale Epiphyse), äußere Leiste der rauen Linie (Diaphyse), Schienbein – Schienbeinhöcker (über das äußere Halteband der Kniescheibe)",
            innervation = "Schenkelnerv - L2-L4",
            funktion = "Streckung des Knies",
            structure_id = 36
        });
        _connection.Insert(new Descriptions
        {
            id = 37,
            ansatz = "Oberschenkelknochen - Corpus (distaler Teil der anterioren Fläche), Kapsel des Kniegelenks (Bursa suprapatellaris)",
            innervation = "Schenkelnerv - L2-L3",
            funktion = "Stabilisierung der Kniescheibe während der Bewegung",
            structure_id = 37
        });
        _connection.Insert(new Descriptions
        {
            id = 38,
            ansatz = "Oberschenkelknochen - Corpus (distaler Teil der anterioren Fläche), Kapsel des Kniegelenks (Bursa suprapatellaris)",
            innervation = "Schenkelnerv - L2-L3",
            funktion = "Stabilisierung der Kniescheibe während der Bewegung",
            structure_id = 38
        });
        _connection.Insert(new Descriptions
        {
            id = 39,
            ansatz = "Becken - oberer Ast des Schambeins, Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            innervation = "Hüftlochnerv - L2-L4",
            funktion = "Adduktion und Flexion des Oberschenkels",
            structure_id = 39
        });
        _connection.Insert(new Descriptions
        {
            id = 40,
            ansatz = "Becken - oberer Ast des Schambeins, Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse)",
            innervation = "Hüftlochnerv - L2-L4",
            funktion = "Adduktion und Flexion des Oberschenkels",
            structure_id = 40
        });
        _connection.Insert(new Descriptions
        {
            id = 41,
            ansatz = "Becken - unterer Ast des Schambeins, Tuber ischiadicum des Sitzbeinastes, Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse), Tuberculum adductorium des inneren Gelenkknorrens (distale Epiphyse)",
            innervation = "Hüftlochnerv - L2-L4, Schienbeinnerv L4",
            funktion = "Adduktion und Flexion des Oberschenkels, Extension des Oberschenkels",
            structure_id = 41
        });
        _connection.Insert(new Descriptions
        {
            id = 42,
            ansatz = "Becken - unterer Ast des Schambeins, Tuber ischiadicum des Sitzbeinastes, Oberschenkelknochen - innere Leiste der rauen Linie (Diaphyse), Tuberculum adductorium des inneren Gelenkknorrens (distale Epiphyse)",
            innervation = "Hüftlochnerv - L2-L4, Schienbeinnerv L4",
            funktion = "Adduktion und Flexion des Oberschenkels, Extension des Oberschenkels",
            structure_id = 42
        });
        _connection.Insert(new Descriptions
        {
            id = 43,
            ansatz = "Wirbelsäule - Querfortsätze der Wirbel L1-L5, Wirbelkörper T12-L4 und Bandscheiben (laterale Seiten), Becken – Darmbeingrube, Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Rechte vordere Äste der Spinalnerven - L1-L3, Schenkelnerv - L2-L3",
            funktion = "Flexion des Oberschenkels, Stabilisierung des Beckens, Aufrichten des Oberkörpers",
            structure_id = 43
        });
        _connection.Insert(new Descriptions
        {
            id = 44,
            ansatz = "Wirbelsäule - Querfortsätze der Wirbel L1-L5, Wirbelkörper T12-L4 und Bandscheiben (laterale Seiten), Becken – Darmbeingrube, Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Linke vordere Äste der Spinalnerven - L1-L3, Schenkelnerv - L2-L3",
            funktion = "Flexion des Oberschenkels, Stabilisierung des Beckens, Aufrichten des Oberkörpers",
            structure_id = 44
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 45,
            latin_name = "Musculus iliacus (dex.)",
            german_name = "Darmbeinmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 46,
            latin_name = "Musculus iliacus (sin.)",
            german_name = "Darmbeinmuskel (sin.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 47,
            latin_name = "Musculus major psoae (dex.)",
            german_name = "Großer Lendenmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 48,
            latin_name = "Musculus major psoae (sin.)",
            german_name = "Großer Lendenmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 49,
            latin_name = "Musculus minor psoae (dex.)",
            german_name = "Kleiner Lendenmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 50,
            latin_name = "Musculus minor psoae (sin.)",
            german_name = "Kleiner Lendenmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 51,
            latin_name = "Musculus semimembranosus (dex.)",
            german_name = "Plattensehnenmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 52,
            latin_name = "Musculus semimembranosus (sin.)",
            german_name = "Plattensehnenmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 53,
            latin_name = "Musculus biceps femoris (dex.)",
            german_name = "Zweiköpfiger Schenkelmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 54,
            latin_name = "Musculus biceps femoris (sin.)",
            german_name = "Zweiköpfiger Schenkelmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 45,
            ansatz = "Becken – Darmbeingrube, Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Schenkelnerv L2-L3",
            funktion = "Flexion des Oberschenkels",
            structure_id = 45
        });
        _connection.Insert(new Descriptions
        {
            id = 46,
            ansatz = "Becken – Darmbeingrube, Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Schenkelnerv - L2-L3",
            funktion = "Flexion des Oberschenkels",
            structure_id = 46
        });
        _connection.Insert(new Descriptions
        {
            id = 47,
            ansatz = "Wirbelsäule - Querfortsätze der Wirbel L1-L5, Wirbelkörper T12-L4 und Bandscheiben (laterale Seiten), Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Rami anteriores nervorum sacralium - L1-L3",
            funktion = "Flexion des Oberschenkels",
            structure_id = 47
        });
        _connection.Insert(new Descriptions
        {
            id = 48,
            ansatz = "Wirbelsäule - Querfortsätze der Wirbel L1-L5, Wirbelkörper T12-L4 und Bandscheiben (laterale Seiten), Oberschenkelknochen - kleiner Rollhügel (proximale Epiphyse)",
            innervation = "Rami anteriores nervorum sacralium - L1-L3",
            funktion = "Flexion des Oberschenkels",
            structure_id = 48
        });
        _connection.Insert(new Descriptions
        {
            id = 49,
            ansatz = "Wirbelsäule - Wirbelkörper T12-L1 und Bandscheibe (laterale Seiten), Becken - Schambeinkamm und Darmbein, Schambein-Höcker des oberen Schambeinastes, Arcus iliopectineus",
            innervation = "Vorderer Ast des Spinalnervs - L1",
            funktion = "Flexion und Außenrotation des Oberschenkels, Stabilisierung des Beckens",
            structure_id = 49
        });
        _connection.Insert(new Descriptions
        {
            id = 50,
            ansatz = "Wirbelsäule - Wirbelkörper T12-L1 und Bandscheibe (laterale Seiten), Becken - Schambeinkamm und Darmbein, Schambein-Höcker des oberen Schambeinastes, Arcus iliopectineus",
            innervation = "Vorderer Ast des Spinalnervs - L1",
            funktion = "Flexion und Außenrotation des Oberschenkels, Stabilisierung des Beckens",
            structure_id = 50
        });
        _connection.Insert(new Descriptions
        {
            id = 51,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes, Schienbein - Condylus medialis (proximale Epiphyse), Schräges Kniekehlenband",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Beugung des Knies, Stabilisierung des Knies, Innenrotation des Oberschenkels",
            structure_id = 51
        });
        _connection.Insert(new Descriptions
        {
            id = 52,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes, Schienbein - Condylus medialis (proximale Epiphyse), Schräges Kniekehlenband",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Beugung des Knies, Stabilisierung des Knies, Innenrotation des Oberschenkels",
            structure_id = 52
        });
        _connection.Insert(new Descriptions
        {
            id = 53,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes, Kreuzbein-Sitzbeinhöcker-Band (Caput longum), Oberschenkelknochen - äußere Leiste der rauen Linie (mittleres 1/3 der Diaphyse - Caput breve), Wadenbein - Spitze des Caput (proximale Epiphyse)",
            innervation = "Schienbeinnerv (Caput longum) und Wadenbeinnerv (Caput breve) - L5-S2",
            funktion = "Beugung des Knies, Außenrotation des Oberschenkels",
            structure_id = 53
        });
        _connection.Insert(new Descriptions
        {
            id = 54,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes, Kreuzbein-Sitzbeinhöcker-Band (Caput longum), Oberschenkelknochen - äußere Leiste der rauen Linie (mittleres 1/3 der Diaphyse - Caput breve), Wadenbein - Spitze des Caput (proximale Epiphyse)",
            innervation = "Schienbeinnerv (Caput longum) und Wadenbeinnerv (Caput breve) – L5-S2",
            funktion = "Beugung des Knies, Außenrotation des Oberschenkels",
            structure_id = 54
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 55,
            latin_name = "Musculus semitendinosus (dex.)",
            german_name = "Halbsehnenmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 56,
            latin_name = "Musculus semitendinosus (sin.)",
            german_name = "Halbsehnenmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 57,
            latin_name = "Musculus gemellus superior (dex.)",
            german_name = "Oberer Zwillingsmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 58,
            latin_name = "Musculus gemellus superior (sin.)",
            german_name = "Oberer Zwillingsmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 59,
            latin_name = "Musculus gemellus inferior (dex.)",
            german_name = "Unterer Zwillingsmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 60,
            latin_name = "Musculus gemellus inferior (sin.)",
            german_name = "Unterer Zwillingsmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 61,
            latin_name = "Musculus obturatorius externus (dex.)",
            german_name = "Äußerer Hüftlochmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 62,
            latin_name = "Musculus obturatorius externus (sin.)",
            german_name = "Äußerer Hüftlochmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 63,
            latin_name = "Musculus piriformis (dex.)",
            german_name = "Birnenförmiger Muskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 64,
            latin_name = "Musculus piriformis (sin.)",
            german_name = "Birnenförmiger Muskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 55,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes, Kreuzbein-Sitzbeinhöcker-Band, Schienbein – Schienbeinhöcker (medialer Teil)",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Beugung des Knies, Innenrotation des Oberschenkels",
            structure_id = 55
        });
        _connection.Insert(new Descriptions
        {
            id = 56,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes, Kreuzbein-Sitzbeinhöcker-Band, Schienbein – Schienbeinhöcker (medialer Teil)",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Beugung des Knies, Innenrotation des Oberschenkels",
            structure_id = 56
        });
        _connection.Insert(new Descriptions
        {
            id = 57,
            ansatz = "Becken – Sitzbeinstachel, Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S2",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 57
        });
        _connection.Insert(new Descriptions
        {
            id = 58,
            ansatz = "Becken – Sitzbeinstachel, Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S2",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 58
        });
        _connection.Insert(new Descriptions
        {
            id = 59,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes, Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L4-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 59
        });
        _connection.Insert(new Descriptions
        {
            id = 60,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes, Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L4-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 60
        });
        _connection.Insert(new Descriptions
        {
            id = 61,
            ansatz = "Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (äußere Fläche), Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Hüftlochnerv – L3-L4",
            funktion = "Außenrotation des Oberschenkels, Adduktion",
            structure_id = 61
        });
        _connection.Insert(new Descriptions
        {
            id = 62,
            ansatz = "Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (äußere Fläche), Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Hüftlochnerv – L3-L4",
            funktion = "Außenrotation des Oberschenkels, Adduktion",
            structure_id = 62
        });
        _connection.Insert(new Descriptions
        {
            id = 63,
            ansatz = "Wirbelsäule - Beckenfläche des Kreuzbeins, Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – S1-S2",
            funktion = "Außenrotation und Abduktion des Oberschenkels",
            structure_id = 63
        });
        _connection.Insert(new Descriptions
        {
            id = 64,
            ansatz = "Wirbelsäule - Beckenfläche des Kreuzbeins, Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – S1-S2",
            funktion = "Außenrotation und Abduktion des Oberschenkels",
            structure_id = 64
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 65,
            latin_name = "Musculus gluteus minimus (dex.)",
            german_name = "Kleiner Gesäßmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 66,
            latin_name = "Musculus gluteus minimus (sin.)",
            german_name = "Kleiner Gesäßmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 67,
            latin_name = "Musculus obturatorius internus (dex.)",
            german_name = "Innerer Hüftlochmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 68,
            latin_name = "Musculus obturatorius internus (sin.)",
            german_name = "Innerer Hüftlochmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 69,
            latin_name = "Musculus gluteus medius (dex.)",
            german_name = "Mittlerer Gesäßmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 70,
            latin_name = "Musculus gluteus medius (sin.)",
            german_name = "Mittlerer Gesäßmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 71,
            latin_name = "Musculus rectus femoris (dex.)",
            german_name = "Gerader Schenkelmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 72,
            latin_name = "Musculus rectus femoris (sin.)",
            german_name = "Gerader Schenkelmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 73,
            latin_name = "Musculus sartorius (dex.)",
            german_name = "Schneidermuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 74,
            latin_name = "Musculus sartorius (sin.)",
            german_name = "Schneidermuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 65,
            ansatz = "Becken - Gesäßfläche des Darmbeins (zwischen der anterioren und der posterioren Linea glutealis), Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Abduktion und Innenrotation des Oberschenkels",
            structure_id = 65
        });
        _connection.Insert(new Descriptions
        {
            id = 66,
            ansatz = "Becken - Gesäßfläche des Darmbeins (zwischen der anterioren und der posterioren Linea glutealis), Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Abduktion und Innenrotation des Oberschenkels",
            structure_id = 66
        });
        _connection.Insert(new Descriptions
        {
            id = 67,
            ansatz = "Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (Innenfläche), Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 67
        });
        _connection.Insert(new Descriptions
        {
            id = 68,
            ansatz = "Becken - Ränder des Hüftbeinlochs, Membrana obturatoria (Innenfläche), Oberschenkelknochen - Rollhügelgrube (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 68
        });
        _connection.Insert(new Descriptions
        {
            id = 69,
            ansatz = "Becken - Gesäßfläche des Darmbeins (unterhalb des Darmbeinkamms zwischen der anterioren und der posterioren Linea glutealis), Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Abduktion und Stabilisierung des Beckens, Abduktion des Oberschenkels",
            structure_id = 69
        });
        _connection.Insert(new Descriptions
        {
            id = 70,
            ansatz = "Becken - Gesäßfläche des Darmbeins (unterhalb des Darmbeinkamms zwischen der anterioren und der posterioren Linea glutealis), Oberschenkelknochen - großer Rollhügel (proximale Epiphyse)",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Abduktion und Stabilisierung des Beckens, Abduktion des Oberschenkels",
            structure_id = 70
        });
        _connection.Insert(new Descriptions
        {
            id = 71,
            ansatz = "Becken - vorderer unterer Darmbeinstachel, Oberrand der Hüftgelenkspfanne (Acetabulum), Schienbein - Schienbeinhöcker (mittels Kniescheibenband)",
            innervation = "Schenkelnerv L2-L4",
            funktion = "Flexion des Oberschenkels, Streckung des Knies",
            structure_id = 71
        });
        _connection.Insert(new Descriptions
        {
            id = 72,
            ansatz = "Becken - vorderer unterer Darmbeinstachel, Oberrand der Hüftgelenkspfanne (Acetabulum), Schienbein - Schienbeinhöcker (mittels Kniescheibenband)",
            innervation = "Schenkelnerv L2-L4",
            funktion = "Flexion des Oberschenkels, Streckung des Knies",
            structure_id = 72
        });
        _connection.Insert(new Descriptions
        {
            id = 73,
            ansatz = "Becken – oberer vorderer Darmbeinstachel, Schienbein - Schienbeinhöcker (medialer Teil)",
            innervation = "Schenkelnerv L2-L3",
            funktion = "Flexion, Abduktion und Außenrotation des Oberschenkels, Beugung des Knies",
            structure_id = 73
        });
        _connection.Insert(new Descriptions
        {
            id = 74,
            ansatz = "Becken – oberer vorderer Darmbeinstachel, Schienbein - Schienbeinhöcker (medialer Teil)",
            innervation = "Schenkelnerv L2-L3",
            funktion = "Flexion, Abduktion und Außenrotation des Oberschenkels, Beugung des Knies",
            structure_id = 74
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 75,
            latin_name = "Musculus gluteus maximus (dex.)",
            german_name = "Großer Gesäßmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 76,
            latin_name = "Musculus gluteus maximus (sin.)",
            german_name = "Großer Gesäßmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 77,
            latin_name = "Musculus tensor fasciae latae (dex.)",
            german_name = "Schenkelbindenspanner (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 78,
            latin_name = "Musculus tensor fasciae latae (sin.)",
            german_name = "Schenkelbindenspanner (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 79,
            latin_name = "Musculus quadratus femoris (dex.)",
            german_name = "Vierseitiger Schenkelmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 80,
            latin_name = "Musculus quadratus femoris (sin.)",
            german_name = "Vierseitiger Schenkelmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 81,
            latin_name = "Musculus popliteus (dex.)",
            german_name = "Kniekehlenmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 82,
            latin_name = "Musculus popliteus (sin.)",
            german_name = "Kniekehlenmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 83,
            latin_name = "Musculus plantaris (dex.)",
            german_name = "Sohlenspanner (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });
        _connection.Insert(new AnatomicalStructures
        {
            id = 84,
            latin_name = "Musculus plantaris (sin.)",
            german_name = "Sohlenspanner (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 75,
            ansatz = "Wirbelsäule - dorsale Kreuzbeinoberfläche, Fascia thoracolumbalis, Becken - Gesäßfläche des Darmbeins, Kreuzbein-Sitzbeinhöcker-Band, Darmbein-Schienbein-Band, Oberschenkelknochen – Gesäßmuskelrauigkeit (Diaphyse)",
            innervation = "Unterer Gesäßnerv – L5-S2",
            funktion = "Hüftstreckung, Extension, Abduktion und Außenrotation des Oberschenkels",
            structure_id = 75
        });
        _connection.Insert(new Descriptions
        {
            id = 76,
            ansatz = "Wirbelsäule - dorsale Kreuzbeinoberfläche, Fascia thoracolumbalis, Becken - Gesäßfläche des Darmbeins, Kreuzbein-Sitzbeinhöcker-Band, Darmbein-Schienbein-Band, Oberschenkelknochen – Gesäßmuskelrauigkeit (Diaphyse)",
            innervation = "Unterer Gesäßnerv – L5-S2",
            funktion = "Hüftstreckung, Extension, Abduktion und Außenrotation des Oberschenkels",
            structure_id = 76
        });
        _connection.Insert(new Descriptions
        {
            id = 77,
            ansatz = "Becken - oberer vorderer Darmbeinstachel, Darmbein-Schienbein-Band",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Spannt die Oberschenkelfaszie, unterstützt die Hüftabduktion",
            structure_id = 77
        });
        _connection.Insert(new Descriptions
        {
            id = 78,
            ansatz = "Becken - oberer vorderer Darmbeinstachel, Darmbein-Schienbein-Band",
            innervation = "Oberer Gesäßnerv - L4-S1",
            funktion = "Spannt die Oberschenkelfaszie, unterstützt die Hüftabduktion",
            structure_id = 78
        });
        _connection.Insert(new Descriptions
        {
            id = 79,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes (laterale Kante), Oberschenkelknochen - quadratischer Höcker der Zwischenrollhügelleiste (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 79
        });
        _connection.Insert(new Descriptions
        {
            id = 80,
            ansatz = "Becken - Tuber ischiadicum des Sitzbeinastes (laterale Kante), Oberschenkelknochen - quadratischer Höcker der Zwischenrollhügelleiste (proximale Epiphyse)",
            innervation = "Muskelast des Kreuzbeinnervengeflechts – L5-S1",
            funktion = "Außenrotation des Oberschenkels",
            structure_id = 80
        });
        _connection.Insert(new Descriptions
        {
            id = 81,
            ansatz = "Oberschenkelknochen - Sulcus popliteus des äußeren Gelenkknorrens (distale Epiphyse), Außenmeniskus (Cornu posterius) (Hinterhorn), Schienbein - Hinterfläche (proximaler Teil der Diaphyse)",
            innervation = "Schienbeinnerv – L4-S1",
            funktion = "Flexion und Innenrotation des Knies",
            structure_id = 81
        });
        _connection.Insert(new Descriptions
        {
            id = 82,
            ansatz = "Oberschenkelknochen - Sulcus popliteus des äußeren Gelenkknorrens (distale Epiphyse), Außenmeniskus (Cornu posterius) (Hinterhorn), Schienbein - Hinterfläche (proximaler Teil der Diaphyse)",
            innervation = "Schienbeinnerv - L4-S1",
            funktion = "Flexion und Innenrotation des Knies",
            structure_id = 82
        });
        _connection.Insert(new Descriptions
        {
            id = 83,
            ansatz = "Oberschenkelknochen - Epicondylus lateralis des äußeren Gelenkknorrens (distale Epiphyse), Schräges Kniekehlenband, Fuß - Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Flexion des Knies, Plantarflexion des Fußes",
            structure_id = 83
        });
        _connection.Insert(new Descriptions
        {
            id = 84,
            ansatz = "Oberschenkelknochen - Epicondylus lateralis des äußeren Gelenkknorrens (distale Epiphyse), Schräges Kniekehlenband, Fuß - Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Flexion des Knies, Plantarflexion des Fußes",
            structure_id = 84
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 85,
            latin_name = "Musculus tibialis posterior (dex.)",
            german_name = "Hinterer Schienbeinmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 86,
            latin_name = "Musculus tibialis posterior (sin.)",
            german_name = "Hinterer Schienbeinmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 87,
            latin_name = "Musculus extensor hallucis longus (dex.)",
            german_name = "Langer Großzehenstrecker (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 88,
            latin_name = "Musculus extensor hallucis longus (sin.)",
            german_name = "Langer Großzehenstrecker (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 89,
            latin_name = "Musculus fibularis brevis (dex.)",
            german_name = "Kurzer Wadenbeinmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 90,
            latin_name = "Musculus fibularis brevis (sin.)",
            german_name = "Kurzer Wadenbeinmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 91,
            latin_name = "Musculus fibularis tertius (dex.)",
            german_name = "Dritter Wadenbeinmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 92,
            latin_name = "Musculus fibularis tertius (sin.)",
            german_name = "Dritter Wadenbeinmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 93,
            latin_name = "Musculus flexor hallucis longus (dex.)",
            german_name = "Langer Großzehenbeuger (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 94,
            latin_name = "Musculus flexor hallucis longus (sin.)",
            german_name = "Langer Großzehenbeuger (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 85,
            ansatz = "Schienbein- Hinterfläche (proximale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Wadenbein - Hinterfläche (proximale 2/3 der Diaphyse), Fuß - Tuberositas des Kahnbeins, inneres, mittleres und äußeres Keilbein, Basen der Mittelfußknochen II-IV (Unterseiten)",
            innervation = "Schienbeinnerv – L4-L5",
            funktion = "Plantarflexion und Supination des Fußes",
            structure_id = 85
        });

        _connection.Insert(new Descriptions
        {
            id = 86,
            ansatz = "Schienbein- Hinterfläche (proximale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Wadenbein - Hinterfläche (proximale 2/3 der Diaphyse), Fuß - Tuberositas des Kahnbeins, inneres, mittleres und äußeres Keilbein, Basen der Mittelfußknochen II-IV (Unterseiten)",
            innervation = "Schienbeinnerv – L4-L5",
            funktion = "Plantarflexion und Supination des Fußes",
            structure_id = 86
        });

        _connection.Insert(new Descriptions
        {
            id = 87,
            ansatz = "Wadenbein mediale Fläche (distale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Dorsalaponeurose der Zehen",
            innervation = "Tiefer Wadenbeinnerv – L5",
            funktion = "Dorsalextension des Fußes, Streckung der Großzehe",
            structure_id = 87
        });

        _connection.Insert(new Descriptions
        {
            id = 88,
            ansatz = "Wadenbein - mediale Fläche (distale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Dorsalaponeurose der Zehen",
            innervation = "Tiefer Wadenbeinnerv - L5",
            funktion = "Dorsalextension des Fußes, Streckung der Großzehe",
            structure_id = 88
        });

        _connection.Insert(new Descriptions
        {
            id = 89,
            ansatz = "Wadenbein - laterale Fläche (distale 2/3 der Diaphyse), Zwischenmuskelscheidewände des Unterschenkels (Septum intermusculare cruris), Fuß - Tuberositas der Basis des 5. Mittelfußknochens (laterale Fläche)",
            innervation = "Oberflächlicher Wadenbeinnerv – L5-S1",
            funktion = "Plantarflexion und Eversion des Fußes",
            structure_id = 89
        });

        _connection.Insert(new Descriptions
        {
            id = 90,
            ansatz = "Wadenbein - laterale Fläche (distale 2/3 der Diaphyse), Zwischenmuskelscheidewände des Unterschenkels (Septum intermusculare cruris), Fuß - Tuberositas der Basis des 5. Mittelfußknochens (laterale Fläche)",
            innervation = "Oberflächlicher Wadenbeinnerv - L5-S1",
            funktion = "Plantarflexion und Eversion des Fußes",
            structure_id = 90
        });

        _connection.Insert(new Descriptions
        {
            id = 91,
            ansatz = "Wadenbein - vordere Kante (distales 1/3 der Diaphyse), Fuß - Basis des 5. Mittelfußknochens (Rückfläche)",
            innervation = "Tiefer Wadenbeinnerv – L5-S1",
            funktion = "Dorsalextension und Eversion des Fußes",
            structure_id = 91
        });

        _connection.Insert(new Descriptions
        {
            id = 92,
            ansatz = "Wadenbein - vordere Kante (distales 1/3 der Diaphyse), Fuß - Basis des 5. Mittelfußknochens (Rückfläche)",
            innervation = "Tiefer Wadenbeinnerv - L5-S1",
            funktion = "Dorsalextension und Eversion des Fußes",
            structure_id = 92
        });

        _connection.Insert(new Descriptions
        {
            id = 93,
            ansatz = "Wadenbein - Hinterfläche (distale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Fuß - Basis des Endglieds der Großzehe (Unterseite)",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Plantarflexion des Fußes und Beugung der Großzehe",
            structure_id = 93
        });

        _connection.Insert(new Descriptions
        {
            id = 94,
            ansatz = "Wadenbein - Hinterfläche (distale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Fuß - Basis des Endglieds der Großzehe (Unterseite)",
            innervation = "Schienbeinnerv - L5-S2",
            funktion = "Plantarflexion des Fußes und Beugung der Großzehe",
            structure_id = 94
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 95,
            latin_name = "Musculus flexor digitorum longus (dex.)",
            german_name = "Langer Zehenbeuger (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 96,
            latin_name = "Musculus flexor digitorum longus (sin.)",
            german_name = "Langer Zehenbeuger (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 97,
            latin_name = "Musculus tibialis anterior (dex.)",
            german_name = "Vorderer Schienbeinmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 98,
            latin_name = "Musculus tibialis anterior (sin.)",
            german_name = "Vorderer Schienbeinmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 99,
            latin_name = "Musculus extensor digitorum longus (dex.)",
            german_name = "Langer Zehenstrecker (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 100,
            latin_name = "Musculus extensor digitorum longus (sin.)",
            german_name = "Langer Zehenstrecker (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 101,
            latin_name = "Musculus fibularis longus (dex.)",
            german_name = "Langer Wadenbeinmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 102,
            latin_name = "Musculus fibularis longus (sin.)",
            german_name = "Langer Wadenbeinmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 103,
            latin_name = "Musculus soleus (dex.)",
            german_name = "Schollenmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 104,
            latin_name = "Musculus soleus (sin.)",
            german_name = "Schollenmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 95,
            ansatz = "Schienbein- Hinterfläche (mittleres 1/3 der Diaphyse), Fuß - Basen der Endphalangen der Zehen II-V (Unterseiten)",
            innervation = "Schienbeinnerv – L5-S2",
            funktion = "Flexion der Zehen II-V, Plantarflexion des Fußes",
            structure_id = 95
        });

        _connection.Insert(new Descriptions
        {
            id = 96,
            ansatz = "Schienbein - Hinterfläche (mittleres 1/3 der Diaphyse), Fuß - Basen der Endphalangen der Zehen II-V (Unterseiten)",
            innervation = "Schienbeinnerv - L5-S2",
            funktion = "Flexion der Zehen II-V, Plantarflexion des Fußes",
            structure_id = 96
        });

        _connection.Insert(new Descriptions
        {
            id = 97,
            ansatz = "Schienbein - laterale Fläche (proximale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Fuß - inneres Keilbein, Basis des 1. Mittelfußknochens (mediale und untere Seite)",
            innervation = "Tiefer Wadenbeinnerv – L4-L5",
            funktion = "Dorsalflexion und Inversion des Fußes",
            structure_id = 97
        });

        _connection.Insert(new Descriptions
        {
            id = 98,
            ansatz = "Schienbein - laterale Fläche (proximale 2/3 der Diaphyse), Zwischenknochenmembran des Unterschenkels, Fuß - inneres Keilbein, Basis des 1. Mittelfußknochens (mediale und untere Seite)",
            innervation = "Tiefer Wadenbeinnerv - L4-L5",
            funktion = "Dorsalflexion und Inversion des Fußes",
            structure_id = 98
        });

        _connection.Insert(new Descriptions
        {
            id = 99,
            ansatz = "Schienbein - lateraler Kondylus (proximale Epiphyse), Wadenbein - Caput (proximale Epiphyse), mediale Fläche (Diaphyse), Zwischenknochenmembran des Unterschenkels, Dorsalaponeurose der Zehen",
            innervation = "Tiefer Wadenbeinnerv – L5-S1",
            funktion = "Dorsalextension des Fußes, Streckung der Zehen",
            structure_id = 99
        });

        _connection.Insert(new Descriptions
        {
            id = 100,
            ansatz = "Schienbein - lateraler Kondylus (proximale Epiphyse), Wadenbein - Caput (proximale Epiphyse), mediale Fläche (Diaphyse), Zwischenknochenmembran des Unterschenkels, Dorsalaponeurose der Zehen",
            innervation = "Tiefer Wadenbeinnerv - L5-S1",
            funktion = "Dorsalextension des Fußes, Streckung der Zehen",
            structure_id = 100
        });

        _connection.Insert(new Descriptions
        {
            id = 101,
            ansatz = "Wadenbein - Caput (proximale Epiphyse), laterale Fläche und vordere Kante (Diaphyse), Zwischenmuskelscheidewände des Unterschenkels (Septum Intermusculare cruris), Fuß - mittleres Keilbein, Tuberositas der Basis des 1. Mittelfußknochens (Unterseiten)",
            innervation = "Oberflächlicher Wadenbeinnerv – L5-S1",
            funktion = "Plantarflexion und Eversion des Fußes",
            structure_id = 101
        });

        _connection.Insert(new Descriptions
        {
            id = 102,
            ansatz = "Wadenbein - Caput (proximale Epiphyse), laterale Fläche und vordere Kante (Diaphyse), Zwischenmuskelscheidewände des Unterschenkels (Septum Intermusculare cruris), Fuß - mittleres Keilbein, Tuberositas der Basis des 1. Mittelfußknochens (Unterseiten)",
            innervation = "Oberflächlicher Wadenbeinnerv – L5-S1",
            funktion = "Plantarflexion und Eversion des Fußes",
            structure_id = 102
        });

        _connection.Insert(new Descriptions
        {
            id = 103,
            ansatz = "Wadenbein - Caput (proximale Epiphyse), Dorsalfläche und dorsale Kante (proximales 1/4 der Diaphyse), Schienbein - Linea musculi solei auf der Dorsalseite und mediale Kante (Diaphyse), Fuß - Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Plantarflexion des Fußes",
            structure_id = 103
        });

        _connection.Insert(new Descriptions
        {
            id = 104,
            ansatz = "Wadenbein - Caput (proximale Epiphyse), Dorsalfläche und dorsale Kante (proximales 1/4 der Diaphyse), Schienbein - Linea musculi solei auf der Dorsalseite und mediale Kante (Diaphyse), Fuß - Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Plantarflexion des Fußes",
            structure_id = 104
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 105,
            latin_name = "Musculus gastrocnemius (dex.)",
            german_name = "Zwillingswadenmuskel (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 106,
            latin_name = "Musculus gastrocnemius (sin.)",
            german_name = "Zwillingswadenmuskel (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 107,
            latin_name = "Musculus opponens digiti minimi pedis (dex.)",
            german_name = "Kleinzehengegensteller (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 108,
            latin_name = "Musculus opponens digiti minimi pedis (sin.)",
            german_name = "Kleinzehengegensteller (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 109,
            latin_name = "Musculus abductor digiti minimi pedis (dex.)",
            german_name = "Kleinzehenspreizer (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 110,
            latin_name = "Musculus abductor digiti minimi pedis (sin.)",
            german_name = "Kleinzehenspreizer (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 111,
            latin_name = "Musculus flexor digiti minimi brevis pedis (dex.)",
            german_name = "Kurzer Kleinzehenbeuger (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 112,
            latin_name = "Musculus flexor digiti minimi brevis pedis (sin.)",
            german_name = "Kurzer Kleinzehenbeuger (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 113,
            latin_name = "Musculi interossei dorsales pedis (dex.)",
            german_name = "Rückseitige Zwischenknochenmuskeln des Fußes (re.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 114,
            latin_name = "Musculi interossei dorsales pedis (sin.)",
            german_name = "Rückseitige Zwischenknochenmuskeln des Fußes (li.)",
            category = "Beinmuskeln",
            parentId = 0
        });

        _connection.Insert(new Descriptions
        {
            id = 105,
            ansatz = "Oberschenkelknochen - Epicondylus lateralis des äußeren Gelenkknorrens, Epicondylus medialis des inneren Gelenkknorrens (distale Epiphyse), Fuß – Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Plantarflexion des Fußes, Beugung des Knies",
            structure_id = 105
        });

        _connection.Insert(new Descriptions
        {
            id = 106,
            ansatz = "Oberschenkelknochen - Epicondylus lateralis des äußeren Gelenkknorrens, Epicondylus medialis des inneren Gelenkknorrens (distale Epiphyse), Fuß – Fersenbeinhöcker",
            innervation = "Schienbeinnerv – S1-S2",
            funktion = "Plantarflexion des Fußes, Beugung des Knies",
            structure_id = 106
        });

        _connection.Insert(new Descriptions
        {
            id = 107,
            ansatz = "Kurzer Wadenbeinmuskel (distale Sehne) und langes Fußsohlenband, Fuß - Basis des 5. Mittelfußknochens (untere Fläche)",
            innervation = "Oberflächlicher Ast des äußeren Fußsohlennervs - S2-S3",
            funktion = "Opposition des Kleinzehs",
            structure_id = 107
        });

        _connection.Insert(new Descriptions
        {
            id = 108,
            ansatz = "Kurzer Wadenbeinmuskel (distale Sehne) und langes Fußsohlenband, Fuß - Basis des 5. Mittelfußknochens (untere Fläche)",
            innervation = "Oberflächlicher Ast des äußeren Fußsohlennervs - S2-S3",
            funktion = "Opposition des Kleinzehs",
            structure_id = 108
        });

        _connection.Insert(new Descriptions
        {
            id = 109,
            ansatz = "Fuß - medialer und lateraler Fortsatz des Fersenbeinhöckers, Plantaraponeurose, Tuberositas der Basis des 5. Mittelfußknochens und Basis des Kleinzehengrundglieds (untere Seiten)",
            innervation = "Äußerer Fußsohlennerv – S1-S3",
            funktion = "Abduktion des Kleinzehs",
            structure_id = 109
        });

        _connection.Insert(new Descriptions
        {
            id = 110,
            ansatz = "Fuß - medialer und lateraler Fortsatz des Fersenbeinhöckers, Plantaraponeurose, Tuberositas der Basis des 5. Mittelfußknochens und Basis des Kleinzehengrundglieds (untere Seiten)",
            innervation = "Äußerer Fußsohlennerv – S1-S3",
            funktion = "Abduktion des Kleinzehs",
            structure_id = 110
        });

        _connection.Insert(new Descriptions
        {
            id = 111,
            ansatz = "Fuß - Basis des 5. Mittelfußknochens (untere Fläche), Langes Fußsohlenband, Basis der proximalen Phalanx der Kleinzehe (Unterseite)",
            innervation = "Oberflächlicher Ast des äußeren Fußsohlennervs - S2-S3",
            funktion = "Flexion des Kleinzehs",
            structure_id = 111
        });

        _connection.Insert(new Descriptions
        {
            id = 112,
            ansatz = "Fuß - Basis des 5. Mittelfußknochens (untere Fläche), Langes Fußsohlenband, Basis der proximalen Phalanx der Kleinzehe (Unterseite)",
            innervation = "Oberflächlicher Ast des äußeren Fußsohlennervs - S2-S3",
            funktion = "Flexion des Kleinzehs",
            structure_id = 112
        });

        _connection.Insert(new Descriptions
        {
            id = 113,
            ansatz = "Corporale von jeweils zwei benachbarten Mittelfußknochen (an den gegenüberliegenden Flächen), Dorsalaponeurose der Zehen",
            innervation = "Äußerer Fußsohlennerv - S2-S3",
            funktion = "Abduktion der Zehen",
            structure_id = 113
        });

        _connection.Insert(new Descriptions
        {
            id = 114,
            ansatz = "Corporale von jeweils zwei benachbarten Mittelfußknochen (an den gegenüberliegenden Flächen), Dorsalaponeurose der Zehen",
            innervation = "Äußerer Fußsohlennerv - S2-S3",
            funktion = "Abduktion der Zehen",
            structure_id = 114
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
