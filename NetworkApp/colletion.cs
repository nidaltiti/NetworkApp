using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
namespace Network_App
{
    public  class colletion : UICollectionViewSource
    {
       
        list<UIButton> row = new list<UIButton>();
        public void geitem(list<UIButton> ie) { row = ie;  row.  }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            return null;
        }
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            

            return  
        }
    }
}