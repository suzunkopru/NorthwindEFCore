using DataAccess.Interfaces;
namespace UIWinForms;
public partial class frmSuppliers: Form
{
    private readonly IDalSupplier dalSupplier;
    private frmProduct frm = new();
    public frmSuppliers(IDalSupplier p_dalSupplier)
    {
        InitializeComponent();
        dalSupplier = p_dalSupplier;
    }
    private void frmSuppliers_Load(object sender, EventArgs e)
    {
        frm.DgwFormat(dgwSuppliers);
        dgwSuppliers.DataSource = dalSupplier.GetAll().ToList();
        dgwSuppliers.AutoResizeRows();
    }
}