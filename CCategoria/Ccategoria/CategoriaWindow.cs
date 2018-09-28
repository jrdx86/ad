using System;
using System.Data;

using Serpis.Ad;

namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
        public CategoriaWindow() : base(Gtk.WindowType.Toplevel)
        {
            this.Build();


            buttonSave.Clicked += delegate {
                IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
                dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";

				DbCommandHelper.AddParameter(dbCommand, "nombre", entryNombre.Text);
                IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                

                int filas = dbCommand.ExecuteNonQuery();

                Console.WriteLine("Nombre=" + entryNombre.Text);
            };

        }

    }
}