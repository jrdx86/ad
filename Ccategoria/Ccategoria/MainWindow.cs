using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using CCategoria;

using System.Reflection;

public partial class MainWindow : Gtk.Window
{

	private IDbConnection dbConnection;
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		dbConnection = new MySqlConnection(
			   "server=localhost;" +
			   "database=dbprueba;" +
			   "user=root;" +
			   "password=sistemas;" +
			   "ssl-mode=none;"
		   );
        
		dbConnection.Open();

		//update();
		//delete();
		update(new Categoria(3,"categoria 3 "+DateTime.Now));

		CellRendererText cellRendererText = new CellRendererText();


		//treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
		//treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);

		String[] properties = new string[] { "Id", "Nombre" };

        foreach (string property in properties)
        {
            string propertyName = property;
            treeView.AppendColumn(
                property,
                cellRendererText,
                delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
                    //Categoria categoria = (Categoria)tree_model.GetValue(iter, 0);
                    //cellRendererText.Text = categoria.Id + "";
                    object model = tree_model.GetValue(iter, 0);
                    object value = model.GetType().GetProperty(property).GetValue(model);
                    cellRendererText.Text = value + "";
                }
            );
        }
	



		//ListStore listStore = new ListStore(typeof(ulong), typeof(string));
		//ListStore listStore = new ListStore(typeof(string), typeof(string));
		ListStore listStore = new ListStore(typeof(Categoria));
		    treeView.Model = listStore;
        
		IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "select id, nombre from categoria order by id";
        IDataReader dataReader = dbCommand.ExecuteReader();


		//listStore.AppendValues("1", "categoria 1");
		//listStore.AppendValues("2", "categoria 2");



		while (dataReader.Read())

			listStore.AppendValues(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
			//listStore.AppendValues(dataReader["id"] + "", dataReader["nombre"] + "");//"" hace funcion de Tostring()
		
		dataReader.Close();

		dbConnection.Close();
			        
    }

	private void insert()
    {
        IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "insert categoria (nombre) values ('categoria 4')";
        dbCommand.ExecuteNonQuery();
    }

	private void update()
	{
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "update categoria set nombre ='categoria 4 modificada' where id = 4";
		dbCommand.ExecuteNonQuery();
	}

	private void update(Categoria categoria)
    {
        IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "update categoria set nombre =@nombre where id =@id";

		IDbDataParameter dbDataparameterNombre = dbCommand.CreateParameter();
		dbDataparameterNombre.ParameterName = "nombre";
		dbDataparameterNombre.Value = categoria.Nombre;
		dbCommand.Parameters.Add(dbDataparameterNombre);

		IDbDataParameter dbDataparameterId = dbCommand.CreateParameter();
        dbDataparameterId.ParameterName = "id";
		dbDataparameterId.Value = categoria.Id;
		dbCommand.Parameters.Add(dbDataparameterId);
        dbCommand.ExecuteNonQuery();

		dbCommand.ExecuteNonQuery();

    }

	private void delete()
    {
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "delete from categoria where id = 4";


        dbCommand.ExecuteNonQuery();
    }


    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
