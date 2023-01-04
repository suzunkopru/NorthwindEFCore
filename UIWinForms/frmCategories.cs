using DataAccess.Interfaces;
namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly IDalCategory dalCategory;
    private frmProduct frm = new();
    public frmCategories(IDalCategory p_dalCategory)
    {
        dalCategory = p_dalCategory;
        InitializeComponent();
    }
    private void frmCategories_Load(object sender, EventArgs e)
    {
        frm.DgwFormat(dgwCategories);
        dgwCategories.DataSource = dalCategory.GetAll().ToList();
        dgwCategories.AutoResizeRows();
    }
}