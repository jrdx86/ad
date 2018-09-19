
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace CMySql
{
    class MainClass
    {
		private static string[] getFieldNames(IDataReader dataReader){
			int fieldCount = dataReader.FieldCount;
			//         string[] fieldNames = new string[fieldCount];

			//for (int index = 0; index < fieldCount; index++){
			//	fieldNames[index] = dataReader.GetName(index);
			//             }
			//return fieldNames;
			List<string> fieldNameList = new List<string>();
			for (int index = 0; index < fieldCount; index++){
				fieldNameList.Add(dataReader.GetName(index));
			}
			return fieldNameList.ToArray();
        }
        public static void Main(string[] args)
        {
            IDbConnection dbConnection = new MySqlConnection(
                "server=localhost;" +
                "database=dbprueba;" +
                "user=root;" +
                "password=sistemas;" +
                "ssl-mode=none;"
            );
            dbConnection.Open();
            
			IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "select * from categoria order by id";
            IDataReader dataReader = dbCommand.ExecuteReader();
            Console.WriteLine("Numero de columnas= " + dataReader.FieldCount);

            for (int index = 0; index < dataReader.FieldCount; index++)
            {
                Console.WriteLine("Columna {0} = {1}", index, dataReader.GetName(index));
            //            Console.Write(getFieldNames(dataReader)[index]+" ");
            }
                        Console.WriteLine();
                        while(dataReader.Read()){
                            Console.WriteLine("id={0} nombre={1}", dataReader["id"], dataReader["nombre"]);
                       }
            dataReader.Close();

            dbConnection.Close();
        }
    }
}