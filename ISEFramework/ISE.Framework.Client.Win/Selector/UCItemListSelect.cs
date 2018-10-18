using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISE.UILibrary;

namespace ISE.Framework.Client.Win.Selector
{
    public partial class UCItemListSelect<T> : IUserControl where T:class
    {
        BindingSource bs = new BindingSource();
        BindingList<T> bindingList;
        public List<T> SelectedItems { get; set; }
        public List<T> DataItems { get; set; }
        public bool HasSelected { get; private set; }
        List<ColumnDescriptor> columnDescriptors = new List<ColumnDescriptor>();
        bool selectMode = true;
        public UCItemListSelect(List<T> itemList,bool multipleSelector=false,bool selectMode=true)
        {
            InitializeComponent();
            HasSelected = false;
            MultipleSelector = multipleSelector;
            SetGrid();
            bindingList = new BindingList<T>(itemList);
            DataItems = itemList;
            bindingList.AllowNew = false;
            bindingList.AllowEdit = false;
            bindingList.AllowRemove = false;
            bs.DataSource = bindingList;
            
            this.iGridEX1.DataSource = bs;
            SelectedItems = new List<T>();
            this.selectMode = selectMode;
            SetUI();
        }

        private void SetUI()
        {
            if (!selectMode)
            {
                btnSelect.Enabled = false;                
            }
        }
       
      
        private bool MultipleSelector
        {
            get;
            set;
        }
        private void SetGrid()
        {           
          
            this.iGridEX1.RootTable = new Janus.Windows.GridEX.GridEXTable();
            this.iGridEX1.RootTable.UseGroupRowSelector = Janus.Windows.GridEX.InheritableBoolean.True;
            this.iGridEX1.RowDoubleClick += iGridEX1_RowDoubleClick;
            
            
            if (MultipleSelector)
            {
                this.iGridEX1.RootTable.Columns.Add("Selector").Caption = "انتخاب";
                this.iGridEX1.RootTable.Columns["Selector"].ActAsSelector = true;
                this.iGridEX1.RootTable.Columns["Selector"].ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox;
                this.iGridEX1.RootTable.Columns["Selector"].EditType = Janus.Windows.GridEX.EditType.CheckBox;
                this.iGridEX1.RootTable.Columns["Selector"].AllowDrag = false;
                this.iGridEX1.RootTable.Columns["Selector"].UseHeaderSelector = true;
                this.iGridEX1.RootTable.Columns["Selector"].Width = 30;
            }
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEX1);
            
        }

        void iGridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if(!MultipleSelector)
            {
                SelectSingle();   
            }            
        }       
        public void AddColumnDescriptor(List<ColumnDescriptor> columnDescriptorList)
        {
            columnDescriptors.AddRange(columnDescriptorList);
            foreach (var columnDescriptor in columnDescriptors)
            {
                this.iGridEX1.RootTable.Columns.Add(columnDescriptor.Name).Caption = columnDescriptor.Caption;
                this.iGridEX1.RootTable.Columns[columnDescriptor.Name].FormatString = columnDescriptor.Format;
                if (columnDescriptor.Width > 0)
                {
                    this.iGridEX1.RootTable.Columns[columnDescriptor.Name].Width = columnDescriptor.Width;
                    
                }
                
            }
        }
        public void AddColumnDescriptor(ColumnDescriptor columnDescriptor)
        {
            columnDescriptors.Add(columnDescriptor);
            
            this.iGridEX1.RootTable.Columns.Add(columnDescriptor.Name).Caption = columnDescriptor.Caption;
            this.iGridEX1.RootTable.Columns[columnDescriptor.Name].FormatString = columnDescriptor.Format;
            if (columnDescriptor.Width > 0)
            {
                this.iGridEX1.RootTable.Columns[columnDescriptor.Name].Width = columnDescriptor.Width;
            }
           
        }
       
        private void iButtonSelect_Click(object sender, EventArgs e)
        {
            if (!MultipleSelector)
            {
                SelectSingle();          
            }
            else
            {
                SelectedItems.Clear();
                var selectedRows = this.iGridEX1.GetCheckedRows();
                if(selectedRows!=null && selectedRows.Count()>0)
                {
                    foreach (var item in selectedRows)
                    {
                        T selected = (T)item.DataRow;
                        SelectedItems.Add(selected);
                    }
                    HasSelected = true;
                    this.ParentForm.Close();
                }                
            }            
        }

        private void SelectSingle()
        {
            SelectedItems.Clear();
            T selected = (T)this.iGridEX1.CurrentRow.DataRow;
            if (selected != null)
            {
                SelectedItems.Add(selected);
                HasSelected = true;
                this.ParentForm.Close();
            }
        }
        public void AddFilter(Func<T,bool> filter)
        {
            var result = DataItems.Where(filter).ToList();
            bindingList = new BindingList<T>(result);
            bs.DataSource = bindingList;
            bindingList.ResetBindings();
        }
        public void ClearFilter()
        {
            bindingList = new BindingList<T>(DataItems);
            bs.DataSource = bindingList;
            bindingList.ResetBindings();
        }
        private void iButtonCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
