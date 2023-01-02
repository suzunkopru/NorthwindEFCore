namespace UIWinForms;
public partial class frmSuppliers: Form
{
    private readonly NorthwindContext context;
    private readonly DalSupplier dalSupplier;
    //private frmProduct frm = new();
    public frmSuppliers()
    {
        InitializeComponent();
        context = new NorthwindContext();
        dalSupplier = new DalSupplier(context!);
    }
    private void frmSuppliers_Load(object sender, EventArgs e)
    {
        //frm.DgwFormat(dgwSuppliers);
        dgwSuppliers.DataSource = dalSupplier.GetAll().ToList();
        dgwSuppliers.AutoResizeRows();
    }
}