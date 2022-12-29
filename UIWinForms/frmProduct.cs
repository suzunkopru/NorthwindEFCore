using Entities.Models;
using Microsoft.EntityFrameworkCore;
using static System.Convert;
namespace UIWinForms;
public partial class frmProduct : Form
{
    private readonly NorthwindContext context;
    private readonly DalCategory dalCategory;
    private readonly DalProduct dalProduct;
    private readonly DalDtoProductCatName dalPrdCatName;
    private readonly DalSupplier dalSupplier;
    public frmProduct()
    {
        context = new();
        dalProduct = new DalProduct(context);
        dalCategory = new DalCategory(context);
        dalSupplier = new DalSupplier(context);
        dalPrdCatName = new DalDtoProductCatName(context);
        InitializeComponent();
    }
    private void frmProduct_Load(object sender, EventArgs e)
    {
        dgwProducts.DataSource = ProductIncludeData();
        DgwFormat(dgwProducts);
        dgwProductCatName.DataSource =
            dalPrdCatName.GetProductsCatName().ToList();
        DgwFormat(dgwProductCatName);
        CmbCatLoad();
        CmbSupLoad();
    }
    private List<Product> ProductIncludeData()
    => dalProduct.GetAll()
                .Include(x => x.Category)
                .Include(x => x.Supplier).ToList();
    private void CmbSupLoad()
    {
        cmbSupplierID.DataSource = dalSupplier.GetAll().ToList();
        cmbSupplierID.DisplayMember = nameof(Supplier.CompanyName);
        cmbSupplierID.ValueMember = nameof(Supplier.SupplierId);
    }
    private void CmbCatLoad()
    {
        cmbCategoryID.DataSource = 
        cmbCategories.DataSource = dalCategory.GetAll().ToList();
        cmbCategories.DisplayMember = cmbCategoryID.DisplayMember =
            nameof(Category.CategoryName);
        cmbCategories.ValueMember = cmbCategoryID.ValueMember
            = nameof(Category.CategoryId);
    }
    private void cmbCategories_SelectedIndexChanged
                        (object sender, EventArgs e)
    {
        var cmb = sender as ComboBox;
        var isCatID =
            int.TryParse(cmb.SelectedValue.ToString(),
                         out var catID);
        if (isCatID)
            dgwProducts.DataSource =
                dalPrdCatName.GetProductsByCatergory(catID)
                 .ToList();
    }
    private void txtProductFind_TextChanged
                (object sender, EventArgs e)
    {
        if (sender is TextBox { TextLength: > 2 } txt)
            dgwProducts.DataSource =
                string.IsNullOrWhiteSpace(txt.Text)
                ? dalProduct.GetAll().ToList()
                : dalPrdCatName.Where(x => x.ProductName
                    .Contains(txt.Text)).ToList();
    }
    private void btnEkle_Click(object sender, EventArgs e)
    {
        var product = new Product();
        CRUEntity(CrudType.Insert, product);
        DgwFormat(dgwProducts);
        dgwProducts.DataSource = ProductIncludeData();
        MessageBox.Show($@"{product} Eklendi");
        dgwProducts.Rows[^1].Selected = true;
        dgwProducts.CurrentCell = dgwProducts.Rows[^1].Cells[1];
    }
    private void btnGuncelle_Click(object sender, EventArgs e)
    {
        var product = new Product();
        int satir = dgwProducts.SelectedRows[0].Index;
        CRUEntity(CrudType.Update, product);
        DgwFormat(dgwProducts);
        dgwProducts.DataSource = ProductIncludeData();
        MessageBox.Show($"{product} Güncellendi");
        dgwProducts.Rows[satir].Selected = true;
        dgwProducts.CurrentCell = dgwProducts.Rows[satir].Cells[1];
    }
    private void btnSil_Click(object sender, EventArgs e)
    {
        if (dgwProducts.CurrentRow == null) return;
        var product = new Product();
        CRUEntity(CrudType.Delete, product);
        DgwFormat(dgwProducts);
        dgwProducts.DataSource = ProductIncludeData();
        MessageBox.Show($"{product} Silindi");
        dgwProducts.Rows[^1].Selected = true;
        dgwProducts.CurrentCell = dgwProducts.Rows[^1].Cells[1];
    }
    private async Task CRUEntity(CrudType cruType, Product prd)
    {
        prd.ProductId = cruType == CrudType.Insert ? 0 :
            ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
        prd.ProductName = txtProductName.Text;
        prd.SupplierId = ToInt32(cmbSupplierID.SelectedValue);
        prd.CategoryId = ToInt32(cmbCategoryID.SelectedValue);
        prd.QuantityPerUnit = txtQuantityPerUnit.Text;
        prd.UnitPrice = ToDecimal(txtUnitPrice.Text);
        prd.UnitsInStock = ToInt16(txtUnitsInStock.Text);
        prd.UnitsOnOrder = ToInt16(txtUnitsOnOrder.Text);
        prd.ReorderLevel = ToInt16(txtReorderLevel.Text);
        prd.Discontinued = rdbDiscontinued.Checked;
        switch (cruType)
        {
            case CrudType.Insert:
                await dalProduct.AddAsync(prd);
                break;
            case CrudType.Update:
                dalProduct.Update(prd);
                break;
            case CrudType.Delete:
                dalProduct.Remove(prd);
                break;
        }
    }
    private void dgwProducts_CellClick
            (object sender, DataGridViewCellEventArgs e)
    {
        CrudControl();
        GridToControl(sender);
    }
    private void GridToControl(object sender)
    {
        var row = (sender as DataGridView).CurrentRow;
        txtProductId.Text = row.Cells[0].Value.ToString();
        txtProductName.Text = row.Cells[1].Value.ToString();
        cmbSupplierID.SelectedValue = row.Cells[2].Value;
        cmbCategoryID.SelectedValue = row.Cells[3].Value;
        txtQuantityPerUnit.Text = row.Cells[4].Value.ToString();
        txtUnitPrice.Text = row.Cells[5].Value.ToString();
        txtUnitsInStock.Text = row.Cells[6].Value.ToString();
        txtUnitsOnOrder.Text = row.Cells[7].Value.ToString();
        txtReorderLevel.Text = row.Cells[8].Value.ToString();
        rdbDiscontinued.Checked = ToBoolean(row.Cells[9].Value);
    }
    private void btnEkle_MouseMove(object sender,
            MouseEventArgs e) => CrudControl(sender);
    private void btnGuncelle_MouseMove(object sender,
            MouseEventArgs e) => CrudControl(sender);
    private void btnSil_MouseHover(object sender,
            EventArgs e) => CrudControl(sender);
    private void btnEkle_Enter(object sender,
            EventArgs e) => CrudControl(sender);
    private void btnGuncelle_Enter(object sender,
            EventArgs e) => CrudControl(sender);
    private void btnSil_Enter(object sender,
            EventArgs e) => CrudControl(sender);
    private void CrudControl(object sender = null)
    {
        var button = (Button)sender;
        if (button == null || context == null) return;
        btnEkle.Enabled = true;
        btnYeni.Enabled = true;
        btnSil.Enabled = true;
        btnGuncelle.Enabled = true;
        if (txtProductId.Text != "" && button == btnEkle)
        {
            MessageBox.Show(
            $"""
            Bu ürün zaten mevcuttur, ancak güncelleme 
            veya Silme işlemi yapabilirsiniz?"
            """);
        }
        else if (txtProductId.Text == "" && button != btnEkle)
        {
            string delUp = button == btnSil ? "Sil" : "Güncelle";
            MessageBox.Show(
            $$"""
            Grid üzerinden bir ürün seçmediniz.
            Hangi ürün {{delUp}}me işlemine tabi tutulacak seçmeniz gerekir.
            """);
        }
    }
    private void btnYeni_Click(object sender,
         EventArgs e) => txtProductId.Text = "";
    private void btnTumu_Click(object sender, EventArgs e)
    {
        DgwFormat(dgwProducts);
        dgwProducts.DataSource = ProductIncludeData();
        txtAra.Clear();
    }
    private void btnCategories_Click(object sender, EventArgs e)
    {
        var frmOpen = new frmCategories();
        frmOpen.Show();
    }
    private void btnSupplier_Click(object sender, EventArgs e)
    {
        var frmOpen = new frmSuppliers();
        frmOpen.Show();
    }
    private void btnDTO_Click(object sender, EventArgs e)
    {
        var frmOpen = new frmProdCatSup();
        frmOpen.Show();
    }
    public void DgwFormat(DataGridView dgw)
    {
        int satirNo = 1;
        foreach (DataGridViewRow item in dgw.Rows)
        {
            item.HeaderCell.Value = satirNo.ToString();
            satirNo++;
            if (satirNo > 500) break;
        }
        dgw.RowsDefaultCellStyle.BackColor = Color.White;
        dgw.AlternatingRowsDefaultCellStyle.BackColor =
        Color.GhostWhite;
        dgw.EditMode = DataGridViewEditMode.EditProgrammatically;
        dgw.AllowUserToDeleteRows = false;
        dgw.AllowUserToAddRows = false;
        dgw.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        dgw.AutoSizeRowsMode = 
            DataGridViewAutoSizeRowsMode.DisplayedCells;
        dgw.AutoSizeColumnsMode = 
            DataGridViewAutoSizeColumnsMode.Fill;
    }
}