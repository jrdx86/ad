using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using CCategoria;

using System.Reflection;

public partial class MainWindow : Gtk.Window
{


	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		IDbConnection dbConnection = new MySqlConnection(
			   "server=localhost;" +
			   "database=dbprueba;" +
			   "user=root;" +
			   "password=sistemas;" +
			   "ssl-mode=none;"
		   );

		dbConnection.Open();



		//treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
		//treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);

		CellRendererText cellRendererText = new CellRendererText();
		//treeView.AppendColumn(
		//	"ID",
		//	cellRendererText,
		//	delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter){
		//	 //   Categoria categoria = (Categoria) tree_model.GetValue(iter,0);
		//		//cellRendererText.Text = categoria.Id + "";
		//	    object model = tree_model.GetValue(iter, 0);
  //              object value = model.GetType().GetProperty("Id").GetValue(model);
  //              cellRendererText.Text = value + "";
		//	}
		//);

		//treeView.AppendColumn(
    //        "Nombre",
    //        cellRendererText,
    //        delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
				////   Categoria categoria = (Categoria) tree_model.GetValue(iter, 0);
				////cellRendererText.Text = categoria.Nombre + "";
			    //object model = tree_model.GetValue(iter, 0);
        //        object value = model.GetType().GetProperty("Nombre").GetValue(model);
        //        cellRendererText.Text = value + "";

        //    }
        //);





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

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
