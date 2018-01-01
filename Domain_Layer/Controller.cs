using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical_Services_Layer;
using System.Windows.Controls;

namespace Domain_Layer
{
    public class Controller
    {
        private static Controller instance;

        public OfficeSupplies OfficeSupplies { get; set; }

        public List<string> officeSuppliesValues;

        public static Controller GetInstance()
        {
            if (instance == null)
            {
                instance = new Controller();
            }

            return instance;
        }

        //Adding, counting or deleting stocks and categories
        public string C_AddSupply(string SupplyName, string SupplyDescription, string SupplyAmount, string SupplyUnit, string Building, string CategoryTitle)
        {
            StoredProcedures sp = new StoredProcedures();
            return sp.AddSupply(SupplyName, SupplyDescription, SupplyAmount, SupplyUnit, Building, CategoryTitle);
        }

        public string C_AddCategory(string CategoryTitle)
        {
            StoredProcedures sp = new StoredProcedures();
            return sp.AddCategory(CategoryTitle);
        }

        public void C_DeleteOfficeSupply(int supplyID)
        {
            StoredProcedures sp = new StoredProcedures();
            sp.DeleteOfficeSupply(supplyID);
        }

        public void C_DeleteCategory(string categoryTitle)
        {
            StoredProcedures sp = new StoredProcedures();
            sp.DeleteCategory(categoryTitle);
        }

        public List<OfficeSupplies> C_SeeSupplyCategory()
        {
            StoredProcedures sp = new StoredProcedures();
            return sp.SeeSupplyCategory();
        }
        public string C_CountSupply(int countAmount, string countMonth, string countYear, int supplyID)
        {
            StoredProcedures sp = new StoredProcedures();
            return sp.CountSupply(countAmount, countMonth, countYear, supplyID);
        }

        //Statistics and editing
        public List<OfficeSupplies> C_SeeOfficeSupplies()
        {
            StoredProcedures sp = new StoredProcedures();
            return sp.SeeOfficeSupplies();
        }
        public string C_ConfirmEdit(string SupplyID, string SupplyName, string SupplyDescription, string SupplyAmount, string SupplyUnit, string Building, string CategoryTitle)
        {
            StoredProcedures sp = new StoredProcedures();
            return sp.ConfirmEdit(SupplyID, SupplyName, SupplyDescription, SupplyAmount, SupplyUnit, Building, CategoryTitle);
        }

        //ListView
        public void SetListViewSource(ListView listView)
        {
            listView.ItemsSource = C_SeeOfficeSupplies();
        }

        public void SetCategoryListViewSource(ListView listView)
        {
            listView.ItemsSource = C_SeeSupplyCategory();
        }

        public void CastSelectedListViewItem(object selectedItem)
        {
            OfficeSupplies = (OfficeSupplies)selectedItem;
        }

        public void LoadValuesIntoList()
        {
            officeSuppliesValues = new List<string>
            {
                OfficeSupplies.supplyID.ToString(),
                OfficeSupplies.supplyName,
                OfficeSupplies.supplyDescription,
                OfficeSupplies.supplyAmount.ToString(),
                OfficeSupplies.supplyUnit,
                OfficeSupplies.building,
                OfficeSupplies.categoryTitle
            };
        }

        public void LoadValuesIntoComboBox(ComboBox comboBox)
        {
            foreach (OfficeSupplies supply in C_SeeSupplyCategory())
            {
                if (!comboBox.Items.Contains(supply.categoryTitle))
                {
                    comboBox.Items.Add(supply.categoryTitle);
                }
            }

            if (OfficeSupplies != null)
            {
                comboBox.SelectedValue = OfficeSupplies.categoryTitle;
            }
        }
    }
}
