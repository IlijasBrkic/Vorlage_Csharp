namespace WinUIWpf.ViewModels;

using Core.Contracts;

using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Base.WpfMvvm;

/// <summary>
/// TODO
/// </summary>
public class MainViewModel : BaseViewModel
{
    #region ctr

    public MainViewModel(IUnitOfWork uow)
    {
        _uow = uow;
    }

    private IUnitOfWork _uow;

    #endregion

    #region Properties

    public IWindowNavigator? Controller { get; set; }


    #endregion

    #region Operations

    public async Task LoadDataAsync()
    {

    }

    #endregion
}