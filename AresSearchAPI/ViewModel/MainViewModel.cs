using AresSearchAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AresSearchAPI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Variable declarations
        private AppDbContext _context { get; set; }

        public CompanyInformationModel CompanyInformation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _cin;
        public string CIN 
        {
            get => _cin;
            set 
            {
                _cin = value; 
                OnPropertyChanged();
            } 
        }

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ??= new RelayCommand(p => true, p => CreateText());
            }
        }

        private string _textblockText;
        public string TextblockText
        {
            get => _textblockText;
            set
            {
                _textblockText = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MainViewModel() 
        {
            CompanyInformation = new CompanyInformationModel();
            _context = new AppDbContext();
        }

        private async void CreateText()
        {
            CompanyInformationModel? companyInformation = null;
            var text = new StringBuilder();

            var dbEntity = await _context.CompanyInformation
                                         .Include(x => x.Headquarters)
                                         .Include(x => x.MailingAddress)
                                         .FirstOrDefaultAsync(x => x.CIN == CIN);

            if (dbEntity != default)
            {
                companyInformation = dbEntity;
                text.AppendLine("From db");
            }
            else
            {
                HttpClient client = new();

                var response = await client.GetAsync($"https://ares.gov.cz/ekonomicke-subjekty-v-be/rest/ekonomicke-subjekty/{CIN}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    companyInformation = await JsonSerializer.DeserializeAsync<CompanyInformationModel>(stream);

                    if (companyInformation != null)
                    {
                        await _context.AddAsync(companyInformation);
                    }
                    else
                        return;
                }
                else
                {
                    TextblockText = "Nepodařilo se pro dané IČO najít společnost";
                    return;
                }
            }

            var companyInformationProps = companyInformation!.GetType().GetProperties();
            var headQuartersProps = companyInformation.Headquarters!.GetType().GetProperties();
            var mailingAddressProps = companyInformation.MailingAddress!.GetType().GetProperties();

            //loop through CompanyInformation object's primitives
            foreach (var prop in companyInformationProps.Where(x => x.PropertyType != typeof(HeadquartersModel) && x.PropertyType != typeof(MailingAddressModel)))
            {
                text.AppendLine($"{prop.Name}: {prop.GetValue(companyInformation, null)?.ToString()}");
            }

            foreach (var prop in headQuartersProps)
            {
                text.AppendLine($"{prop.Name}: {prop.GetValue(companyInformation.Headquarters, null)?.ToString()}");
            }

            foreach (var prop in mailingAddressProps)
            {
                text.AppendLine($"{prop.Name}: {prop.GetValue(companyInformation.MailingAddress, null)?.ToString()}");
            }

            TextblockText = text.ToString();

            await _context.SaveChangesAsync();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
