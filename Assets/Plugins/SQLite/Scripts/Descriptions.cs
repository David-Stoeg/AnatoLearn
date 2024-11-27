using SQLite4Unity3d;

public class Descriptions  {

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string text { get; set; }
	public int structure_id { get; set; }

	public override string ToString ()
	{
		return string.Format ("[Descriptions: id={0}, text={1}, structure_id{2}]", id, text, structure_id);
	}
}