using SQLite4Unity3d;

public class Descriptions  {

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string ansatz { get; set; }
    public string innervation { get; set; }
    public string funktion { get; set; }
    public int structure_id { get; set; }

	public override string ToString ()
	{
		return string.Format ("[Descriptions: id={0}, ansatz={1}, innervation={2}, funktion={3}, structure_id={4}]", id, ansatz, innervation, funktion, structure_id);
	}
}