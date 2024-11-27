using SQLite4Unity3d;

public class Models_3D {

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string model_path { get; set; }
	public string highlight_color { get; set; }
	public int structure_id { get; set; }

	public override string ToString ()
	{
		return string.Format ("[3D_Models: id={0}, model_path={1},  highlight_color={2}, structure_id={3}]", id, model_path, highlight_color, structure_id);
	}
}
