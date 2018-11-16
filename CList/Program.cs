using System;
using System.Collections.Generic;



namespace CList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			List<string> propertyNames = new List<string> (new string[]{ "id", "Nombre", "Precio", "Categoria" });

			List<string> fieldsWithoutId = new List<string>();
            List<string> parameters = new List<string>();
			List<string> fieldsParametersPairs = new List<string>();


			for (int index = 1; index < propertyNames.Count; index++)
            {
                fieldsWithoutId.Add(propertyNames[index]);
                parameters.Add("@" + propertyNames[index]);

            }

			for (int index = 1; index < propertyNames.Count; index++){
				string item = propertyNames[index];
				fieldsParametersPairs.Add(item + "=@" + item);
			}

                     
			//string[] propertynames = new string[] { "id", "Nombre", "Precio", "Categoria" };
            
			//List<string> fieldsWithoutId = new List<string>(propertyNames);
			//fieldsWithoutId.RemoveAt(0);

			//List<string> fieldsWithoutId = propertyNames.GetRange(1, propertyNames.Count - 1);


			//List<string> fieldsWithoutId = new List<string>();
			//foreach(string item in propertyNames){
			//	if (item != "id")
			//		//construye parametros "@"
			//		fieldsWithoutId.Add("@"+item);
			//}
			//for (int index = 1; index < propertyNames.Count; index++)
			//fieldsWithoutId.Add(propertyNames[index]);

			//List<string> fieldsWithoutId = propertyNames.FindAll(item => item !="id");
			//fieldsWithoutId.ForEach(item => parameters.Add("@" + item) );  
         
            
			string fieldNamesCsv = string.Join(",", propertyNames).ToLower();
			Console.WriteLine("FieldNamesCsv= " + fieldNamesCsv);

			string parametersCsv = string.Join(",", parameters).ToLower();
            Console.WriteLine("Parameters= " + parametersCsv);

			string fieldsParametersPairsCsV = string.Join(",", fieldsParametersPairs).ToLower();
			Console.WriteLine("fieldParameterPairs=" + fieldsParametersPairsCsV);




        }
    }
}
