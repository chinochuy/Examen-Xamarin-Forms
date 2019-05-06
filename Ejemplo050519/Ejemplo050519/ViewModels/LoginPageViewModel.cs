using Plugin.Connectivity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Ejemplo050519.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
        public ICommand GoToMainPage { get; set; }
        private readonly IPageDialogService pageDialogService = null;

        #region Properties

        private string username;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                if (username == value)
                {
                    return;
                }
                username = value;
                RaisePropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            this.pageDialogService = pageDialogService;
            GoToMainPage = new DelegateCommand(GoToMainPageExecute);
        }

        private async void GoToMainPageExecute()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (username == null || password == null || username == "" || password == "")
                {
                    await pageDialogService.DisplayAlertAsync("Error", "No puede ir ningún campo vacío", "Ok");
                }
                else
                {
                    var email = Username;
                    var emailformat = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";

                    if (!Regex.IsMatch(username, emailformat))
                    {
                        await pageDialogService.DisplayAlertAsync("Error", "Formato de correo no válido", "Ok");
                    }
                    else
                    {
                        if (username == "ex@hotmail.com" && password == "examen123")
                        {
                            await NavigationService.NavigateAsync(PageNames.MainPage);
                        }
                        else
                        {
                            await pageDialogService.DisplayAlertAsync("Error", "Datos Incorrectos", "Ok");
                        }                        
                    }
                }              
            }
            else
            {
                await pageDialogService.DisplayAlertAsync("Error", "Revisar conexón a internet", "Ok");
            }
        }
    }
}
