namespace UIWinForms;
public partial class frmProdCatSup : Form
{
    private readonly NorthwindContext context;
    private readonly IServiceVwProdCatSup _srvVwProdCatSup;
    private frmProduct frm = new();
    public frmProdCatSup()
    {
        InitializeComponent();
        context = new NorthwindContext();
        _srvVwProdCatSup = new IServiceVwProdCatSup(context!);
    }
    private void frmProdCatSup_Load(object sender, EventArgs e)
    {
        frm.DgwFormat(dgwProdCatSup);
        dgwProdCatSup.DataSource = _srvVwProdCatSup.GetAll().ToList();
        dgwProdCatSup.AutoResizeRows();
    }
}