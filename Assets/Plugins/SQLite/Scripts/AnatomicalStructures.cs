using SQLite4Unity3d;

public class AnatomicalStructures  {

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string german_name { get; set; }
	public string latin_name { get; set; }
	public int category { get; set; }

	public override string ToString ()
	{
		return string.Format ("[AnatomicalStructures: id={0}, german_name={1},  latin_name={2}, category{3}]", id, german_name, latin_name, category);
	}
}