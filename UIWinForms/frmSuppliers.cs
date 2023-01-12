using AutoMapper;
using Business.Interfaces;
using Core.DTOs;
namespace UIWinForms;
public partial class frmSuppliers : Form
{
    private readonly IServiceSupplier srvSupplier;
    private readonly IMapper _mapper;
    private frmProduct frm = new();
    public frmSuppliers(IServiceSupplier pSrvSupplier,
        IMapper p_mapper)
    {
        srvSupplier = pSrvSupplier;
        _mapper = p_mapper;
        InitializeComponent();
    }
    private void frmSuppliers_Load(object sender, EventArgs e)
    {
        frm.DgwFormat(dgwSuppliers);
        dgwSuppliers.DataSource =
            _mapper.Map<List<DtoSupplier>>(srvSupplier.GetAll());
        dgwSuppliers.AutoResizeRows();
    }
}