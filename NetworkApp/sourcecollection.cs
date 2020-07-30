using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.Collections.Generic;
using NetworkApp;

namespace Network_App
{
    class sourcecollection: UICollectionViewSource

    {
        public  static List<CollectionViewCell1> _collectionViewCell = new List<CollectionViewCell1>();
        List<iEbutton> row { set; get; }
        public sourcecollection(List<iEbutton> _row) {

           // row.Clear();

            row = _row; }
       

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            // Return the number of items
            return row.Count;
        }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (CollectionViewCell1)collectionView.DequeueReusableCell(CollectionViewCell1.Key, indexPath);

            // row[indexPath.Row].Frame(0,0,90);


            cell.set(indexPath.Row); 
           
                
                _collectionViewCell.Add(cell);
                return cell;
        
        }


        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            int i = 0;
            //var ui = UIAlertController.Create(i.ToString(), "", UIAlertControllerStyle.Alert);
            //Images.imG.PresentViewController(ui, true, null);



        }
        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.CellForItem(indexPath);
            cell.ContentView.BackgroundColor = UIColor.Yellow;
        }

        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.CellForItem(indexPath);
            cell.ContentView.BackgroundColor = UIColor.White;
        }

    }
}