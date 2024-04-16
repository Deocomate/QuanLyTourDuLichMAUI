using TourManagementMAUI.Model;

namespace TourManagementMAUI;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;
        bool isValidUser = await AuthenticateUser(username, password);
        if (isValidUser)
        {
            // Chuyển hướng, mở trang MainPage.xaml ??? Open MainPage.xaml in new Window
            await DisplayAlert("Đăng nhập thành công", "Đăng nhập thành công", "OK");
            MainPage mainPage = new MainPage();
            Application.Current.MainPage = mainPage;
        }
        else
        {
            await DisplayAlert("Lỗi đăng nhập", "Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại.", "OK");
        }
    }

    private Task<bool> AuthenticateUser(string username, string password)
    {
        Admin_ adm = new Admin_();
        List<Admin_> admins = Admin_DAO.List();
        foreach (var item in admins)
        {
            if (username.Equals(item.TenDangNhap) && password.Equals(item.MatKhau))
            {
                return Task.FromResult(true);
            }
        }
        return Task.FromResult(false);
    }
}