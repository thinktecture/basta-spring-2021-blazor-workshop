using System.Threading.Tasks;

namespace BASTAConfTool.Client.Services
{
    public interface IDialogService
    {
        Task<bool> ConfirmAsync(string message);
        Task AlertAsync(string message);
    }
}
