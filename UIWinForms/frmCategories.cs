namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly NorthwindContext context;
    private readonly DalCategory dalCategory;
    private frmProduct frm = new();
    public frmCategories()
    {
        InitializeComponent();
        context = new NorthwindContext();
        dalCategory = new DalCategory(context!);
    }
    private void frmCategories_Load(object sender, EventArgs e)
    {
        frm.DgwFormat(dgwCategories);
        dgwCategories.DataSource = dalCategory.GetAll().ToList();
        dgwCategories.AutoResizeRows();
    }
}