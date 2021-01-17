using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Network_App
{
    class LibraryWords
    {
        string[] file = { "ip", "db3", "ip.db3" };
        string[] strWord = { "..", "Library", "Databases", "Data Source=", ";Version=3;", };
        string[] strForm = { " TableCell", "Conncat", "Delete", " Okay", "Cancel" };

        string[] tabs = { " Addrisses", "Images","settings" };

        string[] extension = { ".jpg", ".png", ".mp4", ".avi" };
        public static string Row = "@column";
        public static string GetEnumDescription(Enum value)

        {

            var enumType = value.GetType();

            var field = enumType.GetField(value.ToString());

            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;


            // list enum  
        }
        public enum SqlCommand
        {
            [Description("INSERT INTO ip(dns, port) VALUES(@dns, @port)")]

            INSERT,


            [Description("SELECT dns, port " + "FROM ip")]

            SELECT,




            [Description(" DELETE FROM ip " + "WHERE dns=@dns")]
            DELETE


        }; //list enum  
        public int sqlAccess(string str)
        {
            int i = 0;
            if (str.Contains("SELECT")) { i = 1; }
            if (str.Contains("INSERT")) { i = 2; }

            if (str.Contains("DELETE")) { i = 3; }
            if (str.Contains("UPDATE")) { i = 4; }
            return i;


        }



        //public enum File
        //{
        //    [Description("ip")]
        //    Ip,


        //};
        public string Extension(string sreach) {
            string ret = string.Empty;
            for (int i = 0; i < extension.Count(); i++) {
                if (
                    sreach.Contains(extension[i])) {
                    ret = extension[i];




                } }

            return ret;



        }
        public string listWords(int row) { return strWord[row]; }


        public string File(int row)
        {

            return file[row];
        }

        public string Tabs(int i) { return tabs[i]; }
        public string StrForm(int i) { return strForm[i]; }
        public string DELETE(int number) {



            string ret = string.Empty;


            if (number==0) {



                ret= GetEnumDescription(choce.DELETE) + " " + GetEnumDescription(table_ip.Table) + " " + GetEnumDescription(choce.WHERE) + " " + GetEnumDescription(table_ip.dns) + "=" + Row; }



            if (number == 1)
            {



                ret = GetEnumDescription(choce.DELETE) + " " + GetEnumDescription(table_imagedata.Table) + " " + GetEnumDescription(choce.WHERE) + " " + GetEnumDescription(table_imagedata.Titile) + "="+" "+ Row;
            }


            return ret;

        }
        
    


        public string SELECT(int i) {
            string column=string.Empty ;
           // string reslt;
            string ret=string.Empty;
            if (i == 0)
            {
                 column = " " + " " + GetEnumDescription(table_ip.dns) + "," + " " + GetEnumDescription(table_ip.port) + " ";
               
                   ret= GetEnumDescription(choce.SELECT) + column + " " + GetEnumDescription(choce.FROM) + " " + GetEnumDescription(table_ip.Table);
            }
            
            if (i == 1)
            {
                column = " " + " " + GetEnumDescription(table_imagedata.Titile) + "," + " " + GetEnumDescription(table_imagedata.Image) + "," + " " + GetEnumDescription(table_imagedata.Thumbnail) + "," + " "+     GetEnumDescription(table_imagedata.Extension) + " ";

                ret = GetEnumDescription(choce.SELECT) + column + " " + GetEnumDescription(choce.FROM) + " " + GetEnumDescription(table_imagedata.Table);
            }
            return ret;



           //     ("SELECT dns, port " + "FROM ip")
        }

        public string INSERT(int i) {
            string ret = string.Empty;
            if (i == 1)
            {
                string column = " " + "(" + " " + GetEnumDescription(table_ip.dns) + "," + " " + GetEnumDescription(table_ip.port) + " " + ")";

                string rows = " " + "(" + " " + Row + 0.ToString() + " " + "," + " " + Row + 1.ToString() + " " + ")";

                ret = GetEnumDescription(choce.INSERT) + " " + GetEnumDescription(table_ip.Table) + column + GetEnumDescription(choce.VALUES) + rows;
            }


            else {

                //change
                string column = " " + "(" + " " + GetEnumDescription(table_imagedata.Titile) + "," + " " + GetEnumDescription(table_imagedata.Image) + "," + " " + " " + GetEnumDescription(table_imagedata.Thumbnail) + "," + " " + GetEnumDescription(table_imagedata.Extension) + " " + ")";

                string rows = " " + "(" + " " + Row + 0.ToString() + " " + "," + " " + Row + 1.ToString() + " " + "," + " " + Row + 2.ToString() + " " + "," + " " + Row + 3.ToString() + " " + ")";

                ret = GetEnumDescription(choce.INSERT) + " " + GetEnumDescription(table_imagedata.Table) + column + GetEnumDescription(choce.VALUES) + rows;





            }



            return ret;




        }
      
        
        
        
        
        
        
        // " DELETE FROM ip  WHERE dns = @column"
        //  "INSERT INTO ip(dns, port) VALUES(@dns, @port)"

        public enum choce
        {
            [Description("INSERT INTO")]

            INSERT,


            [Description("SELECT")]

            SELECT,




            [Description(" DELETE FROM ")]

            DELETE,



            [Description("WHERE")]
            WHERE,
            [Description("VALUES")]
            VALUES,


            [Description("FROM")]
            FROM,
                 [Description("TRUNCATE TABLE ")]
            DELETEAll,
            [Description("UPDATE")]
            UPDATE,
            [Description("set")]

            Set,

        }; //list enum  



        public enum table_ip {
            [Description("ip")]
            Table,
            [Description("dns")]
            dns,


            [Description("port")]
            port,

        };


        public enum table_imagedata
        {
            [Description("imagedata")]
            Table,
            [Description("Titile")]
            Titile,


            [Description("Image")]
            Image,
            [Description("Thumbnail")]
            Thumbnail,


            [Description("Extension")]
            Extension,



        };



        public String detleteAll()
        {
            string ret = string.Empty;

            



                //ret = GetEnumDescription(choce.DELETE) + " " + GetEnumDescription(table_imagedata.Table);
           
            ret= " DELETE FROM  imagedata ";

            return ret;


        }



        public String Upload()
        {
            string ret = string.Empty;





            //ret = GetEnumDescription(choce.DELETE) + " " + GetEnumDescription(table_imagedata.Table);

            ret = GetEnumDescription(choce.UPDATE) + " " + GetEnumDescription(table_imagedata.Table) + " " + GetEnumDescription(choce.Set) + " " + GetEnumDescription(table_imagedata.Titile) + "=" + " " + Row + " " + GetEnumDescription(choce.WHERE) + " " + GetEnumDescription(table_imagedata.Titile) + "=" + " " + Row+1.ToString() ;

            return ret;


        }


    }
}