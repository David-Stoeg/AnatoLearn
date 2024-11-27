using SQLite4Unity3d;

public class Relations {

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string relation_type { get; set; }
	public int structure1_id { get; set; }
    public int structure2_id { get; set; }

	public override string ToString ()
	{
		return string.Format ("[Relations: id={0}, relation_type={1}, structure1_id{2}, structure2_id{3}]", id, relation_type, structure1_id, structure2_id);
	}
}