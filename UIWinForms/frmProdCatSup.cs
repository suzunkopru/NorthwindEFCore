namespace UIWinForms;
public partial class frmProdCatSup : Form
{
    private readonly NorthwindContext context;
    private readonly DalVwProdCatSup dalVwProdCatSup;
    //private frmProduct frm = new();
    public frmProdCatSup()
    {
        InitializeComponent();
        context = new NorthwindContext();
        dalVwProdCatSup = new DalVwProdCatSup(context!);
    }
    private void frmProdCatSup_Load(object sender, EventArgs e)
    {
        //frm.DgwFormat(dgwProdCatSup);
        dgwProdCatSup.DataSource = dalVwProdCatSup.GetAll().ToList();
        dgwProdCatSup.AutoResizeRows();
    }
}