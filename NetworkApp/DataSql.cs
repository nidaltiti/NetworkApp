using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace Network_App
{
    class DataSql
    {
        public string lop = "string";
           LibraryWords WLibrary = new LibraryWords();
        SqliteParameterCollection Parameters;
        string docFolder, libFolder, dbPath;
        SqliteConnection _dbConnection;
        SqliteCommand command;
        IDbCommand commandreader;
    public static    List<string> data = new List<string>();
        public static List<byte[]> databyet= new List<byte[]> ();
        public static  IDataReader reader;
         int row = 0;
    
        public void fileSql(string filename)
        {
            pathName(filename);
           // string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
           // string libFolder = Path.Combine(docFolder, WLibrary.listWords(0), WLibrary.listWords(1), WLibrary.listWords(2));

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            // dbPath = Path.Combine(libFolder, filename);

            if (!File.Exists(dbPath))
            {
                var existingDb = NSBundle.MainBundle.PathForResource(WLibrary.File(0), WLibrary.File(1));
                File.Copy(existingDb, dbPath);

            }
        }
      


      //++++++++++++++++++++++++++++++
        public void  Rowdata(int i) { row = i; }
        public void process(string filename, string sql, SqliteParameterCollection sqlpram) {
          
                Parameters = sqlpram;

                pathName(filename);
                db_conntion(null);
                commandstring(sql);
                close();
           
        
              
         

        }
        private void pathName(string filename)
        {
            docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            libFolder = Path.Combine(docFolder, WLibrary.listWords(0), WLibrary.listWords(1), WLibrary.listWords(2));

            dbPath = Path.Combine(libFolder, filename);

        }
        private void db_conntion(SqliteConnection cnn)
        {
            _dbConnection = cnn;

            try
            {
                _dbConnection =
    new SqliteConnection(WLibrary.listWords(3) + dbPath + WLibrary.listWords(4));


                _dbConnection.Open();

            }
            catch
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();

                    _dbConnection.Dispose();
                    command.Dispose();
                    _dbConnection = null;
                    command = null;
                    db_conntion(null);

                }
            }
        }
        private void commandstring(string sql)
        {

            command = new SqliteCommand(_dbConnection);
          

           // commade Selectcomand = new commade();
            int Selectcomand = WLibrary.sqlAccess(sql);


            
            switch (Selectcomand)
            {
                case 1: { SELECT(sql); } break;
                case 2: { INSERT(sql); } break;

                case 3: {

                        if (Parameters != null)
                        {
                            DELETE(sql);
                        }

                        else { DeleteAll(sql); }


                    } break;
            }



            // if (sql.Contains(GetEnumDescription(commade.INSERT))) { }


        }
       

        //public static string GetEnumDescription(Enum value)

        //{

        //    var enumType = value.GetType();

        //    var field = enumType.GetField(value.ToString());

        //    var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        //    return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;


        //    // list enum  
        //}
        private void INSERT(string sql) {




            command.CommandText = sql;



            foreach (SqliteParameter paramter in Parameters)
                command.Parameters.Add(paramter);
            command.ExecuteNonQuery();

        }
        private void SELECT(string sql) {
            commandreader = _dbConnection.CreateCommand();

            commandreader.CommandText = sql;
            reader = commandreader.ExecuteReader();



            loop();



        } 

        public  List<string > GetData() {


           


          


            return data;
        }


        private void loop()
        {


            if (lop == "string")
            {
                data.Clear();

                while (reader.Read())
                {
                    //
                    data.Add(reader.GetString(row));
                    //  string lastName = reader.GetString(1);


                }

            }
            else
            {
                while (reader.Read())
                {
                    byte[] b = null;
                    b = (byte[])reader.GetValue(row);

                    databyet.Add(b); }
            }
        }
        private void DELETE(string sql)
        {
            command.CommandText = sql;

          

                foreach (SqliteParameter paramter in Parameters)
                    command.Parameters.Add(paramter);

                int rows = command.ExecuteNonQuery();
                      
           

        }
        private void DeleteAll(string sql)
        {
            command.CommandText = sql;

            command.ExecuteNonQuery();
        }
        public void close() {


            if(_dbConnection.State == ConnectionState.Open){
                _dbConnection.Close();

                _dbConnection.Dispose();
                command.Dispose();
                _dbConnection = null;
                command = null;

            }


        }
        
    }
}
    
