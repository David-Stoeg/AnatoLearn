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
        _connection.CreateTable<AnatomicalStructures>();
        _connection.CreateTable<Descriptions>();


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
            ansatz = "Darmbein-Lenden-Band (Ligamentum iliolumbale) Becken - Innere Gruppe des Darmbeinkamms, Brustkorb-Rippenkörper XII (anteroinferiorer Tell)",
            innervation = "Vordere Äste der Spinalnerven (T12, L1-L4)",
            funktion = "Stabilisierung der Lendenwirbelsäule und des Beckens",
            structure_id = 14
        });
        _connection.Insert(new Descriptions
        {
            id = 15,
            ansatz = "Darmbein-Lenden-Band (Ligamentum iliolumbale) Becken - Innere Gruppe des Darmbeinkamms, Brustkorb-Rippenkörper XII (anteroinferiorer Tell)",
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
            ansatz = "Brustkorb- Rippenkörper VIl-XIl (lnnenfläche),  Fascia thoracolumbalis und Fascia iliolumbalis, Becken - Innere Lippe des Darmbeinkamms und oberer vorderer Darmbeinstachel, Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln), Becken - Schambeinleiste (Crista pubica)",
            innervation = "Rechte Zwischenrippennerven - 17-T12, Hüft-Becken-Nerv (Nervus llohypogastricus) - T12-L1, Hüft-Leisten-Nerv (Nervus ilioinguinalis) - L1-L4",
            funktion = "Stabilisierung des Rumpfes, Unterstützung des Beckenbodens",
            structure_id = 18
        });
        _connection.Insert(new Descriptions
        {
            id = 19,
            ansatz = "Brustkorb- Rippenkörper VIl-XIl (lnnenfläche),  Fascia thoracolumbalis und Fascia iliolumbalis, Becken - Innere Lippe des Darmbeinkamms und oberer vorderer Darmbeinstachel, Linea alba (aponeurotische Sehnenfaserverflechtung der vorderen lateralen breiten Bauchmuskeln), Becken - Schambeinleiste (Crista pubica)",
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

        _connection.Insert(new AnatomicalStructures
        {
            id = 115,
            latin_name = "Musculus biceps brachii (sin.)",
            german_name = "Langer Kopf des Bizeps (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 115,
            ansatz = "Tuberositas radii und über die Aponeurosis musculi bicipitis brachii an der Fascia antebrachii",
            innervation = "N. musculocutaneus (C5–C6)",
            funktion = "Flexion und Supination im Ellenbogengelenk; unterstützt Flexion im Schultergelenk",
            structure_id = 115
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 116,
            latin_name = "Musculus biceps brachii (dex.)",
            german_name = "Langer Kopf des Bizeps (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 116,
            ansatz = "Tuberositas radii und über die Aponeurosis musculi bicipitis brachii an der Fascia antebrachii",
            innervation = "N. musculocutaneus (C5–C6)",
            funktion = "Flexion und Supination im Ellenbogengelenk; unterstützt Flexion im Schultergelenk",
            structure_id = 116
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 117,
            latin_name = "Musculus coracobrachialis (sin.)",
            german_name = "Rabenschnabelmuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 117,
            ansatz = "Mediale Fläche des Humerus in Verlängerung der Crista tuberculi minoris",
            innervation = "N. musculocutaneus (C5–C7)",
            funktion = "Adduktion, Flexion und Innenrotation im Schultergelenk",
            structure_id = 117
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 118,
            latin_name = "Musculus coracobrachialis (dex.)",
            german_name = "Rabenschnabelmuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 118,
            ansatz = "Mediale Fläche des Humerus in Verlängerung der Crista tuberculi minoris",
            innervation = "N. musculocutaneus (C5–C7)",
            funktion = "Adduktion, Flexion und Innenrotation im Schultergelenk",
            structure_id = 118
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 119,
            latin_name = "Musculus deltoideus (sin.)",
            german_name = "Deltamuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 119,
            ansatz = "Tuberositas deltoidea des Humerus",
            innervation = "N. axillaris (C5–C6)",
            funktion = "Abduktion, Anteversion, Retroversion, Innen- und Außenrotation im Schultergelenk (je nach Faseranteil)",
            structure_id = 119
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 120,
            latin_name = "Musculus deltoideus (dex.)",
            german_name = "Deltamuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 120,
            ansatz = "Tuberositas deltoidea des Humerus",
            innervation = "N. axillaris (C5–C6)",
            funktion = "Abduktion, Anteversion, Retroversion, Innen- und Außenrotation im Schultergelenk (je nach Faseranteil)",
            structure_id = 120
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 121,
            latin_name = "Musculus infraspinatus (sin.)",
            german_name = "Untergrätenmuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 121,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. suprascapularis (C4–C6)",
            funktion = "Außenrotation im Schultergelenk",
            structure_id = 121
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 122,
            latin_name = "Musculus infraspinatus (dex.)",
            german_name = "Untergrätenmuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 122,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. suprascapularis (C4–C6)",
            funktion = "Außenrotation im Schultergelenk",
            structure_id = 122
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 123,
            latin_name = "Musculus subscapularis (sin.)",
            german_name = "Unterschulterblattmuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 123,
            ansatz = "Tuberculum minus des Humerus",
            innervation = "Nn. subscapulares (C5–C6)",
            funktion = "Innenrotation im Schultergelenk",
            structure_id = 123
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 124,
            latin_name = "Musculus subscapularis (dex.)",
            german_name = "Unterschulterblattmuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 124,
            ansatz = "Tuberculum minus des Humerus",
            innervation = "Nn. subscapulares (C5–C6)",
            funktion = "Innenrotation im Schultergelenk",
            structure_id = 124
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 125,
            latin_name = "Musculus supraspinatus (sin.)",
            german_name = "Obergrätenmuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 125,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. suprascapularis (C4–C6)",
            funktion = "Abduktion im Schultergelenk",
            structure_id = 125
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 126,
            latin_name = "Musculus supraspinatus (dex.)",
            german_name = "Obergrätenmuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 126,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. suprascapularis (C4–C6)",
            funktion = "Abduktion im Schultergelenk",
            structure_id = 126
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 127,
            latin_name = "Musculus teres major (sin.)",
            german_name = "Großer Rundmuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 127,
            ansatz = "Crista tuberculi minoris des Humerus",
            innervation = "N. thoracodorsalis (C6–C7)",
            funktion = "Innenrotation, Adduktion und Retroversion im Schultergelenk",
            structure_id = 127
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 128,
            latin_name = "Musculus teres major (dex.)",
            german_name = "Großer Rundmuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 128,
            ansatz = "Crista tuberculi minoris des Humerus",
            innervation = "N. thoracodorsalis (C6–C7)",
            funktion = "Innenrotation, Adduktion und Retroversion im Schultergelenk",
            structure_id = 128
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 129,
            latin_name = "Musculus teres minor (sin.)",
            german_name = "Kleiner Rundmuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 129,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. axillaris (C5–C6)",
            funktion = "Außenrotation und schwache Adduktion im Schultergelenk",
            structure_id = 129
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 130,
            latin_name = "Musculus teres minor (dex.)",
            german_name = "Kleiner Rundmuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 130,
            ansatz = "Tuberculum majus des Humerus",
            innervation = "N. axillaris (C5–C6)",
            funktion = "Außenrotation und schwache Adduktion im Schultergelenk",
            structure_id = 130
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 131,
            latin_name = "Musculus triceps brachii (sin.)",
            german_name = "Langer Kopf des Trizeps (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 131,
            ansatz = "Olecranon der Ulna",
            innervation = "N. radialis (C6–C8)",
            funktion = "Extension im Ellenbogengelenk; Retroversion und Adduktion im Schultergelenk",
            structure_id = 131
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 132,
            latin_name = "Musculus triceps brachii (dex.)",
            german_name = "Langer Kopf des Trizeps (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 132,
            ansatz = "Olecranon der Ulna",
            innervation = "N. radialis (C6–C8)",
            funktion = "Extension im Ellenbogengelenk; Retroversion und Adduktion im Schultergelenk",
            structure_id = 132
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 133,
            latin_name = "Musculus brachialis (sin.)",
            german_name = "Armbeuger (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 133,
            ansatz = "Tuberositas ulnae",
            innervation = "N. musculocutaneus (C5–C6)",
            funktion = "Flexion im Ellenbogengelenk",
            structure_id = 133
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 134,
            latin_name = "Musculus brachialis (dex.)",
            german_name = "Armbeuger (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 134,
            ansatz = "Tuberositas ulnae",
            innervation = "N. musculocutaneus (C5–C6)",
            funktion = "Flexion im Ellenbogengelenk",
            structure_id = 134
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 135,
            latin_name = "Musculus anconeus (sin.)",
            german_name = "Ellenbogenmuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 135,
            ansatz = "Olecranon und proximales Viertel der dorsalen Fläche der Ulna",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension im Ellenbogengelenk; spannt die Gelenkkapsel",
            structure_id = 135
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 136,
            latin_name = "Musculus anconeus (dex.)",
            german_name = "Ellenbogenmuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 136,
            ansatz = "Olecranon und proximales Viertel der dorsalen Fläche der Ulna",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension im Ellenbogengelenk; spannt die Gelenkkapsel",
            structure_id = 136
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 137,
            latin_name = "Musculus brachioradialis (sin.)",
            german_name = "Oberarmspeichenmuskel (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 137,
            ansatz = "Processus styloideus radii",
            innervation = "N. radialis (C5–C6)",
            funktion = "Flexion im Ellenbogengelenk; unterstützt Pronation und Supination des Unterarms in die Mittelstellung",
            structure_id = 137
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 138,
            latin_name = "Musculus brachioradialis (dex.)",
            german_name = "Oberarmspeichenmuskel (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 138,
            ansatz = "Processus styloideus radii",
            innervation = "N. radialis (C5–C6)",
            funktion = "Flexion im Ellenbogengelenk; unterstützt Pronation und Supination des Unterarms in die Mittelstellung",
            structure_id = 138
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 139,
            latin_name = "Musculus pronator teres (sin.)",
            german_name = "Runder Einwärtsdreher (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 139,
            ansatz = "Facies lateralis radii (Mitte der Außenseite des Radius)",
            innervation = "N. medianus (C6–C7)",
            funktion = "Pronation und schwache Flexion im Ellenbogengelenk",
            structure_id = 139
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 140,
            latin_name = "Musculus pronator teres (dex.)",
            german_name = "Runder Einwärtsdreher (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 140,
            ansatz = "Facies lateralis radii (Mitte der Außenseite des Radius)",
            innervation = "N. medianus (C6–C7)",
            funktion = "Pronation und schwache Flexion im Ellenbogengelenk",
            structure_id = 140
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 141,
            latin_name = "Musculus supinator (sin.)",
            german_name = "Auswärtsdreher (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 141,
            ansatz = "Proximales Drittel des Radius",
            innervation = "N. radialis (C5–C6)",
            funktion = "Supination des Unterarms",
            structure_id = 141
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 142,
            latin_name = "Musculus supinator (dex.)",
            german_name = "Auswärtsdreher (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 142,
            ansatz = "Proximales Drittel des Radius",
            innervation = "N. radialis (C5–C6)",
            funktion = "Supination des Unterarms",
            structure_id = 142
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 143,
            latin_name = "Musculus extensor carpi radialis brevis (sin.)",
            german_name = "Kurzer speichenseitiger Handstrecker (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 143,
            ansatz = "Basis des Os metacarpi III",
            innervation = "N. radialis (C7–C8)",
            funktion = "Dorsalextension und Radialabduktion im Handgelenk",
            structure_id = 143
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 144,
            latin_name = "Musculus extensor carpi radialis brevis (dex.)",
            german_name = "Kurzer speichenseitiger Handstrecker (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 144,
            ansatz = "Basis des Os metacarpi III",
            innervation = "N. radialis (C7–C8)",
            funktion = "Dorsalextension und Radialabduktion im Handgelenk",
            structure_id = 144
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 145,
            latin_name = "Musculus extensor carpi radialis longus  (sin.)",
            german_name = "Langer speichenseitiger Handstrecker (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 145,
            ansatz = "Basis des Os metacarpi II",
            innervation = "N. radialis (C6–C7)",
            funktion = "Dorsalextension und Radialabduktion im Handgelenk",
            structure_id = 145
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 146,
            latin_name = "Musculus extensor carpi radialis longus (dex.)",
            german_name = "Langer speichenseitiger Handstrecker (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 146,
            ansatz = "Basis des Os metacarpi II",
            innervation = "N. radialis (C6–C7)",
            funktion = "Dorsalextension und Radialabduktion im Handgelenk",
            structure_id = 146
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 147,
            latin_name = "Musculus extensor carpi ulnaris (sin.)",
            german_name = "Ellenseitiger Handstrecker (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 147,
            ansatz = "Basis des Os metacarpi V",
            innervation = "N. radialis (C7–C8)",
            funktion = "Dorsalextension und Ulnarabduktion im Handgelenk",
            structure_id = 147
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 148,
            latin_name = "Musculus extensor carpi ulnaris (dex.)",
            german_name = "Ellenseitiger Handstrecker (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 148,
            ansatz = "Basis des Os metacarpi V",
            innervation = "N. radialis (C7–C8)",
            funktion = "Dorsalextension und Ulnarabduktion im Handgelenk",
            structure_id = 148
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 149,
            latin_name = "Musculus extensor digiti minimi (sin.)",
            german_name = "Kleinfingerstrecker (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 149,
            ansatz = "Dorsalaponeurose des 5. Fingers",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension des 5. Fingers; unterstützt Dorsalextension im Handgelenk",
            structure_id = 149
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 150,
            latin_name = "Musculus extensor digiti minimi (dex.)",
            german_name = "Kleinfingerstrecker (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 150,
            ansatz = "Dorsalaponeurose des 5. Fingers",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension des 5. Fingers; unterstützt Dorsalextension im Handgelenk",
            structure_id = 150
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 151,
            latin_name = "Musculus flexor carpi radialis (sin.)",
            german_name = "Speichenseitiger Handbeuger (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 151,
            ansatz = "Basis des Os metacarpi II und III",
            innervation = "N. medianus (C6–C7)",
            funktion = "Flexion und Radialabduktion im Handgelenk",
            structure_id = 151
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 152,
            latin_name = "Musculus flexor carpi radialis (dex.)",
            german_name = "Speichenseitiger Handbeuger (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 152,
            ansatz = "Basis des Os metacarpi II und III",
            innervation = "N. medianus (C6–C7)",
            funktion = "Flexion und Radialabduktion im Handgelenk",
            structure_id = 152
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 153,
            latin_name = "Musculus flexor carpi ulnaris (sin.)",
            german_name = "Ellenseitiger Handbeuger (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 153,
            ansatz = "Os pisiforme, Hamulus ossis hamati, Basis des Os metacarpi V",
            innervation = "N. ulnaris (C7–Th1)",
            funktion = "Flexion und Ulnarabduktion im Handgelenk",
            structure_id = 153
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 154,
            latin_name = "Musculus flexor carpi ulnaris (dex.)",
            german_name = "Ellenseitiger Handbeuger (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 154,
            ansatz = "Os pisiforme, Hamulus ossis hamati, Basis des Os metacarpi V",
            innervation = "N. ulnaris (C7–Th1)",
            funktion = "Flexion und Ulnarabduktion im Handgelenk",
            structure_id = 154
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 155,
            latin_name = "Musculus flexor pollicis longus (sin.)",
            german_name = "Langer Daumenbeuger (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 155,
            ansatz = "Basis der Endphalanx des Daumens",
            innervation = "N. medianus (C7–C8)",
            funktion = "Flexion im Daumengrund- und -endgelenk; unterstützt Flexion im Handgelenk",
            structure_id = 155
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 156,
            latin_name = "Musculus flexor pollicis longus (dex.)",
            german_name = "Langer Daumenbeuger (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 156,
            ansatz = "Basis der Endphalanx des Daumens",
            innervation = "N. medianus (C7–C8)",
            funktion = "Flexion im Daumengrund- und -endgelenk; unterstützt Flexion im Handgelenk",
            structure_id = 156
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 157,
            latin_name = "Musculus iliocostalis lumborum (sin.)",
            german_name = "Lenden-Rippenmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 157,
            ansatz = "Untere Rippen (Anguli costarum) und Fascia thoracolumbalis",
            innervation = "Rr. dorsales der Spinalnerven (C8–L1)",
            funktion = "Dorsalextension der Wirbelsäule, Lateralflexion zur ipsilateralen Seite",
            structure_id = 157
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 158,
            latin_name = "Musculus iliocostalis lumborum (dex.)",
            german_name = "Lenden-Rippenmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 158,
            ansatz = "Untere Rippen (Anguli costarum) und Fascia thoracolumbalis",
            innervation = "Rr. dorsales der Spinalnerven (C8–L1)",
            funktion = "Dorsalextension der Wirbelsäule, Lateralflexion zur ipsilateralen Seite",
            structure_id = 158
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 159,
            latin_name = "Musculi interspinales lumborum (sin.)",
            german_name = "Zwischenwirbelmuskeln der Lendenwirbelsäule (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 159,
            ansatz = "Dornfortsätze der benachbarten Lendenwirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung und Dorsalextension der Lendenwirbelsäule",
            structure_id = 159
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 160,
            latin_name = "Musculi interspinales lumborum (dex.)",
            german_name = "Zwischenwirbelmuskeln der Lendenwirbelsäule (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 160,
            ansatz = "Dornfortsätze der benachbarten Lendenwirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung und Dorsalextension der Lendenwirbelsäule",
            structure_id = 160
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 161,
            latin_name = "Musculi intertransversarii laterales lumborum (sin.)",
            german_name = "Seitliche Zwischenquerfortsatzmuskeln (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 161,
            ansatz = "Querfortsätze der benachbarten Lendenwirbel",
            innervation = "Rr. ventrales und dorsales der Spinalnerven",
            funktion = "Lateralflexion der Wirbelsäule",
            structure_id = 161
        });
        
        _connection.Insert(new AnatomicalStructures
        {
            id = 165,
            latin_name = "Musculus longissimus thoracis (sin.)",
            german_name = "Langer Rückenmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 165,
            ansatz = "Rippen und Querfortsätze der Brustwirbel",
            innervation = "Rr. dorsales der Spinalnerven (C4–L5)",
            funktion = "Dorsalextension und Lateralflexion der Wirbelsäule",
            structure_id = 165
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 166,
            latin_name = "Musculus longissimus thoracis (dex.)",
            german_name = "Langer Rückenmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 166,
            ansatz = "Rippen und Querfortsätze der Brustwirbel",
            innervation = "Rr. dorsales der Spinalnerven (C4–L5)",
            funktion = "Dorsalextension und Lateralflexion der Wirbelsäule",
            structure_id = 166
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 167,
            latin_name = "Musculus multifidus (sin.)",
            german_name = "Vielgefiederter Muskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 167,
            ansatz = "Dornfortsätze der Wirbel, 2–4 Segmente überspannend",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung der Wirbelsäule, Dorsalextension und Rotation zur Gegenseite",
            structure_id = 167
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 168,
            latin_name = "Musculus multifidus (dex.)",
            german_name = "Vielgefiederter Muskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 168,
            ansatz = "Dornfortsätze der Wirbel, 2–4 Segmente überspannend",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung der Wirbelsäule, Dorsalextension und Rotation zur Gegenseite",
            structure_id = 168
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 169,
            latin_name = "Musculus obliquus inferior capitis (sin.)",
            german_name = "Unterer schräger Kopfmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 169,
            ansatz = "Processus transversus des Atlas (C1)",
            innervation = "N. suboccipitalis (C1)",
            funktion = "Rotation des Kopfes zur ipsilateralen Seite",
            structure_id = 169
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 170,
            latin_name = "Musculus obliquus inferior capitis (dex.)",
            german_name = "Unterer schräger Kopfmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 170,
            ansatz = "Processus transversus des Atlas (C1)",
            innervation = "N. suboccipitalis (C1)",
            funktion = "Rotation des Kopfes zur ipsilateralen Seite",
            structure_id = 170
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 171,
            latin_name = "Musculus obliquus superior capitis (sin.)",
            german_name = "Oberer schräger Kopfmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 171,
            ansatz = "Os occipitale zwischen Linea nuchae superior und inferior",
            innervation = "N. suboccipitalis (C1)",
            funktion = "Dorsalextension und Lateralflexion des Kopfes",
            structure_id = 171
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 172,
            latin_name = "Musculus obliquus superior capitis (dex.)",
            german_name = "Oberer schräger Kopfmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 172,
            ansatz = "Os occipitale zwischen Linea nuchae superior und inferior",
            innervation = "N. suboccipitalis (C1)",
            funktion = "Dorsalextension und Lateralflexion des Kopfes",
            structure_id = 172
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 173,
            latin_name = "Musculi rotatores (thoracis breves + longi) (sin.)",
            german_name = "Drehmuskeln (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 173,
            ansatz = "Dornfortsätze der Wirbel, überspringen 1 (breves) oder 2 (longi) Segmente",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Rotation und Stabilisierung der Wirbelsäule",
            structure_id = 173
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 174,
            latin_name = "Musculi rotatores (thoracis breves + longi) (dex.)",
            german_name = "Drehmuskeln (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 174,
            ansatz = "Dornfortsätze der Wirbel, überspringen 1 (breves) oder 2 (longi) Segmente",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Rotation und Stabilisierung der Wirbelsäule",
            structure_id = 174
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 175,
            latin_name = "Musculus semispinalis thoracis (sin.)",
            german_name = "Halbdornmuskel des Thorax (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 175,
            ansatz = "Dornfortsätze der Brust- und Halswirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Dorsalextension der Wirbelsäule und des Kopfes, Rotation zur Gegenseite",
            structure_id = 175
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 176,
            latin_name = "Musculus semispinalis thoracis (dex.)",
            german_name = "Halbdornmuskel des Thorax (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 176,
            ansatz = "Dornfortsätze der Brust- und Halswirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Dorsalextension der Wirbelsäule und des Kopfes, Rotation zur Gegenseite",
            structure_id = 176
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 177,
            latin_name = "Musculus spinalis thoracis (sin.)",
            german_name = "Dornmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 177,
            ansatz = "Dornfortsätze der oberen Brust- und unteren Halswirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Dorsalextension der Wirbelsäule",
            structure_id = 177
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 178,
            latin_name = "Musculus spinalis thoracis (dex.)",
            german_name = "Dornmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 178,
            ansatz = "Dornfortsätze der oberen Brust- und unteren Halswirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Dorsalextension der Wirbelsäule",
            structure_id = 178
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 181,
            latin_name = "Musculus serratus posterior superior (sin.)",
            german_name = "Oberer hinterer Sägemuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 181,
            ansatz = "Rippen 2–5 (kraniale Ränder)",
            innervation = "Nn. intercostales (Th1–Th4)",
            funktion = "Heben der Rippen, Unterstützung bei Inspiration",
            structure_id = 181
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 182,
            latin_name = "Musculus serratus posterior superior (dex.)",
            german_name = "Oberer hinterer Sägemuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 182,
            ansatz = "Rippen 2–5 (kraniale Ränder)",
            innervation = "Nn. intercostales (Th1–Th4)",
            funktion = "Heben der Rippen, Unterstützung bei Inspiration",
            structure_id = 182
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 183,
            latin_name = "Musculus serratus posterior inferior (sin.)",
            german_name = "Unterer hinterer Sägemuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 183,
            ansatz = "Rippen 9–12 (kaudale Ränder)",
            innervation = "Nn. intercostales (Th9–Th12)",
            funktion = "Senken der Rippen, Unterstützung bei Exspiration",
            structure_id = 183
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 184,
            latin_name = "Musculus serratus posterior inferior (dex.)",
            german_name = "Unterer hinterer Sägemuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 184,
            ansatz = "Rippen 9–12 (kaudale Ränder)",
            innervation = "Nn. intercostales (Th9–Th12)",
            funktion = "Senken der Rippen, Unterstützung bei Exspiration",
            structure_id = 184
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 185,
            latin_name = "Musculus latissimus dorsi (sin.)",
            german_name = "Breiter Rückenmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 185,
            ansatz = "Crista tuberculi minoris des Humerus",
            innervation = "N. thoracodorsalis (C6–C8)",
            funktion = "Adduktion, Innenrotation und Retroversion im Schultergelenk",
            structure_id = 185
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 186,
            latin_name = "Musculus latissimus dorsi (dex.)",
            german_name = "Breiter Rückenmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 186,
            ansatz = "Crista tuberculi minoris des Humerus",
            innervation = "N. thoracodorsalis (C6–C8)",
            funktion = "Adduktion, Innenrotation und Retroversion im Schultergelenk",
            structure_id = 186
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 187,
            latin_name = "Musculus rhomboideus minor (sin.)",
            german_name = "Kleiner Rautenmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 187,
            ansatz = "Margo medialis der Scapula (oberhalb der Spina scapulae)",
            innervation = "N. dorsalis scapulae (C4–C5)",
            funktion = "Fixierung der Scapula, Adduktion und Elevation der Scapula",
            structure_id = 187
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 188,
            latin_name = "Musculus rhomboideus minor (dex.)",
            german_name = "Kleiner Rautenmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 188,
            ansatz = "Margo medialis der Scapula (oberhalb der Spina scapulae)",
            innervation = "N. dorsalis scapulae (C4–C5)",
            funktion = "Fixierung der Scapula, Adduktion und Elevation der Scapula",
            structure_id = 188
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 189,
            latin_name = "Musculus rhomboideus major (sin.)",
            german_name = "Großer Rautenmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 189,
            ansatz = "Margo medialis der Scapula (unterhalb der Spina scapulae)",
            innervation = "N. dorsalis scapulae (C4–C5)",
            funktion = "Fixierung der Scapula, Adduktion und Elevation der Scapula",
            structure_id = 189
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 190,
            latin_name = "Musculus rhomboideus major (dex.)",
            german_name = "Großer Rautenmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 190,
            ansatz = "Margo medialis der Scapula (unterhalb der Spina scapulae)",
            innervation = "N. dorsalis scapulae (C4–C5)",
            funktion = "Fixierung der Scapula, Adduktion und Elevation der Scapula",
            structure_id = 190
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 191,
            latin_name = "Musculus trapezius (sin.)",
            german_name = "Kapuzenmuskel (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 191,
            ansatz = "Laterales Drittel der Clavicula, Acromion, Spina scapulae",
            innervation = "N. accessorius (XI. Hirnnerv) und Plexus cervicalis (C2–C4)",
            funktion = "Fixierung der Scapula, Elevation, Depression, Retraktion und Rotation der Scapula",
            structure_id = 191
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 192,
            latin_name = "Musculus trapezius (dex.)",
            german_name = "Kapuzenmuskel (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 192,
            ansatz = "Laterales Drittel der Clavicula, Acromion, Spina scapulae",
            innervation = "N. accessorius (XI. Hirnnerv) und Plexus cervicalis (C2–C4)",
            funktion = "Fixierung der Scapula, Elevation, Depression, Retraktion und Rotation der Scapula",
            structure_id = 192
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 193,
            latin_name = "Musculi interspinales thoracis (sin.)",
            german_name = "Zwischenwirbelmuskeln der Brustwirbelsäule (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 193,
            ansatz = "Dornfortsätze der benachbarten Brustwirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung und Dorsalextension der Brustwirbelsäule",
            structure_id = 193
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 194,
            latin_name = "Musculi interspinales thoracis (dex.)",
            german_name = "Zwischenwirbelmuskeln der Brustwirbelsäule (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 194,
            ansatz = "Dornfortsätze der benachbarten Brustwirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung und Dorsalextension der Brustwirbelsäule",
            structure_id = 194
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 195,
            latin_name = "Musculi intertransversarii thoracis (sin.)",
            german_name = "Zwischenquerfortsatzmuskeln der Brustwirbelsäule (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 195,
            ansatz = "Querfortsätze der benachbarten Brustwirbel",
            innervation = "Rr. dorsales und ventrales der Spinalnerven",
            funktion = "Lateralflexion der Brustwirbelsäule",
            structure_id = 195
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 196,
            latin_name = "Musculi intertransversarii thoracis (dex.)",
            german_name = "Zwischenquerfortsatzmuskeln der Brustwirbelsäule (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 196,
            ansatz = "Querfortsätze der benachbarten Brustwirbel",
            innervation = "Rr. dorsales und ventrales der Spinalnerven",
            funktion = "Lateralflexion der Brustwirbelsäule",
            structure_id = 196
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 197,
            latin_name = "Musculus abductor pollicis longus (sin.)",
            german_name = "Daumenabduktor (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 197,
            ansatz = "Insertion an der Basis des Os metacarpale I",
            innervation = "N. radialis (C7–C8)",
            funktion = "Abduktion und Extension des Daumens",
            structure_id = 197
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 198,
            latin_name = "Musculus abductor pollicis longus (dex.)",
            german_name = "Daumenabduktor (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 198,
            ansatz = "Insertion an der Basis des Os metacarpale I",
            innervation = "N. radialis (C7–C8)",
            funktion = "Abduktion und Extension des Daumens",
            structure_id = 198
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 199,
            latin_name = "Musculus extensor indicis (sin.)",
            german_name = "Zeigefingerstrecker (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 199,
            ansatz = "Ansatz über die dorsale Aponeurose des 2. Fingers",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension des Zeigefingers; unterstützt die Dorsalextension im Handgelenk",
            structure_id = 199
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 200,
            latin_name = "Musculus extensor indicis (dex.)",
            german_name = "Zeigefingerstrecker (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 200,
            ansatz = "Ansatz über die dorsale Aponeurose des 2. Fingers",
            innervation = "N. radialis (C7–C8)",
            funktion = "Extension des Zeigefingers; unterstützt die Dorsalextension im Handgelenk",
            structure_id = 200
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 201,
            latin_name = "Musculus palmaris longus (sin.)",
            german_name = "Langer Palmaris (li.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 201,
            ansatz = "Ansatz über die Palmaraponeurose der Handfläche",
            innervation = "N. medianus (C7–C8)",
            funktion = "Flexion im Handgelenk und Spannung der Handfläche",
            structure_id = 201
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 202,
            latin_name = "Musculus palmaris longus (dex.)",
            german_name = "Langer Palmaris (re.)",
            category = "Armmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 202,
            ansatz = "Ansatz über die Palmaraponeurose der Handfläche",
            innervation = "N. medianus (C7–C8)",
            funktion = "Flexion im Handgelenk und Spannung der Handfläche",
            structure_id = 202
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 203,
            latin_name = "Musculi interspinales thoracis_2 (sin.)",
            german_name = "Zwischenwirbelmuskeln der Brustwirbelsäule (li.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 203,
            ansatz = "Dornfortsätze der benachbarten Brustwirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung und Dorsalextension der Brustwirbelsäule",
            structure_id = 193
        });

        _connection.Insert(new AnatomicalStructures
        {
            id = 204,
            latin_name = "Musculi interspinales thoracis_2 (dex.)",
            german_name = "Zwischenwirbelmuskeln der Brustwirbelsäule (re.)",
            category = "Rückenmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 204,
            ansatz = "Dornfortsätze der benachbarten Brustwirbel",
            innervation = "Rr. dorsales der Spinalnerven",
            funktion = "Stabilisierung und Dorsalextension der Brustwirbelsäule",
            structure_id = 194
        });
        
        //NEW
        // Bauchmuskulatur – Linea alba (links)
        _connection.Insert(new AnatomicalStructures
        {
            id = 205,
            latin_name = "Linea alba",
            german_name = "Linea alba (li.)",
            category = "Bauchmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 205,
            ansatz = "Zwischen Processus xiphoideus und Symphyse",
            innervation = "Keine direkte Innervation – Bindegewebsstruktur",
            funktion = "Verbindung der Bauchmuskeln beider Seiten; Unterstützung der Bauchpresse",
            structure_id = 205
        });
        
        // Musculus pectoralis major (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 206,
            latin_name = "Musculus pectoralis major (dex.)",
            german_name = "Großer Brustmuskel (re.)",
            category = "Brustmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 206,
            ansatz = "Crista tuberculi majoris des Humerus",
            innervation = "Nn. pectorales medialis und lateralis (Th5–Th7)",
            funktion = "Adduktion, Innenrotation und Anteversion des Arms",
            structure_id = 206
        });

        // Musculus pectoralis major (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 207,
            latin_name = "Musculus pectoralis major (sin.)",
            german_name = "Großer Brustmuskel (li.)",
            category = "Brustmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 207,
            ansatz = "Crista tuberculi majoris des Humerus",
            innervation = "Nn. pectorales medialis und lateralis (Th5–Th7)",
            funktion = "Adduktion, Innenrotation und Anteversion des Arms",
            structure_id = 207
        });

        // Levator labii superioris alaeque nasi (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 208,
            latin_name = "M levator labii superioris alaeque nasi (dex.)",
            german_name = "Muskelheber der Oberlippe und Nasenflügel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 208,
            ansatz = "Haut der Oberlippe und Nasenflügel",
            innervation = "N. facialis (VII)",
            funktion = "Hebt Oberlippe und erweitert Nasenloch",
            structure_id = 208
        });

        // Levator labii superioris alaeque nasi (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 209,
            latin_name = "M levator labii superioris alaeque nasi (sin.)",
            german_name = "Muskelheber der Oberlippe und Nasenflügel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 209,
            ansatz = "Haut der Oberlippe und Nasenflügel",
            innervation = "N. facialis (VII)",
            funktion = "Hebt Oberlippe und erweitert Nasenloch",
            structure_id = 209
        });

        // Musculus auricularis anterior (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 210,
            latin_name = "Musculus auricularis anterior (dex.)",
            german_name = "Vorderer Ohrmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 210,
            ansatz = "Haut vor der Ohrmuschel",
            innervation = "N. facialis (VII)",
            funktion = "Bewegt Ohrmuschel nach vorn",
            structure_id = 210
        });

        // Musculus auricularis anterior (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 211,
            latin_name = "Musculus auricularis anterior (sin.)",
            german_name = "Vorderer Ohrmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 211,
            ansatz = "Haut vor der Ohrmuschel",
            innervation = "N. facialis (VII)",
            funktion = "Bewegt Ohrmuschel nach vorn",
            structure_id = 211
        });

        // Musculus auricularis posterior (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 212,
            latin_name = "Musculus auricularis posterior (dex.)",
            german_name = "Hinterer Ohrmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 212,
            ansatz = "Haut der Ohrmuschel",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Ohrmuschel nach hinten",
            structure_id = 212
        });

        // Musculus auricularis posterior (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 213,
            latin_name = "Musculus auricularis posterior (sin.)",
            german_name = "Hinterer Ohrmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 213,
            ansatz = "Haut der Ohrmuschel",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Ohrmuschel nach hinten",
            structure_id = 213
        });

        // Musculus auricularis superior (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 214,
            latin_name = "Musculus auricularis superior (dex.)",
            german_name = "Oberer Ohrmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 214,
            ansatz = "Galea aponeurotica zur Ohrmuschel",
            innervation = "N. facialis (VII)",
            funktion = "Hebt die Ohrmuschel leicht an",
            structure_id = 214
        });

        // Musculus auricularis superior (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 215,
            latin_name = "Musculus auricularis superior (sin.)",
            german_name = "Oberer Ohrmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 215,
            ansatz = "Galea aponeurotica zur Ohrmuschel",
            innervation = "N. facialis (VII)",
            funktion = "Hebt die Ohrmuschel leicht an",
            structure_id = 215
        });

        // Musculus corrugator supercilii (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 216,
            latin_name = "Musculus corrugator supercilii (dex.)",
            german_name = "Augenbrauenrunzler (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 216,
            ansatz = "Haut der Augenbraue medial",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Augenbraue nach medial und unten (zorniger Gesichtsausdruck)",
            structure_id = 216
        });

        // Musculus corrugator supercilii (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 217,
            latin_name = "Musculus corrugator supercilii (sin.)",
            german_name = "Augenbrauenrunzler (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 217,
            ansatz = "Haut der Augenbraue medial",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Augenbraue nach medial und unten (zorniger Gesichtsausdruck)",
            structure_id = 217
        });

        // Musculus depressor labii inferioris (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 218,
            latin_name = "Musculus depressor labii inferioris (dex.)",
            german_name = "Unterlippenherabzieher (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 218,
            ansatz = "Haut der Unterlippe",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Unterlippe nach unten und lateral",
            structure_id = 218
        });

        // Musculus depressor labii inferioris (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 219,
            latin_name = "Musculus depressor labii inferioris (sin.)",
            german_name = "Unterlippenherabzieher (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 219,
            ansatz = "Haut der Unterlippe",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Unterlippe nach unten und lateral",
            structure_id = 219
        });

        // Musculus depressor septi nasi (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 220,
            latin_name = "Musculus depressor septi nasi (dex.)",
            german_name = "Nasenscheidewand-Senker (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 220,
            ansatz = "Nasenseptum und unterer Nasenflügel",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Nasenscheidewand nach unten, erweitert die Nasenlöcher",
            structure_id = 220
        });

        // Musculus depressor septi nasi (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 221,
            latin_name = "Musculus depressor septi nasi (sin.)",
            german_name = "Nasenscheidewand-Senker (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 221,
            ansatz = "Nasenseptum und unterer Nasenflügel",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Nasenscheidewand nach unten, erweitert die Nasenlöcher",
            structure_id = 221
        });

        // Musculus depressor supercilii (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 222,
            latin_name = "Musculus depressor supercilii (dex.)",
            german_name = "Augenbrauensenker (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 222,
            ansatz = "Haut der medialen Augenbraue",
            innervation = "N. facialis (VII)",
            funktion = "Senkt die mediale Augenbraue, beteiligt an Stirnrunzeln",
            structure_id = 222
        });

        // Musculus depressor supercilii (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 223,
            latin_name = "Musculus depressor supercilii (sin.)",
            german_name = "Augenbrauensenker (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 223,
            ansatz = "Haut der medialen Augenbraue",
            innervation = "N. facialis (VII)",
            funktion = "Senkt die mediale Augenbraue, beteiligt an Stirnrunzeln",
            structure_id = 223
        });

        // Musculus frontalis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 224,
            latin_name = "Musculus frontalis (dex.)",
            german_name = "Stirnmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 224,
            ansatz = "Haut der Stirn und Augenbraue",
            innervation = "N. facialis (VII)",
            funktion = "Hebt die Augenbrauen und runzelt die Stirn",
            structure_id = 224
        });

        // Musculus frontalis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 225,
            latin_name = "Musculus frontalis (sin.)",
            german_name = "Stirnmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 225,
            ansatz = "Haut der Stirn und Augenbraue",
            innervation = "N. facialis (VII)",
            funktion = "Hebt die Augenbrauen und runzelt die Stirn",
            structure_id = 225
        });

        // Musculus levator anguli oris (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 226,
            latin_name = "Musculus levator anguli oris (dex.)",
            german_name = "Mundwinkelheber (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 226,
            ansatz = "Haut des Mundwinkels",
            innervation = "N. facialis (VII)",
            funktion = "Hebt den Mundwinkel (z. B. beim Lächeln)",
            structure_id = 226
        });

        // Musculus levator anguli oris (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 227,
            latin_name = "Musculus levator anguli oris (sin.)",
            german_name = "Mundwinkelheber (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 227,
            ansatz = "Haut des Mundwinkels",
            innervation = "N. facialis (VII)",
            funktion = "Hebt den Mundwinkel (z. B. beim Lächeln)",
            structure_id = 227
        });

        // Musculus levator labii superioris (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 228,
            latin_name = "Musculus levator labii superioris (dex.)",
            german_name = "Oberlippenheber (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 228,
            ansatz = "Haut der Oberlippe",
            innervation = "N. facialis (VII)",
            funktion = "Hebt die Oberlippe (z. B. beim Ekel- oder Schmollausdruck)",
            structure_id = 228
        });

        // Musculus levator labii superioris (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 229,
            latin_name = "Musculus levator labii superioris (sin.)",
            german_name = "Oberlippenheber (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 229,
            ansatz = "Haut der Oberlippe",
            innervation = "N. facialis (VII)",
            funktion = "Hebt die Oberlippe (z. B. beim Ekel- oder Schmollausdruck)",
            structure_id = 229
        });

        // Musculus masseter (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 230,
            latin_name = "Musculus masseter (dex.)",
            german_name = "Kaumuskel (re.)",
            category = "Kaumuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 230,
            ansatz = "Ramus mandibulae und Angulus mandibulae",
            innervation = "N. mandibularis (V3)",
            funktion = "Hebt den Unterkiefer (Kieferschluss)",
            structure_id = 230
        });
        
        // Musculus masseter (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 231,
            latin_name = "Musculus masseter (sin.)",
            german_name = "Kaumuskel (li.)",
            category = "Kaumuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 231,
            ansatz = "Ramus mandibulae und Angulus mandibulae",
            innervation = "N. mandibularis (V3)",
            funktion = "Hebt den Unterkiefer (Kieferschluss)",
            structure_id = 231
        });

        // Musculus mentalis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 232,
            latin_name = "Musculus mentalis (dex.)",
            german_name = "Kinnmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 232,
            ansatz = "Haut des Kinns",
            innervation = "N. facialis (VII)",
            funktion = "Hebt die Haut des Kinns und wölbt die Unterlippe vor",
            structure_id = 232
        });

        // Musculus mentalis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 233,
            latin_name = "Musculus mentalis (sin.)",
            german_name = "Kinnmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 233,
            ansatz = "Haut des Kinns",
            innervation = "N. facialis (VII)",
            funktion = "Hebt die Haut des Kinns und wölbt die Unterlippe vor",
            structure_id = 233
        });

        // Musculus nasalis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 234,
            latin_name = "Musculus nasalis (dex.)",
            german_name = "Nasemuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 234,
            ansatz = "Nasenseptum und Nasenflügel",
            innervation = "N. facialis (VII)",
            funktion = "Verengt oder erweitert die Nasenlöcher (je nach Teil)",
            structure_id = 234
        });

        // Musculus nasalis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 235,
            latin_name = "Musculus nasalis (sin.)",
            german_name = "Nasemuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 235,
            ansatz = "Nasenseptum und Nasenflügel",
            innervation = "N. facialis (VII)",
            funktion = "Verengt oder erweitert die Nasenlöcher (je nach Teil)",
            structure_id = 235
        });

        // Musculus occipitalis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 236,
            latin_name = "Musculus occipitalis (dex.)",
            german_name = "Hinterhauptmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 236,
            ansatz = "Galea aponeurotica",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Kopfhaut nach hinten",
            structure_id = 236
        });
        
        // Musculus occipitalis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 237,
            latin_name = "Musculus occipitalis (sin.)",
            german_name = "Hinterhauptmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 237,
            ansatz = "Galea aponeurotica",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Kopfhaut nach hinten",
            structure_id = 237
        });

        // Musculus orbicularis oculi (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 238,
            latin_name = "Musculus orbicularis oculi (dex.)",
            german_name = "Augenschließmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 238,
            ansatz = "Haut um die Augenlider",
            innervation = "N. facialis (VII)",
            funktion = "Schließt die Augenlider (willkürlich und reflektorisch)",
            structure_id = 238
        });

        // Musculus orbicularis oculi (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 239,
            latin_name = "Musculus orbicularis oculi (sin.)",
            german_name = "Augenschließmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 239,
            ansatz = "Haut um die Augenlider",
            innervation = "N. facialis (VII)",
            funktion = "Schließt die Augenlider (willkürlich und reflektorisch)",
            structure_id = 239
        });

        // Musculus orbicularis oris
        _connection.Insert(new AnatomicalStructures
        {
            id = 240,
            latin_name = "Musculus orbicularis oris",
            german_name = "Mundringmuskel",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 240,
            ansatz = "Haut und Schleimhaut der Lippen",
            innervation = "N. facialis (VII)",
            funktion = "Schließt und spitzt die Lippen (z. B. beim Pfeifen, Kussmund)",
            structure_id = 240
        });

        // Musculus procerus (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 241,
            latin_name = "Musculus procerus (dex.)",
            german_name = "Stirnrunzler (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 241,
            ansatz = "Haut zwischen den Augenbrauen",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Haut der Stirn nach unten; bildet Querfalten über der Nasenwurzel",
            structure_id = 241
        });

        // Musculus procerus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 242,
            latin_name = "Musculus procerus (sin.)",
            german_name = "Stirnrunzler (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 242,
            ansatz = "Haut zwischen den Augenbrauen",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Haut der Stirn nach unten; bildet Querfalten über der Nasenwurzel",
            structure_id = 242
        });

        // Musculus pterygoideus lateralis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 243,
            latin_name = "Musculus pterygoideus lateralis  (dex.)",
            german_name = "Äußerer Flügelmuskel (re.)",
            category = "Kaumuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 243,
            ansatz = "Kiefergelenkkapsel, Discus articularis, Processus condylaris mandibulae",
            innervation = "N. mandibularis (V3)",
            funktion = "Kiefervorschub und Kieferöffnung, Mahlbewegung mit einseitiger Aktivität",
            structure_id = 243
        });

        // Musculus pterygoideus lateralis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 244,
            latin_name = "Musculus pterygoideus lateralis  (sin.)",
            german_name = "Äußerer Flügelmuskel (li.)",
            category = "Kaumuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 244,
            ansatz = "Kiefergelenkkapsel, Discus articularis, Processus condylaris mandibulae",
            innervation = "N. mandibularis (V3)",
            funktion = "Kiefervorschub und Kieferöffnung, Mahlbewegung mit einseitiger Aktivität",
            structure_id = 244
        });

        // Musculus pterygoideus medialis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 245,
            latin_name = "Musculus pterygoideus medialis (dex.)",
            german_name = "Innerer Flügelmuskel (re.)",
            category = "Kaumuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 245,
            ansatz = "Tuberositas pterygoidea an der Mandibula",
            innervation = "N. mandibularis (V3)",
            funktion = "Hebt den Unterkiefer, Mahlbewegung bei einseitiger Kontraktion",
            structure_id = 245
        });

        // Musculus pterygoideus medialis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 246,
            latin_name = "Musculus pterygoideus medialis (sin.)",
            german_name = "Innerer Flügelmuskel (li.)",
            category = "Kaumuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 246,
            ansatz = "Tuberositas pterygoidea an der Mandibula",
            innervation = "N. mandibularis (V3)",
            funktion = "Hebt den Unterkiefer, Mahlbewegung bei einseitiger Kontraktion",
            structure_id = 246
        });

        // Musculus risorius (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 247,
            latin_name = "Musculus risorius (dex.)",
            german_name = "Lachmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 247,
            ansatz = "Haut am Mundwinkel",
            innervation = "N. facialis (VII)",
            funktion = "Zieht den Mundwinkel nach lateral (Lächeln)",
            structure_id = 247
        });

        // Musculus risorius (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 248,
            latin_name = "Musculus risorius (sin.)",
            german_name = "Lachmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 248,
            ansatz = "Haut am Mundwinkel",
            innervation = "N. facialis (VII)",
            funktion = "Zieht den Mundwinkel nach lateral (Lächeln)",
            structure_id = 248
        });

        // Musculus temporalis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 249,
            latin_name = "Musculus temporalis (dex.)",
            german_name = "Schläfenmuskel (re.)",
            category = "Kaumuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 249,
            ansatz = "Processus coronoideus der Mandibula",
            innervation = "N. mandibularis (V3)",
            funktion = "Hebt und retrahiert den Unterkiefer",
            structure_id = 249
        });

        // Musculus temporalis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 250,
            latin_name = "Musculus temporalis (sin.)",
            german_name = "Schläfenmuskel (li.)",
            category = "Kaumuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 250,
            ansatz = "Processus coronoideus der Mandibula",
            innervation = "N. mandibularis (V3)",
            funktion = "Hebt und retrahiert den Unterkiefer",
            structure_id = 250
        });

        // Musculus temporoparietalis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 251,
            latin_name = "Musculus temporoparietalis (dex.)",
            german_name = "Schläfen-Scheitelmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 251,
            ansatz = "Galea aponeurotica",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Kopfhaut nach oben und seitlich",
            structure_id = 251
        });

        // Musculus temporoparietalis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 252,
            latin_name = "Musculus temporoparietalis (sin.)",
            german_name = "Schläfen-Scheitelmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 252,
            ansatz = "Galea aponeurotica",
            innervation = "N. facialis (VII)",
            funktion = "Zieht die Kopfhaut nach oben und seitlich",
            structure_id = 252
        });

        // Musculus zygomaticus (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 253,
            latin_name = "Musculus zygomaticus  (dex.)",
            german_name = "Jochbeinmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 253,
            ansatz = "Mundwinkel",
            innervation = "N. facialis (VII)",
            funktion = "Zieht den Mundwinkel nach oben und lateral (Lächeln)",
            structure_id = 253
        });

        // Musculus zygomaticus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 254,
            latin_name = "Musculus zygomaticus  (sin.)",
            german_name = "Jochbeinmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 254,
            ansatz = "Mundwinkel",
            innervation = "N. facialis (VII)",
            funktion = "Zieht den Mundwinkel nach oben und lateral (Lächeln)",
            structure_id = 254
        });

        // Musculus buccinator (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 255,
            latin_name = "Musculus buccinator (dex.)",
            german_name = "Wangenmuskel (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 255,
            ansatz = "Raphe pterygomandibularis und Alveolarknochen der Mandibula",
            innervation = "N. facialis (VII)",
            funktion = "Komprimiert die Wange, hält Nahrung zwischen den Zähnen beim Kauen",
            structure_id = 255
        });

        // Musculus buccinator (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 256,
            latin_name = "Musculus buccinator (sin.)",
            german_name = "Wangenmuskel (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 256,
            ansatz = "Raphe pterygomandibularis und Alveolarknochen der Mandibula",
            innervation = "N. facialis (VII)",
            funktion = "Komprimiert die Wange, hält Nahrung zwischen den Zähnen beim Kauen",
            structure_id = 256
        });

        // Musculus depressor anguli oris (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 257,
            latin_name = "Musculus depressor anguli oris (dex.)",
            german_name = "Mundwinkelzieher (re.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 257,
            ansatz = "Mandibula",
            innervation = "N. facialis (VII)",
            funktion = "Zieht den Mundwinkel nach unten (Trauriger Gesichtsausdruck)",
            structure_id = 257
        });

        // Musculus depressor anguli oris (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 258,
            latin_name = "Musculus depressor anguli oris (sin.)",
            german_name = "Mundwinkelzieher (li.)",
            category = "Mimische Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 258,
            ansatz = "Mandibula",
            innervation = "N. facialis (VII)",
            funktion = "Zieht den Mundwinkel nach unten (Trauriger Gesichtsausdruck)",
            structure_id = 258
        });

        // Musculus obliquus internus abdominis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 259,
            latin_name = "Musculus obliquus internus abdominis(sin.)",
            german_name = "Innerer schräger Bauchmuskel (li.)",
            category = "Bauchmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 259,
            ansatz = "Crista iliaca, Fascia thoracolumbalis",
            innervation = "Nn. intercostales (T7–T12), N. iliohypogastricus, N. ilioinguinalis",
            funktion = "Rumpfbeugung und Rotation, Bauchpresse",
            structure_id = 259
        });

        // Musculus obliquus internus abdominis (li.) Variante
        _connection.Insert(new AnatomicalStructures
        {
            id = 260,
            latin_name = "Musculus obliquus internus abdominis(sin.)",
            german_name = "Innerer schräger Bauchmuskel (li.) Variante",
            category = "Bauchmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 260,
            ansatz = "Crista iliaca, Fascia thoracolumbalis",
            innervation = "Nn. intercostales (T7–T12), N. iliohypogastricus, N. ilioinguinalis",
            funktion = "Rumpfbeugung und Rotation, Bauchpresse",
            structure_id = 260
        });

        // Musculi digastrici (re.) Variante 002
        _connection.Insert(new AnatomicalStructures
        {
            id = 261,
            latin_name = "musculi digastrici (dex.)",
            german_name = "Zweibauchmuskel (re.) Variante 002",
            category = "Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 261,
            ansatz = "Margo inferior mandibulae (Venter anterior), Os occipitale (Venter posterior)",
            innervation = "N. mylohyoideus (V3) und N. facialis (VII)",
            funktion = "Öffnet den Mund, zieht das Zungenbein nach oben",
            structure_id = 261
        });

        // Musculi digastrici (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 262,
            latin_name = "musculi digastrici (dex.)",
            german_name = "Zweibauchmuskel (re.) Variante L",
            category = "Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 262,
            ansatz = "Margo inferior mandibulae (Venter anterior), Os occipitale (Venter posterior)",
            innervation = "N. mylohyoideus (V3) und N. facialis (VII)",
            funktion = "Öffnet den Mund, zieht das Zungenbein nach oben",
            structure_id = 262
        });

        // Musculi digastrici (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 263,
            latin_name = "musculi digastrici (dex.)",
            german_name = "Zweibauchmuskel (re.) Variante L",
            category = "Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 263,
            ansatz = "Margo inferior mandibulae (Venter anterior), Os occipitale (Venter posterior)",
            innervation = "N. mylohyoideus (V3) und N. facialis (VII)",
            funktion = "Öffnet den Mund, zieht das Zungenbein nach oben",
            structure_id = 263
        });

        // Musculi digastrici (li.) Variante 002
        _connection.Insert(new AnatomicalStructures
        {
            id = 264,
            latin_name = "musculi digastrici (sin.)",
            german_name = "Zweibauchmuskel (li.) Variante 002",
            category = "Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 264,
            ansatz = "Margo inferior mandibulae (Venter anterior), Os occipitale (Venter posterior)",
            innervation = "N. mylohyoideus (V3) und N. facialis (VII)",
            funktion = "Öffnet den Mund, zieht das Zungenbein nach oben",
            structure_id = 264
        });

        // Musculi digastrici (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 265,
            latin_name = "musculi digastrici (sin.)",
            german_name = "Zweibauchmuskel (li.) Variante L",
            category = "Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 265,
            ansatz = "Margo inferior mandibulae (Venter anterior), Os occipitale (Venter posterior)",
            innervation = "N. mylohyoideus (V3) und N. facialis (VII)",
            funktion = "Öffnet den Mund, hebt das Zungenbein",
            structure_id = 265
        });

        // Musculi digastrici (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 266,
            latin_name = "musculi digastrici (sin.)",
            german_name = "Zweibauchmuskel (li.) Variante L",
            category = "Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 266,
            ansatz = "Margo inferior mandibulae (Venter anterior), Os occipitale (Venter posterior)",
            innervation = "N. mylohyoideus (V3) und N. facialis (VII)",
            funktion = "Öffnet den Mund, hebt das Zungenbein",
            structure_id = 266
        });

        // Musculus geniohyoideus (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 267,
            latin_name = "Musculus geniohyoideus (dex.)",
            german_name = "Kinn-Zungenbeinmuskel (re.)",
            category = "Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 267,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Ramus anterior aus C1 via N. hypoglossus (XII)",
            funktion = "Zieht das Zungenbein nach vorne-oben, unterstützt das Schlucken",
            structure_id = 267
        });

        // Musculus geniohyoideus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 268,
            latin_name = "Musculus geniohyoideus (sin.)",
            german_name = "Kinn-Zungenbeinmuskel (li.)",
            category = "Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 268,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Ramus anterior aus C1 via N. hypoglossus (XII)",
            funktion = "Zieht das Zungenbein nach vorne-oben, unterstützt das Schlucken",
            structure_id = 268
        });

        // Musculus longus capitis (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 269,
            latin_name = "Musculus longus capitis (dex.)",
            german_name = "Langer Kopfmuskel (re.) Variante L",
            category = "Prävertebrale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 269,
            ansatz = "Pars basilaris ossis occipitalis",
            innervation = "Plexus cervicalis (C1–C3)",
            funktion = "Beugung des Kopfes nach vorne",
            structure_id = 269
        });

        // Musculus longus capitis (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 270,
            latin_name = "Musculus longus capitis (sin.)",
            german_name = "Langer Kopfmuskel (li.) Variante L",
            category = "Prävertebrale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 270,
            ansatz = "Pars basilaris ossis occipitalis",
            innervation = "Plexus cervicalis (C1–C3)",
            funktion = "Beugung des Kopfes nach vorne",
            structure_id = 270
        });

        // Musculus longus colli (re.) Variante 002
        _connection.Insert(new AnatomicalStructures
        {
            id = 271,
            latin_name = "Musculus longus colli (dex.)",
            german_name = "Langer Halsmuskel (re.) Variante 002",
            category = "Prävertebrale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 271,
            ansatz = "Ventrale Flächen der Hals- und oberen Brustwirbelkörper",
            innervation = "Plexus cervicalis (C2–C6)",
            funktion = "Beugung und Rotation der Halswirbelsäule",
            structure_id = 271
        });

        // Musculus longus colli (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 272,
            latin_name = "Musculus longus colli (dex.)",
            german_name = "Langer Halsmuskel (re.) Variante L",
            category = "Prävertebrale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 272,
            ansatz = "Ventrale Flächen der Hals- und oberen Brustwirbelkörper",
            innervation = "Plexus cervicalis (C2–C6)",
            funktion = "Beugung und Rotation der Halswirbelsäule",
            structure_id = 272
        });

        // Musculus longus colli (li.) Variante 002
        _connection.Insert(new AnatomicalStructures
        {
            id = 273,
            latin_name = "Musculus longus colli (sin.)",
            german_name = "Langer Halsmuskel (li.) Variante 002",
            category = "Prävertebrale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 273,
            ansatz = "Ventrale Flächen der Hals- und oberen Brustwirbelkörper",
            innervation = "Plexus cervicalis (C2–C6)",
            funktion = "Beugung und Rotation der Halswirbelsäule",
            structure_id = 273
        });

        // Musculus longus colli (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 274,
            latin_name = "Musculus longus colli (sin.)",
            german_name = "Langer Halsmuskel (li.) Variante L",
            category = "Prävertebrale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 274,
            ansatz = "Ventrale Flächen der Hals- und oberen Brustwirbelkörper",
            innervation = "Plexus cervicalis (C2–C6)",
            funktion = "Beugung und Rotation der Halswirbelsäule",
            structure_id = 274
        });

        // Musculus mylohyoideus (re.) Variante R2
        _connection.Insert(new AnatomicalStructures
        {
            id = 275,
            latin_name = "Musculus mylohyoideus (dex.)2",
            german_name = "Kiefer-Zungenbeinmuskel (re.) Variante R2",
            category = "Mundbodenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 275,
            ansatz = "Raphe mylohyoidea und Corpus ossis hyoidei",
            innervation = "N. mylohyoideus (aus V3)",
            funktion = "Spannt den Mundboden und hebt das Zungenbein",
            structure_id = 275
        });

        // Musculus mylohyoideus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 276,
            latin_name = "Musculus mylohyoideus (sin.)",
            german_name = "Kiefer-Zungenbeinmuskel (li.)",
            category = "Mundbodenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 276,
            ansatz = "Raphe mylohyoidea und Corpus ossis hyoidei",
            innervation = "N. mylohyoideus (aus V3)",
            funktion = "Spannt den Mundboden und hebt das Zungenbein",
            structure_id = 276
        });

        // Musculus rectus anterior capitis (re.) Variante L.011
        _connection.Insert(new AnatomicalStructures
        {
            id = 277,
            latin_name = "Musculus rectus anterior capitis (dex.).011",
            german_name = "Vorderer gerader Kopfmuskel (re.) Variante L.011",
            category = "Tiefer Nackenmuskel",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 277,
            ansatz = "Pars basilaris ossis occipitalis",
            innervation = "Plexus cervicalis (C1–C2)",
            funktion = "Beugung des Kopfes nach vorne",
            structure_id = 277
        });

        // Musculus rectus anterior capitis (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 278,
            latin_name = "Musculus rectus anterior capitis (sin.)",
            german_name = "Vorderer gerader Kopfmuskel (li.) Variante L",
            category = "Tiefer Nackenmuskel",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 278,
            ansatz = "Pars basilaris ossis occipitalis",
            innervation = "Plexus cervicalis (C1–C2)",
            funktion = "Beugung des Kopfes nach vorne",
            structure_id = 278
        });

        // Musculus scalenus anterior (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 279,
            latin_name = "Musculus scalenus anterior (dex.)",
            german_name = "Vorderer Treppenmuskel (re.) Variante L",
            category = "Skalenusgruppe",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 279,
            ansatz = "Tuberculum musculi scaleni anterioris der 1. Rippe",
            innervation = "Plexus brachialis und Plexus cervicalis (C5–C7)",
            funktion = "Hebung der 1. Rippe, Lateralflexion der Halswirbelsäule",
            structure_id = 279
        });

        // Musculus scalenus anterior (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 280,
            latin_name = "Musculus scalenus anterior (sin.)",
            german_name = "Vorderer Treppenmuskel (li.) Variante L",
            category = "Skalenusgruppe",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 280,
            ansatz = "Tuberculum musculi scaleni anterioris der 1. Rippe",
            innervation = "Plexus brachialis und Plexus cervicalis (C5–C7)",
            funktion = "Hebung der 1. Rippe, Lateralflexion der Halswirbelsäule",
            structure_id = 280
        });

        // Musculus scalenus medius (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 281,
            latin_name = "Musculus scalenus medius (dex.)",
            german_name = "Mittlerer Treppenmuskel (re.) Variante L",
            category = "Skalenusgruppe",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 281,
            ansatz = "1. Rippe (dorsal des Sulcus arteriae subclaviae)",
            innervation = "Plexus brachialis und Plexus cervicalis (C3–C8)",
            funktion = "Hebung der 1. Rippe, Lateralflexion der Halswirbelsäule",
            structure_id = 281
        });

        // Musculus scalenus medius (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 282,
            latin_name = "Musculus scalenus medius (sin.)",
            german_name = "Mittlerer Treppenmuskel (li.) Variante L",
            category = "Skalenusgruppe",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 282,
            ansatz = "1. Rippe (dorsal des Sulcus arteriae subclaviae)",
            innervation = "Plexus brachialis und Plexus cervicalis (C3–C8)",
            funktion = "Hebung der 1. Rippe, Lateralflexion der Halswirbelsäule",
            structure_id = 282
        });

        // Musculus scalenus minimus (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 283,
            latin_name = "Musculus scalenus minimus (dex.)",
            german_name = "Kleinster Treppenmuskel (re.) Variante L",
            category = "Skalenusgruppe",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 283,
            ansatz = "Innenfläche der 1. Rippe und Pleura cupula",
            innervation = "Plexus brachialis",
            funktion = "Hebung der 1. Rippe, Unterstützung der Atmung",
            structure_id = 283
        });

        // Musculus scalenus minimus (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 284,
            latin_name = "Musculus scalenus minimus (sin.)",
            german_name = "Kleinster Treppenmuskel (li.) Variante L",
            category = "Skalenusgruppe",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 284,
            ansatz = "Innenfläche der 1. Rippe und Pleura cupula",
            innervation = "Plexus brachialis",
            funktion = "Hebung der 1. Rippe, Unterstützung der Atmung",
            structure_id = 284
        });

        // Musculus scalenus posterior (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 285,
            latin_name = "Musculus scalenus posterior (dex.)",
            german_name = "Hinterer Treppenmuskel (re.) Variante L",
            category = "Skalenusgruppe",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 285,
            ansatz = "Außenfläche der 2. Rippe",
            innervation = "Plexus brachialis (C6–C8)",
            funktion = "Hebung der 2. Rippe, Lateralflexion der Halswirbelsäule",
            structure_id = 285
        });

        // Musculus scalenus posterior (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 286,
            latin_name = "Musculus scalenus posterior (sin.)",
            german_name = "Hinterer Treppenmuskel (li.) Variante L",
            category = "Skalenusgruppe",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 286,
            ansatz = "Außenfläche der 2. Rippe",
            innervation = "Plexus brachialis (C6–C8)",
            funktion = "Hebung der 2. Rippe, Lateralflexion der Halswirbelsäule",
            structure_id = 286
        });

        // Musculus sternocleidomastoideus (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 287,
            latin_name = "Musculus sternocleidomastoideus (dex.)",
            german_name = "Kopfwender (re.) Variante L",
            category = "Halsmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 287,
            ansatz = "Processus mastoideus und Linea nuchae superior",
            innervation = "Nervus accessorius (XI) und Plexus cervicalis",
            funktion = "Rotation des Kopfes zur Gegenseite, Lateralflexion zur gleichen Seite, Hebung des Sternums",
            structure_id = 287
        });

        // Musculus sternocleidomastoideus (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 288,
            latin_name = "Musculus sternocleidomastoideus (sin.)",
            german_name = "Kopfwender (li.) Variante L",
            category = "Halsmuskeln",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 288,
            ansatz = "Processus mastoideus und Linea nuchae superior",
            innervation = "Nervus accessorius (XI) und Plexus cervicalis",
            funktion = "Rotation des Kopfes zur Gegenseite, Lateralflexion zur gleichen Seite, Hebung des Sternums",
            structure_id = 288
        });

        // Musculus sternohyoideus (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 289,
            latin_name = "Musculus sternohyoideus (dex.)",
            german_name = "Brustbein-Zungenbein-Muskel (re.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 289,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Ansa cervicalis aus Plexus cervicalis (C1–C3)",
            funktion = "Senkung des Zungenbeins nach dem Schluckakt",
            structure_id = 289
        });

        // Musculus sternohyoideus (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 290,
            latin_name = "Musculus sternohyoideus (sin.)",
            german_name = "Brustbein-Zungenbein-Muskel (li.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 290,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Ansa cervicalis aus Plexus cervicalis (C1–C3)",
            funktion = "Senkung des Zungenbeins nach dem Schluckakt",
            structure_id = 290
        });

        // Musculus sternothyreoideus (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 291,
            latin_name = "Musculus sternothyreoideus (dex.)",
            german_name = "Brustbein-Schildknorpel-Muskel (re.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 291,
            ansatz = "Linea obliqua des Schildknorpels",
            innervation = "Ansa cervicalis aus Plexus cervicalis (C1–C3)",
            funktion = "Senkung des Kehlkopfs nach dem Schlucken",
            structure_id = 291
        });

        // Musculus sternothyreoideus (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 292,
            latin_name = "Musculus sternothyreoideus (sin.)",
            german_name = "Brustbein-Schildknorpel-Muskel (li.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 292,
            ansatz = "Linea obliqua des Schildknorpels",
            innervation = "Ansa cervicalis aus Plexus cervicalis (C1–C3)",
            funktion = "Senkung des Kehlkopfs nach dem Schlucken",
            structure_id = 292
        });

        // Musculus stylohyoideus (re.) Variante R2
        _connection.Insert(new AnatomicalStructures
        {
            id = 293,
            latin_name = "Musculus stylohyoideus (dex.)2",
            german_name = "Griffel-Zungenbein-Muskel (re.) Variante R2",
            category = "Suprahyoidale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 293,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Nervus facialis (VII)",
            funktion = "Hebung des Zungenbeins nach hinten beim Schlucken",
            structure_id = 293
        });

        // Musculus stylohyoideus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 294,
            latin_name = "Musculus stylohyoideus (sin.)",
            german_name = "Griffel-Zungenbein-Muskel (li.)",
            category = "Suprahyoidale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 294,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Nervus facialis (VII)",
            funktion = "Hebung des Zungenbeins nach hinten beim Schlucken",
            structure_id = 294
        });

        // Musculus thyreohyoideus (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 295,
            latin_name = "Musculus thyreohyoideus (dex.)",
            german_name = "Schildknorpel-Zungenbein-Muskel (re.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 295,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Radix descendens nervi hypoglossi (C1 über N. hypoglossus)",
            funktion = "Senkung des Zungenbeins oder Hebung des Kehlkopfs",
            structure_id = 295
        });

        // Musculus thyreohyoideus (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 296,
            latin_name = "Musculus thyreohyoideus (sin.)",
            german_name = "Schildknorpel-Zungenbein-Muskel (li.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 296,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Radix descendens nervi hypoglossi (C1 über N. hypoglossus)",
            funktion = "Senkung des Zungenbeins oder Hebung des Kehlkopfs",
            structure_id = 296
        });

        // Platysma (re.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 297,
            latin_name = "Platysma (dex.)",
            german_name = "Halshautmuskel (re.) Variante L",
            category = "Oberflächliche Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 297,
            ansatz = "Mandibula, Haut der unteren Gesichtshälfte",
            innervation = "Ramus colli des Nervus facialis (VII)",
            funktion = "Spannt die Haut des Halses, mimischer Ausdruck (Zorn, Furcht)",
            structure_id = 297
        });

        // Platysma (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 298,
            latin_name = "Platysma (sin.)",
            german_name = "Halshautmuskel (li.) Variante L",
            category = "Oberflächliche Halsmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 298,
            ansatz = "Mandibula, Haut der unteren Gesichtshälfte",
            innervation = "Ramus colli des Nervus facialis (VII)",
            funktion = "Spannt die Haut des Halses, mimischer Ausdruck (Zorn, Furcht)",
            structure_id = 298
        });

        // Venter inferior musculi omohyoidei (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 299,
            latin_name = "venter inferior musculi omohyoidei",
            german_name = "Unterer Bauch des Schulter-Zungenbein-Muskels (li.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 299,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Ansa cervicalis aus Plexus cervicalis (C1–C3)",
            funktion = "Senkung des Zungenbeins, Spannung der Halsfaszie",
            structure_id = 299
        });

        // Venter inferior musculi omohyoidei (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 300,
            latin_name = "venter inferior musculi omohyoidei",
            german_name = "Unterer Bauch des Schulter-Zungenbein-Muskels (li.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 300,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Ansa cervicalis aus Plexus cervicalis (C1–C3)",
            funktion = "Senkung des Zungenbeins, Spannung der Halsfaszie",
            structure_id = 300
        });

        // Venter superior musculi omohyoidei (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 301,
            latin_name = "venter superior musculi omohyoidei",
            german_name = "Oberer Bauch des Schulter-Zungenbein-Muskels (li.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 301,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Ansa cervicalis aus Plexus cervicalis (C1–C3)",
            funktion = "Senkung des Zungenbeins, Spannung der Halsfaszie",
            structure_id = 301
        });

        // Venter superior musculi omohyoidei (li.) Variante L
        _connection.Insert(new AnatomicalStructures
        {
            id = 302,
            latin_name = "venter superior musculi omohyoidei",
            german_name = "Oberer Bauch des Schulter-Zungenbein-Muskels (li.) Variante L",
            category = "Infrahyale Muskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 302,
            ansatz = "Corpus ossis hyoidei",
            innervation = "Ansa cervicalis aus Plexus cervicalis (C1–C3)",
            funktion = "Senkung des Zungenbeins, Spannung der Halsfaszie",
            structure_id = 302
        });

        // Musculus hyoglossus (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 303,
            latin_name = "Musculus hyoglossus (dex.)",
            german_name = "Zungenbein-Zungenmuskel (re.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 303,
            ansatz = "Zungenkörper (Seitenrand)",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Zieht die Zunge nach unten und hinten",
            structure_id = 303
        });

        // Musculus hyoglossus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 304,
            latin_name = "Musculus hyoglossus (sin.)",
            german_name = "Zungenbein-Zungenmuskel (li.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 304,
            ansatz = "Zungenkörper (Seitenrand)",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Zieht die Zunge nach unten und hinten",
            structure_id = 304
        });

        // Musculi intercostales interni (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 305,
            latin_name = "Musculi intercostales interni (dex.)",
            german_name = "Innere Zwischenrippenmuskeln (re.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 305,
            ansatz = "Oberrand der jeweils unteren Rippe",
            innervation = "Nervi intercostales I–XI",
            funktion = "Rippenverengung, beteiligt an der Exspiration",
            structure_id = 305
        });

        // Musculi intercostales interni (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 306,
            latin_name = "Musculi intercostales interni (sin.)",
            german_name = "Innere Zwischenrippenmuskeln (li.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 306,
            ansatz = "Oberrand der jeweils unteren Rippe",
            innervation = "Nervi intercostales I–XI",
            funktion = "Rippenverengung, beteiligt an der Exspiration",
            structure_id = 306
        });

        // Musculus pectoralis minor (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 307,
            latin_name = "Musculus pectoralis minor (dex.)",
            german_name = "Kleiner Brustmuskel (re.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 307,
            ansatz = "Processus coracoideus der Scapula",
            innervation = "Nervus pectoralis medialis und lateralis (C6–Th1)",
            funktion = "Zieht die Scapula nach vorne und unten, hebt die Rippen bei fixierter Scapula",
            structure_id = 307
        });

        // Musculus pectoralis minor (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 308,
            latin_name = "Musculus pectoralis minor (sin.)",
            german_name = "Kleiner Brustmuskel (li.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 308,
            ansatz = "Processus coracoideus der Scapula",
            innervation = "Nervus pectoralis medialis und lateralis (C6–Th1)",
            funktion = "Zieht die Scapula nach vorne und unten, hebt die Rippen bei fixierter Scapula",
            structure_id = 308
        });

        // Musculus serratus anterior (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 309,
            latin_name = "Musculus serratus anterior (dex.)",
            german_name = "Vorderer Sägemuskel (re.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 309,
            ansatz = "Angulus superior, Margo medialis und Angulus inferior der Scapula",
            innervation = "Nervus thoracicus longus (C5–C7)",
            funktion = "Zieht die Scapula nach lateral und rotiert sie nach außen; wichtig für Elevation des Arms",
            structure_id = 309
        });

        // Musculus serratus anterior (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 310,
            latin_name = "Musculus serratus anterior (sin.)",
            german_name = "Vorderer Sägemuskel (li.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 310,
            ansatz = "Angulus superior, Margo medialis und Angulus inferior der Scapula",
            innervation = "Nervus thoracicus longus (C5–C7)",
            funktion = "Zieht die Scapula nach lateral und rotiert sie nach außen; wichtig für Elevation des Arms",
            structure_id = 310
        });

        // Musculus subclavius (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 311,
            latin_name = "Musculus subclavius (sin.)",
            german_name = "Unterschlüsselbeinmuskel (li.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 311,
            ansatz = "Unterfläche der Clavicula",
            innervation = "Nervus subclavius (C5–C6)",
            funktion = "Fixiert und senkt die Clavicula, schützt Gefäße unterhalb",
            structure_id = 311
        });

        // Musculus subcostalis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 312,
            latin_name = "Musculus subcostalis (dex)",
            german_name = "Unterrippenmuskel (re.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 312,
            ansatz = "Innenfläche der übernächsten bis drittnächsten Rippe",
            innervation = "Nervi intercostales",
            funktion = "Unterstützt die Exspiration durch Senkung der Rippen",
            structure_id = 312
        });

        // Musculus subcostalis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 313,
            latin_name = "Musculus subcostalis (sin)",
            german_name = "Unterrippenmuskel (li.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 313,
            ansatz = "Innenfläche der übernächsten bis drittnächsten Rippe",
            innervation = "Nervi intercostales",
            funktion = "Unterstützt die Exspiration durch Senkung der Rippen",
            structure_id = 313
        });

        // Musculus transversus thoracis (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 314,
            latin_name = "Musculus transversus thoracis(dex.)",
            german_name = "Querbrustmuskel (re.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 314,
            ansatz = "Knorpel der Rippen 2–6",
            innervation = "Nervi intercostales (Th1–Th6)",
            funktion = "Unterstützt die Exspiration durch Senkung der Rippen",
            structure_id = 314
        });

        // Musculus transversus thoracis (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 315,
            latin_name = "Musculus transversus thoracis(sin.)",
            german_name = "Querbrustmuskel (li.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 315,
            ansatz = "Knorpel der Rippen 2–6",
            innervation = "Nervi intercostales (Th1–Th6)",
            funktion = "Unterstützt die Exspiration durch Senkung der Rippen",
            structure_id = 315
        });

        // Musculi longitudinales (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 316,
            latin_name = "Musculi longitudinales (dex.)",
            german_name = "Längsmuskeln der Zunge (re.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 316,
            ansatz = "Verläuft längs durch die Zunge",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Verkürzt die Zunge und hebt/spitzt die Zungenspitze",
            structure_id = 316
        });

        // Musculi longitudinales (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 317,
            latin_name = "Musculi longitudinales (sin.) ",
            german_name = "Längsmuskeln der Zunge (li.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 317,
            ansatz = "Verläuft längs durch die Zunge",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Verkürzt die Zunge und hebt/spitzt die Zungenspitze",
            structure_id = 317
        });

        // Musculus chondroglossus (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 318,
            latin_name = "Musculus chondroglossus (dex.)",
            german_name = "Knorpel-Zungen-Muskel (re.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 318,
            ansatz = "Seitlich am Zungenkörper",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Unterstützt die Bewegung der Zunge nach unten und hinten",
            structure_id = 318
        });

        // Musculus chondroglossus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 319,
            latin_name = "Musculus chondroglossus (sin.)",
            german_name = "Knorpel-Zungen-Muskel (li.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 319,
            ansatz = "Seitlich am Zungenkörper",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Unterstützt die Bewegung der Zunge nach unten und hinten",
            structure_id = 319
        });

        // Musculus genioglossus (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 320,
            latin_name = "Musculus genioglossus (dex.)",
            german_name = "Kinn-Zungen-Muskel (re.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 320,
            ansatz = "Zungenkörper und Zungenbasis",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Zieht die Zunge nach vorne und unten",
            structure_id = 320
        });

        // Musculus pectoralis minor (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 321,
            latin_name = "Musculus pectoralis minor  (dex.)",
            german_name = "Kleiner Brustmuskel (re.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 321,
            ansatz = "Proc. coracoideus der Scapula",
            innervation = "Nervus pectoralis medialis",
            funktion = "Zieht die Scapula nach kaudal und ventral",
            structure_id = 321
        });

        // Musculus pectoralis minor (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 322,
            latin_name = "Musculus pectoralis minor  (sin.)",
            german_name = "Kleiner Brustmuskel (li.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 322,
            ansatz = "Proc. coracoideus der Scapula",
            innervation = "Nervus pectoralis medialis",
            funktion = "Zieht die Scapula nach kaudal und ventral",
            structure_id = 322
        });

        // Musculus subclavius (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 323,
            latin_name = "Musculus subclavius (dex.)",
            german_name = "Unterschlüsselbeinmuskel (re.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 323,
            ansatz = "Unterfläche der Clavicula",
            innervation = "Nervus subclavius",
            funktion = "Fixiert die Clavicula am Sternum, senkt die Schulter",
            structure_id = 323
        });

        // Musculus genioglossus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 324,
            latin_name = "Musculus genioglossus (sin.)",
            german_name = "Kinn-Zungen-Muskel (li.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 324,
            ansatz = "Zungenkörper und Zungenbasis",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Zieht die Zunge nach vorne und unten",
            structure_id = 324
        });

        // Musculus palatoglossus (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 325,
            latin_name = "Musculus palatoglossus (dex.)",
            german_name = "Gaumenzungenmuskel (re.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 325,
            ansatz = "Zungenrücken",
            innervation = "Plexus pharyngeus (N. vagus und N. glossopharyngeus)",
            funktion = "Hebt den Zungengrund, senkt den weichen Gaumen",
            structure_id = 325
        });

        // Musculus palatoglossus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 326,
            latin_name = "Musculus palatoglossus (sin.)",
            german_name = "Gaumenzungenmuskel (li.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 326,
            ansatz = "Zungenrücken",
            innervation = "Plexus pharyngeus (N. vagus und N. glossopharyngeus)",
            funktion = "Hebt den Zungengrund, senkt den weichen Gaumen",
            structure_id = 326
        });

        // Musculus styloglossus (re.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 327,
            latin_name = "Musculus styloglossus (dex.)",
            german_name = "Griffelzungenmuskel (re.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 327,
            ansatz = "Seitenrand der Zunge",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Zieht die Zunge nach hinten und oben",
            structure_id = 327
        });

        // Musculus styloglossus (li.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 328,
            latin_name = "Musculus styloglossus (sin.)",
            german_name = "Griffelzungenmuskel (li.)",
            category = "Zungenmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 328,
            ansatz = "Seitenrand der Zunge",
            innervation = "Nervus hypoglossus (XII)",
            funktion = "Zieht die Zunge nach hinten und oben",
            structure_id = 328
        });
        
        // Torax_Musculus pectoralis minor (dex.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 334,
            latin_name = "Musculus pectoralis minor (dex.)",
            german_name = "Kleiner Brustmuskel (re.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 334,
            ansatz = "Proc. coracoideus der Scapula",
            innervation = "Nervus pectoralis medialis",
            funktion = "Zieht die Scapula nach kaudal und ventral",
            structure_id = 334
        });

        // Torax_Musculus pectoralis minor (sin.)
        _connection.Insert(new AnatomicalStructures
        {
            id = 335,
            latin_name = "Musculus pectoralis minor (sin.)",
            german_name = "Kleiner Brustmuskel (li.)",
            category = "Thoraxmuskulatur",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 335,
            ansatz = "Proc. coracoideus der Scapula",
            innervation = "Nervus pectoralis medialis",
            funktion = "Zieht die Scapula nach kaudal und ventral",
            structure_id = 335
        });
        
        
        
        //Skeleton entry to avoid error
        _connection.Insert(new AnatomicalStructures
        {
            id = 9999,
            latin_name = "Skeleton_m_V7",
            german_name = "Skeleton_m_V7",
            category = "Platzhalter",
            parentId = 0
        });
        _connection.Insert(new Descriptions
        {
            id = 9999,
            ansatz = "",
            innervation = "",
            funktion = "",
            structure_id = 9999
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
	public IEnumerable<Descriptions> GetDescriptions(){
		return _connection.Table<Descriptions>();
	}

}
