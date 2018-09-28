﻿using System;
using System.Data;
using System.Collections.Generic;
using Serpis.Ad;

namespace CCategoria
{
    public class CategoriaDao
    {
		private static string selectAll = "select id, nombre from categoria order by id";
		public static IList<Categoria> Categorias{
			get {
				List<Categoria> categorias = new List<Categoria>();
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
                dbCommand.CommandText = "select id, nombre from categoria order by id";
                IDataReader dataReader = dbCommand.ExecuteReader();
                while (dataReader.Read())
					categorias.Add(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
                dataReader.Close();
			}
        }
    }
}
