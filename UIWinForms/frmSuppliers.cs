using AutoMapper;
using Core.DTOs;
using DataAccess.Interfaces;
namespace UIWinForms;
public partial class frmSuppliers : Form
{
    private readonly IDalSupplier dalSupplier;
    private readonly IMapper _mapper;
    private frmProduct frm = new();
    public frmSuppliers(IDalSupplier p_dalSupplier,
                                    IMapper p_mapper)
    {
        dalSupplier = p_dalSupplier;
        _mapper = p_mapper;
        InitializeComponent();
    }
    private void frmSuppliers_Load(object sender, EventArgs e)
    {
        frm.DgwFormat(dgwSuppliers);
        dgwSuppliers.DataSource =
                _mapper.Map<List<DtoSupplier>>(dalSupplier.GetAll());
        dgwSuppliers.AutoResizeRows();
    }
}