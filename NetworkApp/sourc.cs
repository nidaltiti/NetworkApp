using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using System.ComponentModel;
using CoreGraphics;
using Mono.Data.Sqlite;
using CoreGraphics;
using System.Collections.Generic;
using Network_App;
using NetworkApp;

namespace Network_App
{
   
}
public class sourc : UITableViewSource

{
    LibraryWords library = new LibraryWords();
    DataSql dataSql = new DataSql();
    string CellIdentifier;
    UITableView tableView;

    List<string> cellList = new List<string>();
    List<int> PortList = new List<int>();
    public sourc(List<string> list, List<int> PL, UITableView table) {



         CellIdentifier = library.StrForm(0);

        cellList = list; tableView = table;


        PortList = PL;


    }




    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
        UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
        string item = cellList[indexPath.Row];
        if (cell == null) { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }
        cell.TextLabel.Text = item;
        return cell;
    }




    public override nint RowsInSection(UITableView tableview, nint section)
    {
        return cellList.Count;
    }
    public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
    {
        var conncatbutton = UITableViewRowAction.Create(UITableViewRowActionStyle.Default,library.StrForm(1), click_connact);

        var deletebutton = UITableViewRowAction.Create(UITableViewRowActionStyle.Default, library.StrForm(2), click_delete);

        conncatbutton.BackgroundColor = UIColor.Blue;
        deletebutton.BackgroundColor = UIColor.Red;
        return new UITableViewRowAction[] { conncatbutton, deletebutton };

    }
    public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
    {
        return true; // return false if you wish to disable editing for a specific indexPath or for all rows
    }

    private void click_connact(UITableViewRowAction row, NSIndexPath indexPath) // Action  Connect button
    {
        Connect connect = new Connect("",9);


    }

    private void click_delete(UITableViewRowAction row, NSIndexPath indexPath) //Action Delete button
    {

      

        dataSql.process(library.File(2), library.DELETE(0), DataSql_Parameters(cellList[indexPath.Row]));
        PortList.RemoveAt(indexPath.Row);

        cellList.RemoveAt(indexPath.Row);
       

        //            // delete the row from the table
        tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
        //  tableView.DeleteRows(new[] { indexPath[0] }, UITableViewRowAnimation.Fade);
        //  tableView.DeleteRows(new NSIndexPath[] { NSIndexPath.FromItemSection(0, 0) }, UITableViewRowAnimation.Fade);

        

    }

    private SqliteParameterCollection DataSql_Parameters(string String)
    {
        SqliteCommand SqliteCommand = new SqliteCommand();
        SqliteParameterCollection ReturnParamter = SqliteCommand.Parameters;

        ReturnParamter.AddWithValue(LibraryWords.Row, String);

     //   ReturnParamter.AddWithValue("@port", field2.Text);


        return ReturnParamter;

    }

}
