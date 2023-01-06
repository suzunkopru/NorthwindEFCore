using AutoMapper;
using Core.DTOs;
using DataAccess.Interfaces;
namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly IDalCategory dalCategory;
    private readonly IMapper _mapper;
    private frmProduct frm = new();
    public frmCategories(IDalCategory p_dalCategory,
                                    IMapper p_mapper)
    {
        dalCategory = p_dalCategory;
        _mapper = p_mapper;
        InitializeComponent();
    }
    private void frmCategories_Load(object sender, EventArgs e)
    {
        frm.DgwFormat(dgwCategories);
        dgwCategories.DataSource =
            _mapper.Map<List<DtoCategory>>(dalCategory.GetAll());
            //dalCategory.GetAll().ToList();
        dgwCategories.AutoResizeRows();
    }
}