using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Đặt hàng")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Tensp")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DATHANG : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DATHANG(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private int _soluong;
        [XafDisplayName("Số lượng"), Size(int.MaxValue)]
        public int Soluong
        {
            get { return _soluong; }
            set { SetPropertyValue<int>(nameof(Soluong), ref _soluong, value); }
        }


        private SANPHAM _sanpham;
        [XafDisplayName("Sản phẩm"), Size(255)]
        [Association]
        public SANPHAM Sanpham
        {
            get { return _sanpham; }
            set { SetPropertyValue<SANPHAM>(nameof(Sanpham), ref _sanpham, value); }
        }

        private HOADON _hoadon;
        [XafDisplayName("Hóa đơn"), Size(255)]
        [Association]
        public HOADON Hoadon
        {
            get { return _hoadon; }
            set { SetPropertyValue<HOADON>(nameof(Hoadon), ref _hoadon, value); }
        }


        [XafDisplayName("Thành tiền"), Size(255)]
        public decimal Thanhtien
        {
            get
            {
                if (Soluong != null && Sanpham != null && Sanpham.Gia != null)
                {
                    return (decimal)Soluong * Sanpham.Gia;
                }
                else
                {
                 
                    return 0; 
                }
            }
        }

    }
}