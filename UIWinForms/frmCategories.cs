using AutoMapper;
using Business.Interfaces;
using Core.DTOs;
namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly IServiceCategory srvCategory;
    private readonly IMapper _mapper;
    private frmProduct frm = new();
    public frmCategories(IServiceCategory pSrvCategory,
                                    IMapper p_mapper)
    {
        srvCategory = pSrvCategory;
        _mapper = p_mapper;
        InitializeComponent();
    }
    private void frmCategories_Load(object sender, EventArgs e)
    {
        frm.DgwFormat(dgwCategories);
        dgwCategories.DataSource =
            _mapper.Map<List<DtoCategory>>
                (srvCategory.GetAll());
        dgwCategories.AutoResizeRows();
    }
}